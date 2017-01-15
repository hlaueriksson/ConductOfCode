import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ThunkAction, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface StackState {
    isLoading: boolean;
    isDirty: boolean;
    items: Item[];
    result: Item;
    error: Error;
}

export interface Item {
    value: string;
}

export interface Error {
    message: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

interface RequestClearAction { type: 'REQUEST_CLEAR' }
interface ReceiveClearAction { type: 'RECEIVE_CLEAR' }

interface RequestPeekAction { type: 'REQUEST_PEEK' }
interface ReceivePeekAction { type: 'RECEIVE_PEEK', result: Item }

interface RequestPopAction { type: 'REQUEST_POP' }
interface ReceivePopAction { type: 'RECEIVE_POP', result: Item }

interface RequestPushAction { type: 'REQUEST_PUSH', value: string }
interface ReceivePushAction { type: 'RECEIVE_PUSH' }

interface RequestToArrayAction { type: 'REQUEST_TOARRAY' }
interface ReceiveToArrayAction { type: 'RECEIVE_TOARRAY', items: Item[] }

interface ErrorAction { type: 'ERROR', error: Error }

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction =
    RequestClearAction | ReceiveClearAction |
    RequestPeekAction | ReceivePeekAction |
    RequestPopAction | ReceivePopAction |
    RequestPushAction | ReceivePushAction |
    RequestToArrayAction | ReceiveToArrayAction |
    ErrorAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestClear: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`/api/Stack/Clear`, {
                method: 'POST'
            })
            .then(response => dispatch({ type: 'RECEIVE_CLEAR' }));

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_CLEAR' });
    },
    requestPeek: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`/api/Stack/Peek`)
            .then(response => {
                if (response.status == 200) {
                    return response.json() as Promise<Item>
                } else {
                    (response.json() as Promise<Error>)
                    .then(error => dispatch({ type: 'ERROR', error: error }))
                }
            })
            .then(data => dispatch({ type: 'RECEIVE_PEEK', result: data }));

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_PEEK' });
    },
    requestPop: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`/api/Stack/Pop`)
            .then(response => {
                if (response.status == 200) {
                    return response.json() as Promise<Item>
                } else {
                    (response.json() as Promise<Error>)
                    .then(error => dispatch({ type: 'ERROR', error: error }))
                }
            })
            .then(data => dispatch({ type: 'RECEIVE_POP', result: data }));

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_POP' });
    },
    requestPush: (value: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`/api/Stack/Push`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({value: value })
            })
            .then(response => dispatch({ type: 'RECEIVE_PUSH' }));

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_PUSH', value: value });
    },
    requestToArray: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`/api/Stack/ToArray`)
            .then(response => response.json() as Promise<Item[]>)
            .then(data => dispatch({ type: 'RECEIVE_TOARRAY', items: data }));

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_TOARRAY' });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: StackState = { isLoading: false, isDirty: false, items: [], result: null, error: null };

export const reducer: Reducer<StackState> = (state: StackState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_CLEAR':
            return Object.assign({}, state, {
                isLoading: true
            });
        case 'RECEIVE_CLEAR':
            return Object.assign({}, state, {
                isLoading: false,
                isDirty: true,
                result: null,
                error: null
            });
        case 'REQUEST_PEEK':
            return Object.assign({}, state, {
                isLoading: true
            });
        case 'RECEIVE_PEEK':
            return Object.assign({}, state, {
                isLoading: false,
                result: action.result
            });
        case 'REQUEST_POP':
            return Object.assign({}, state, {
                isLoading: true
            });
        case 'RECEIVE_POP':
            return Object.assign({}, state, {
                isLoading: false,
                isDirty: true,
                result: action.result
            });
        case 'REQUEST_PUSH':
            return Object.assign({}, state, {
                isLoading: true
            });
        case 'RECEIVE_PUSH':
            return Object.assign({}, state, {
                isLoading: false,
                isDirty: true,
                result: null,
                error: null
            });
        case 'REQUEST_TOARRAY':
            return Object.assign({}, state, {
                isLoading: true
            });
        case 'RECEIVE_TOARRAY':
            return Object.assign({}, state, {
                isLoading: false,
                isDirty: false,
                items: action.items
            });
        case 'ERROR':
            return Object.assign({}, state, {
                error: action.error
            });
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    // For unrecognized actions (or in cases where actions have no effect), must return the existing state
    //  (or default initial state if none was supplied)
    return state || unloadedState;
};
