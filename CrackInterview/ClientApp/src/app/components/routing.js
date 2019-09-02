import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import App from './App';
import Contact from './contact';
import About from './about';
import Login from './Login';
import Home from './home';
import SignUP from './sign-in';
import ForgetPassword from './forget';
import SecurityQuestion from './securityQuestion';
import OTPVerify from './otpverify';
import Register from './register';

export default(
  <BrowserRouter>
      <Switch>
        <Route exact path='/' component={Register} />
        {/* <Route path='/' component={Home} /> */}
        <Route path = "/about" component = {About} />
        <Route path = "/contact" component = {Contact} />
        <Route path = "/login" component = {Login} />
        <Route path = "/signup" component = {SignUP} />
      </Switch>
    </BrowserRouter>
)