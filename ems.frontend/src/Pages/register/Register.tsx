import { useState } from "react";
import RegisterInput from "../../ReusableComponents/RegisterInput";
import Row from "../../ReusableComponents/Row";
import { UserRegister } from "../../models/user/User";
import Button from "../../ReusableComponents/Button";
import adminService from "../../services/adminService";
import { toast } from "sonner";

const Register = () => {

    const [user,setUser] = useState<UserRegister>({
        firstName:'',
        lastName:'',
        employeeID:'',
        password:'',
        confirmPassword:'',
        address:'',
        phoneNumber:'',
        email:'',
        dateOfBirth: new Date(),
        dateOfJoin:new Date(),
        location:'',
        maritalStatus:'',
        gender:'',
        bloodGroup:'',
        emergencyNumber:'',
        about:'',
        school:'',
        college:'',
        previouCompany:''
    });

    const handleFirstName = (name:string) => {
        setUser({...user,firstName:name});
    }

    const handleLastName = (name:string) => {
        setUser({...user,lastName:name});
    }

    const handleEmployeeId = (empId:string) => {
        setUser({...user,employeeID:empId});
    }

    const handleAddress = (address:string) => {
        setUser({...user,address:address});
    }

    const handlePhoneNumber = (phNumber:string) => {
        setUser({...user,phoneNumber:phNumber});
    }

    const handleEmail = (email:string) => {
        setUser({...user,email:email});
    }

    const handleDateOfBirth = (date:Date) => {
        setUser({...user,dateOfBirth:date});
    }

    const handlePassword = (password:string) => {
        setUser({...user,password:password});
    }

    const handleConfirmPassword = (confirmPassword:string) => {
        setUser({...user,confirmPassword:confirmPassword});
    }

    const handleDateOfJoin = (date:Date) => {
        setUser({...user,dateOfJoin:date});
    }

    const handleLocation = (locaton:string) => {
        setUser({...user,location:locaton});
    }

    const handleMaritalStatus = (status:string) => {
        setUser({...user,maritalStatus:status});
    }

    const handleGender = (gender:string) => {
        setUser({...user,gender:gender});
    }

    const handleEmergencyContactNumber = (contactNumber:string) => {
        setUser({...user,emergencyNumber:contactNumber});
    }

    const handleRegister = async () => {
        await adminService.register(user).then( (response) =>{
            console.log(response);
            toast.success("Registered Successfully");
        }).catch((error)=>console.log(error));
    }


    return (
        <div>
            <Row>
                <label htmlFor="FirstName">First Name</label>
                <RegisterInput type="text" 
                    name="FirstName"
                    value={user.firstName}
                    maxLength={25}        
                    placeholder="Your Name"
                    id="FirstName"
                    onChange={(event)=>handleFirstName(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="LastName">Last Name</label>
                <RegisterInput type="text" 
                    name="LastName"
                    value={user.lastName}
                    maxLength={25}        
                    placeholder="Your Last Name"
                    id="LastName"              
                    onChange={(event)=>handleLastName(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="EmpId">Employee Id</label>
                <RegisterInput type="text" 
                    name="EmpId"
                    value={user.employeeID}
                    maxLength={5}        
                    placeholder="Employee Id"
                    id="EmpId" 
                    onChange={(event)=>handleEmployeeId(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="DateOfBirth">Date Of Birth</label>
                <RegisterInput type="date" 
                    name="DateOfBirth"
                    id="DateOfBirth"
                    onChange={(event)=>handleDateOfBirth(new Date(event.target.value))}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="PhoneNumber">Phone Number</label>
                <RegisterInput type="text" 
                    name="PhoneNumber"
                    value={user.phoneNumber}
                    maxLength={15}        
                    placeholder="Your Phone Number"
                    id="PhoneNumber"
                    onChange={(event)=>handlePhoneNumber(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="Address">Address</label>
                <RegisterInput type="text" 
                    name="Address"
                    value={user.address}
                    maxLength={75}        
                    placeholder="Your Address"
                    id="Address"
                    onChange={(event)=>handleAddress(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="Email">Email</label>
                <RegisterInput type="text" 
                    name="Email"
                    value={user.email}
                    maxLength={20}        
                    placeholder="Your Email"
                    id="Email"
                    onChange={(event)=>handleEmail(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="Password">Password</label>
                <RegisterInput type="password" 
                    name="Password"
                    value={user.password}
                    maxLength={25}        
                    placeholder="Enter Password here"
                    id="Password"
                    onChange={(event)=>handlePassword(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="ConfirmPassword">Confirm Password</label>
                <RegisterInput type="password" 
                    name="ConfirmPassword"
                    value={user.confirmPassword}
                    maxLength={25}        
                    placeholder="Confirm Password"
                    id="ConfirmPassword"
                    onChange={(event)=>handleConfirmPassword(event.target.value)}
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="DateOfJoining">Date Of Joining</label>
                <RegisterInput type="date" 
                    name="DateOfJoining"
                    id="DateOfJoining"
                    onChange={(event)=>handleDateOfJoin(new Date(event.target.value))}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="Location">Work Location</label>
                <RegisterInput type="text" 
                    name="Location"
                    value={user.location}
                    maxLength={20}        
                    placeholder="Your Location"
                    id="Location"
                    onChange={(event)=>handleLocation(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="MaritalStatus">Marital Status</label>
                <RegisterInput type="text" 
                    name="MaritalStatus"
                    value={user.maritalStatus}
                    maxLength={10}        
                    placeholder="Your Marital Status"
                    id="MaritalStatus"
                    onChange={(event)=>handleMaritalStatus(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="Gender">Gender</label>
                <RegisterInput type="text" 
                    name="Gender"
                    value={user.gender}
                    maxLength={75}        
                    placeholder="Your Gender"
                    id="Gender"
                    onChange={(event)=>handleGender(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="EmergencyNumber">Emergency Number</label>
                <RegisterInput type="text" 
                    name="EmergencyNumber"
                    value={user.emergencyNumber}
                    maxLength={15}        
                    placeholder="Your EmergencyNumber"
                    id="EmergencyNumber"
                    onChange={(event)=>handleEmergencyContactNumber(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="About">About</label>
                <RegisterInput type="text" 
                    name="About"
                    value={user.about}
                    maxLength={500}        
                    placeholder="About Yourself"
                    id="About"
                    onChange={(event)=>(event.target.value)}                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="PreviousCompany">Previous Company</label>
                <RegisterInput type="text" 
                    name="PreviousCompany"
                    value={user.previouCompany}
                    maxLength={25}        
                    placeholder="PreviousCompany"
                    id="PreviousCompany"                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="College">College</label>
                <RegisterInput type="text" 
                    name="College"
                    value={user.college}
                    maxLength={25}        
                    placeholder="Your College"
                    id="College"                    
                ></RegisterInput>
            </Row>
            <Row>
                <label htmlFor="School">School</label>
                <RegisterInput type="text" 
                    name="School"
                    value={user.school}
                    maxLength={25}        
                    placeholder="Your School"
                    id="School"                    
                ></RegisterInput>
            </Row>
            <Button onClick={handleRegister}>Register</Button>
        </div>
    );
};

export default Register;