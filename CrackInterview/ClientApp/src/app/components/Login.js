import React from 'react';
import loginImage from '../../Images/userLogin.png';
import '../../Css/login.css';
import Header from './header';
import { Link } from "react-router-dom";

class Login extends React.Component{
    render(){
        return(
            <div>
                <Header/>
                <div className="card">
                    <div className="card-header loginheader">
                        <img src={loginImage} alt="Login"/>
                    </div>
                    <div className="card-body">
                    <div className="input-container">
                        <i className="fa fa-envelope icon"></i>
                        <input className="input-field" type="text" placeholder="Email" name="email"/>
                    </div>
                    <div className="input-container">
                        <i className="fa fa-key icon"></i>
                        <input className="input-field" type="password" placeholder="Password" name="psw"/>
                    </div>
                    <div className="row">
                    <div className="col-sm-4">
                        <div className="custom-control custom-switch">
                            <input type="checkbox" className="custom-control-input" id="switch1"/>
                            <label className="custom-control-label" htmlFor="switch1">Remember me</label>
                        </div>
                    </div>
                    <div className="col-sm-3">
                    <Link to="\">Forget Password?</Link>
                    </div>
                    </div>
                    <button type="submit" className="btn">Login</button>
                    </div>
                </div>
            </div>
        )
    }
}
export default Login;