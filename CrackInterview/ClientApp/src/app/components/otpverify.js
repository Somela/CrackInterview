import React from 'react';
class OTPVerify extends React.Component{
    render(){
        return(
            <div className="element">
                <h2>OTP Verification</h2>
                    <div className="card cardEmail">
                    <div className="card-header"  id="cardOTP">
                        <h4>Please enter OTP Here</h4>
                    </div>
                        <div className="card-body">
                           <input type="text" placeholder="Enter OTP Here" className="form-control form-control-sm"/>
                        </div>
                        <div className="card-footer">
                           <button className="btn btn-sm btn-success">Submit</button>
                        </div>
                    </div>
            </div>
            )
    }
}
export default OTPVerify;