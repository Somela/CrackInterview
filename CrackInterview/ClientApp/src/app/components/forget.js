import React from 'react';
import Headers from './header';
import "../../Css/forget.css";

class ForgetPassword extends React.Component{
render(){
    document.body.style.backgroundColor="blue";
    return(
        <div className="elelment">
            <h2>Reset Password Form</h2>
            <div className="element-main">
		        <h1>Forgot Password</h1>
		            <p> Please Enter Email to reset Password</p>
                    <form>
                        <input type="text" placeholder="Your e-mail address" />
                        <button type="submit" className="btn btn-sm btn-primary">Reset my Password</button>
                    </form>
            </div>
        </div>
    )
}
}
export default ForgetPassword;