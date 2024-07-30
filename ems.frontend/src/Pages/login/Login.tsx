/* eslint-disable @typescript-eslint/no-explicit-any */

import { useEffect, useRef, useState } from 'react';
import styles from './Login.module.css';
import { UserLogin } from '../../models/user/User';
import Row from "../../ReusableComponents/Row";
import Button from '../../ReusableComponents/Button';
import { Link } from 'react-router-dom';
import { IconContext } from 'react-icons';
import { IoEyeOffOutline, IoEyeOutline } from 'react-icons/io5';
import ValidationText from '../../ReusableComponents/ValidationText';
import Constant from '../../utils/Constant';

const Login = () => {

    const[user,setUser] = useState<UserLogin>({
        email:"",
        password:""
    });
    const userEmailRef = useRef<any>(null);
    const [showPassword,setShowPassword] = useState<boolean>(false);
    const [emailError,setEmailError] = useState<string>('');
    const [passwordError,setPasswordError] = useState<string>('');

    useEffect(()=>{
        if(userEmailRef.current)
            userEmailRef.current.focus();
    },[]);

    const handleLogin = () => {
        console.log("Login");
    }

    const handleKeyDown = (event:any) => {
        if(event.key == "Enter")
            handleLogin();
    }

    const validateEmail = (email:string) => {
        const emailRegex:any = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    const handleEmailValidation = (email:string) => {
        setUser({...user,email:email});
        if(email === '')
            setEmailError('Email Cannot be Empty');
        else if(!validateEmail(email))
            setEmailError('Invalid Email address');
        else 
            setEmailError('');
    }

    const handlePasswordChange = (password:string) => {
        setUser({...user,password:password});
        if(password === '')
            setPasswordError('Password Cannot be Empty');
        else if(password.length < 8)
            setPasswordError('Minimum 8 characters needed');
        else
            setPasswordError('');
    }


    return (
        <Row type='vertical' className={styles.loginBackground}>
            <div className={styles.userImage}>
                <img src='icons/user_login.png' alt='UserLogin'/>
            </div>
            <Row type='vertical' className={styles.inputStyle}>
                <label htmlFor='email'>User Email</label>
                <input type="text"
                    id='email'
                    ref={userEmailRef}
                    className={styles.loginInputField}
                    name="email"
                    maxLength={20}
                    placeholder='Enter your Email' 
                    value={user.email} 
                    onChange={(event)=>handleEmailValidation(event.target.value)}
                    />
                {
                    emailError && <ValidationText>{emailError}</ValidationText>
                }
            </Row>
            <Row type='vertical' className={styles.inputStyle}>
                <label htmlFor='password'>Password</label>
                <input type={showPassword ? "text" : "password"}
                    name="password"
                    className={styles.loginInputField}
                    id='password'
                    maxLength={15}
                    placeholder='Enter your Password' 
                    value={user.password}
                    onChange={(event)=>handlePasswordChange(event.target.value)}
                    onKeyDown={handleKeyDown}
                    />
                <span className={styles.passwordShowIcon} onClick={()=>setShowPassword(!showPassword)}>
                    {showPassword ? <IconContext.Provider value={{color:"white"}}> <IoEyeOffOutline /> </IconContext.Provider>  : 
                    <IconContext.Provider value={{color:"white"}}> <IoEyeOutline /> </IconContext.Provider> }
                </span>
                <ValidationText>{passwordError}</ValidationText>
            </Row>
            <Row>
                {
                    emailError === '' && passwordError === '' && user.email !== '' && user.password !== '' ?
                    <Button variation={Constant.StyledComponentTypes.Primary}>Login</Button> :
                    <Button variation={Constant.StyledComponentTypes.buttonDisable}>Login</Button>
                }
            </Row>
            <Row className={styles.loginLinksContainer}>
                <Link to="/register" className={styles.loginLinks}>Register</Link>
                <Link to="" className={styles.loginLinks}>Forgot Password</Link>
            </Row>
        </Row>
    );
};

export default Login;