import React from 'react';
import '../../Css/forget.css';

class Register extends React.Component{
    render(){
        return(
            <div className="container">
            <form className="form-horizontal" role="form">
                <h2>Registration</h2>
                <div className="card">
                    <div className="card-body">
                    <input type="text" id="FirstName" placeholder="Enter First Name" className="register form-control form-control-sm"/>
                    <input type="text" id="LastName" placeholder="Enter Last Name" className="register form-control form-control-sm"/>
                    <input type="text" id="MiddleName" placeholder="Enter Middle Name" className=" register form-control form-control-sm"/>
                    <input type="email" id="Email" placeholder="Enter Email" className=" register form-control form-control-sm"/>
                    <input type="text" id="Password" placeholder="Enter Password" className=" register form-control form-control-sm"/>
                    <input type="date" id="dateofbirth" placeholder="Enter Date Of Birth" className=" register form-control form-control-sm"/>
                    <select id="secQues1" className=" register form-control form-control-sm">
                        <option>-- Please select Any --</option>
                    </select>
                    <input type="text" id="secAns1" placeholder="Security Answer" className="register form-control form-control-sm"/>
                    <select id="secQues2" className="register form-control form-control-sm">
                        <option>-- Please select Any --</option>
                    </select>
                    <input type="text" id="secAns2" placeholder="Security Answer" className="register form-control form-control-sm"/>
                    <select id="secQues1" className="register form-control form-control-sm">
                        <option>-- Please select Any --</option>
                    </select>
                    <input type="text" id="secAns3" placeholder="Security Answer" className="register form-control form-control-sm"/>
                    </div>
                    <div className="card-footer">
                    <button type="submit" className="btn btn-success">Submit</button>
                </div>
                </div>
            </form>
        </div> 
            )
    }
}
export default Register;