/* eslint-disable @typescript-eslint/no-explicit-any */

import { Image } from "react-bootstrap";
import styles from './Logo.module.css';

const Logo = () => {
    return (
        <div className={styles.logoContainer}>
            <Image fluid src="images/logo.png" alt="EMS-Logo" width={200}/>
        </div>
    );
};

export default Logo;