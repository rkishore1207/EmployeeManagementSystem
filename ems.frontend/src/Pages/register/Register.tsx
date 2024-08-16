/* eslint-disable @typescript-eslint/no-explicit-any */
import { useCallback, useState } from "react";
import RegisterInput from "../../ReusableComponents/RegisterInput";
import Row from "../../ReusableComponents/Row";
import { User } from "../../models/user/User";
import Button from "../../ReusableComponents/Button";
import adminService from "../../services/adminService";
import { toast } from "sonner";
import { useDropzone } from "react-dropzone";
import styles from "./Register.module.css";
import ValidationText from "../../ReusableComponents/ValidationText";

const Register = () => {

    const [user,setUser] = useState<User>({
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
    const [imageError,setImageError] = useState<string>('');
    const [imageURL,setImageURL] = useState<any>(null);
    const [image,setImage] = useState<any>(null);

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
        const formData = new FormData();
        formData.append("image",image);
        await adminService.uploadImage(formData).then( async (response) =>{
            console.log(response);
            await adminService.register(user).then(()=>toast.success("Registered Successfully")).catch((error)=>console.log(error));
        }).catch((error)=>console.log(error));
    }

    const maxSize = 1 * 1024 * 1024;
    const onDrop = useCallback((acceptedFiles : any,fileRejections:any)=>{
        console.log(fileRejections);
        console.log(acceptedFiles);
        if(fileRejections.length > 0){
            setImageURL(null);
            fileRejections.forEach((rejection:any)=>{
                rejection.errors.some((e:any) => {
                    if(e.code === "file-too-large")
                        setImageError("File limit Exceeds");
                    else if(e.code === "file-invalid-type")
                        setImageError(e.message);
                });
            });
        }
        else if(acceptedFiles.length > 0 && fileRejections.length <= 0){
            setImageError('');
            const imagePreview = Object.assign(acceptedFiles[0], {preview:URL.createObjectURL(acceptedFiles[0])});
            setImageURL(imagePreview);
            setImage(acceptedFiles[0]);
        }
    },[]);

    const {getRootProps,getInputProps} = useDropzone({
        onDrop,
        accept:{"image":['.jpeg','.png','.jpg']},
        maxSize
    });


    return (
        <div>
            <Row {...getRootProps()} className={styles.uploadBox}>
                <input {...getInputProps()}/>
                <p>Drag 'n' Drop some file here, or click to select</p>
            </Row>
            {
                imageURL !== null && <Row>
                <img src={imageURL.preview} width={50} height={50}/>
            </Row>
            }            
            <ValidationText>{imageError}</ValidationText>
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