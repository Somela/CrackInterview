import React from 'react';
import Headers from './header';
import { Field, reduxForm } from 'redux-form'
import { Link } from "react-router-dom";


class Contact extends React.Component{
    render(){
        return(
            <form>
                <Headers/>
                <div className="main">
                    <div className="main-inner">More than a website</div>
                    <div className="contact-us" id="contact-us">
                        <div className="wrap">
                            <div className="pannel-left">
                                <h3>Get in Touch</h3>
                                <p>Please fill out the quick form and we will be in touch with lightning speed.</p>
                                <div className="contact-form">
                                    <div className="card">
                                        <div className="card-body">
                                            <input type="text" className="form-control form-control-sm text" placeholder="Name"/>
                                            <input type="text" className="form-control form-control-sm text" placeholder="Your Email Address"/>
                                            <textarea type="text" className="form-control form-control-sm text" placeholder="Message"/>
                                        </div>
                                        <div className="card-footer">
                                            <button type="submit" className="btn btn-success">Submit</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="pannel-right">
                                <h3>Connect with us:</h3>
                                <p className="textMail">For support or any questions:crackInterview@gmail.com</p>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
            )
    }
}
export default Contact;