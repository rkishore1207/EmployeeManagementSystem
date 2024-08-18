import { Outlet } from 'react-router-dom';
import styles from './AdminRightPanel.module.css';



const AdminRightPanel = () => {

    return (
        <div className={styles.rightPanelContainer}>
            <Outlet/>
        </div>
    );
};

export default AdminRightPanel;