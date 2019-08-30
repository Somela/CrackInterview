import React from 'react';
// import '../css/style.css';
import { Link } from "react-router-dom";

class Header extends React.Component{
    render(){
        return(
            <nav className="navbar navbar-expand-sm navload navbar-light">
            <div className="container">
               <a className="navbar-brand" href="/"><h3 className="title">Crack Interview</h3></a>
                 <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarResponsive">
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item active">
                        <a className="nav-link" src="/">Home
                            <span className="sr-only">(current)</span>
                        </a>
                        </li>
                        <li className="nav-item active">
                        <a className="nav-link" src="/">About
                            
                        </a>
                        </li>
                        <li className="nav-item active">
                        <a className="nav-link" src="/">Services
                        </a>
                        </li>
                        <li className="nav-item active">
                        <a className="nav-link" src="/">Contact
                        </a>
                        </li>
                    </ul>
                    </div>
                </div>
            </nav>
        )
    }
}
export default Header;