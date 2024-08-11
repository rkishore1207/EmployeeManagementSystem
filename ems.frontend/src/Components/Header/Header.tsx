import { Stack } from "react-bootstrap";
import Logo from "../../ReusableComponents/Logo/Logo";
import { FaUser } from "react-icons/fa6";
import styles from './Header.module.css';
import { IconContext } from "react-icons";

const Header = () => {
    return (
        <Stack direction="horizontal" className={styles.headerContainer} >
            <Logo/>
            <div className={styles.userIcon}>
                <IconContext.Provider value={{size:"40px"}}>
                    <FaUser />
                </IconContext.Provider>
            </div>
        </Stack>
    );
};

export default Header;