import React from 'react';
import ReactDOM from 'react-dom';
import { Router,browserHistory } from 'react-router';
import routing from './components/routing';

ReactDOM.render(
    routing
    ,document.getElementById('MyApp'));