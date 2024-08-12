import { Stack } from "react-bootstrap";
import { IconContext } from "react-icons";
import { FiHome } from "react-icons/fi";
import { PiCurrencyInrBold } from "react-icons/pi";
import styles from './SideBar.module.css';
import { useState } from "react";

const SideBar = () => {

    const [isShowText,setIsShowText] = useState<boolean>(false);

    return (
        <Stack className={styles.sideBarContainer} 
            onMouseEnter={()=>setIsShowText(true)}
            onMouseLeave={()=>setIsShowText(false)}
            >
            <div className={styles.sideBarItem}>
                <IconContext.Provider value={{size:"40px"}}>
                    <FiHome />
                </IconContext.Provider>
                <p style={{display:isShowText ? "inline" : "none",fontSize:'1.2rem'}}>Home</p>
            </div>

            <div className={styles.sideBarItem}>
                <IconContext.Provider value={{size:"40px"}}>
                    <PiCurrencyInrBold />
                </IconContext.Provider>
                <p style={{display:isShowText ? "inline" : "none",fontSize:'1.2rem'}}>Finance</p>
            </div>

            <div className={styles.sideBarItem}>
                <IconContext.Provider value={{size:"40px"}}>
                    <FiHome />
                </IconContext.Provider>
                <p style={{display:isShowText ? "inline" : "none",fontSize:'1.2rem'}}>Finance</p>
            </div>            
        </Stack>
    );
};

export default SideBar;