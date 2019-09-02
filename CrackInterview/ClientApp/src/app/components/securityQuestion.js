import React from 'react';
import Headers from './header';
import "../../Css/forget.css";

class SecurityQuestion extends React.Component{
render(){
    document.body.style.backgroundColor="blue";
    return(
        <div className="elelment">
            <h2>Security Questions Form</h2>
            <div className="card">
                <div className="card-body">
                    <select className="form-control form-control-sm txtcenter" id="secQues1">
                        <option>-- Select Any Option --</option>
                    </select>
                    <input type="text" className="form-control form-control-sm txtcenter" placeholder="Security Answer" />
                    <select className="form-control form-control-sm txtcenter" id="secQues2">
                        <option>-- Select Any Option --</option>
                    </select>
                    <input  type="text" className="form-control form-control-sm txtcenter" placeholder="Security Answer" />
                </div>
                <div className="card-footer">
                    <button type="submit" className="btn btn-success">Submit</button>
                </div>
            </div>
        </div>
    )
}
}
export default SecurityQuestion;