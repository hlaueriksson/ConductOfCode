import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as StackStore from '../store/Stack';

type StackProps = StackStore.StackState & typeof StackStore.actionCreators;

class Stack extends React.Component<StackProps, void> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestToArray();
    }

    componentWillReceiveProps(nextProps: StackProps) {
        // This method runs when incoming props (e.g., route params) change
        if (nextProps.isDirty) this.props.requestToArray();
    }

    public render() {
        let result = null;
        if (this.props.result) result = <p>Result: <strong id="result">{this.props.result.value}</strong></p>;

        let error = null;
        if (this.props.error) error = <p>Error: <strong id="error">{this.props.error.message}</strong></p>;

        return <div>
            <input id="value" />
            <button id="push" onClick={() => { this.props.requestPush(document.getElementById('value')['value']) } }>Push</button>

            <ul>
                {this.props.items.map((item, index) =>
                    <li key={index} className="item">{item.value}</li>
                )}
            </ul>

            <button id="clear" onClick={() => { this.props.requestClear() } }>Clear</button>
            <button id="peek" onClick={() => { this.props.requestPeek() } }>Peek</button>
            <button id="pop" onClick={() => { this.props.requestPop() } }>Pop</button>

            <div id="output">
                {result}
                {error}
            </div>
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.stack, // Selects which state properties are merged into the component's props
    StackStore.actionCreators                 // Selects which action creators are merged into the component's props
)(Stack);
