import * as React from 'react';
import { Router, Route, HistoryBase } from 'react-router';
import Home from './components/Home';

export default <Route path='/' component={ Home } />;

// Enable Hot Module Replacement (HMR)
if (module.hot) {
    module.hot.accept();
}
