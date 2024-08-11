import { AdminRightPanelActive } from "../../../utils/enums";
import styles from './AdminRightPanel.module.css';

interface AdminRightPanelProps{
    activeTab:string
}

const AdminRightPanel = ({activeTab}:AdminRightPanelProps) => {

    return (
        <div className={styles.rightPanelContainer}>
            {
                activeTab === AdminRightPanelActive.Home.toString() && <></>
            }
        </div>
    );
};

export default AdminRightPanel;