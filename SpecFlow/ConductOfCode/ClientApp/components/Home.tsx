import * as React from 'react';
import Stack from './Stack';

export default class Home extends React.Component<void, void> {
    public render() {
        return <div>
            <h1>Stack</h1>
            <Stack />
        </div>;
    }
}
