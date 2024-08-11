import { Stack } from "react-bootstrap";
import { IconContext } from "react-icons";
import { FiHome } from "react-icons/fi";
import { PiCurrencyInrBold } from "react-icons/pi";
import styles from './SideBar.module.css';

const SideBar = () => {
    return (
        <Stack className={styles.sideBarContainer}>
            <div className={styles.sideBarItem}>
                <IconContext.Provider value={{size:"40px"}}>
                    <FiHome />
                </IconContext.Provider>
                <p className={styles.sideBarText}>Home</p>
            </div>

            <div className={styles.sideBarItem}>
                <IconContext.Provider value={{size:"40px"}}>
                    <PiCurrencyInrBold />
                </IconContext.Provider>
                <p className={styles.sideBarText}>Home</p>
            </div>

            <div className={styles.sideBarItem}>
                <IconContext.Provider value={{size:"40px"}}>
                    <FiHome />
                </IconContext.Provider>
                <p className={styles.sideBarText}>Home</p>
            </div>            
        </Stack>
    );
};

export default SideBar;