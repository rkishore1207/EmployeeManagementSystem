/* eslint-disable @typescript-eslint/no-explicit-any */

import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";

interface AuthenticationProps{
    children:any
}

const Authentication = ({children}:AuthenticationProps) => {

    const [isAuthenticate,setIsAuthenticate] = useState<boolean>(false);

    useEffect(()=>{
        const user:any = sessionStorage.getItem('user');
        console.log(user);
        if(user?.token)
            setIsAuthenticate(true);
        else
            setIsAuthenticate(false);
    },[]);

    return (
        <>
            {isAuthenticate ? children : <Navigate to="/login"/>}
        </>
    );
};

export default Authentication;