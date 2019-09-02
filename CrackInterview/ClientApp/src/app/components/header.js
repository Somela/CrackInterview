import React from 'react';
// import '../css/style.css';
import { Link } from "react-router-dom";
import "@material-ui/core";
// import imgAppName from '../../Images/appName.JPG';

class Header extends React.Component{
    render(){
        return(
<nav className="navbar navbar-expand-sm navload navbar-light">
            <div className="container">
               <Link className="navbar-brand" to="/"><img id="imgAppName" alt="Crack Interview" src="../../Images/appName.JPG"/></Link>
                 <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarResponsive">
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item active">
                        <Link className="nav-link" to="/">Home
                            <span className="sr-only">(current)</span>
                        </Link>
                        </li>
                        <li className="nav-item active">
                        <Link className="nav-link" to="/about">About
                            
                        </Link>
                        </li>
                        <li className="nav-item active">
                        <Link className="nav-link" to="/contact">Contact
                        </Link>
                        </li>
                        <li className="nav-item active">
                        <Link className="nav-link" to="/contact">Login
                        </Link>
                        </li>
                        <li className="nav-item active">
                        <Link className="nav-link" to="/contact">SignUp
                        </Link>
                        </li>
                    </ul>
                    </div>
                </div>
            </nav>
                    )
    }
}
export default Header;