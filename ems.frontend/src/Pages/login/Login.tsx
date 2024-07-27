
import { useState } from 'react';
import styles from './Login.module.css';
import { UserLogin } from '../../models/user/User';

import Row from "../../ReusableComponents/Row";
import Button from '../../ReusableComponents/Button';

const Login = () => {

    const[user,setUser] = useState<UserLogin>({
        email:"",
        password:""
    });


    return (
        <div className={styles.loginBackground}>
            <div>

            </div>
            <Row>
                <label>UserEmail</label>
                <input type="text" 
                    name="email"
                    placeholder='Enter your Email' 
                    value={user.email} 
                    onChange={(event)=>setUser({...user,email:event.target.value})}
                />
            </Row>
            <Row>
                <label>Password</label>
                <input type="password" 
                    name="password"
                    placeholder='Enter your Password' 
                    value={user.password} 
                    onChange={(event)=>setUser({...user,password:event.target.value})}
                />
            </Row>
            <div>
                <Button>Login</Button>
            </div>
            <Row>

            </Row>
        </div>
    );
};

export default Login;