import Logo from "../../ReusableComponents/Logo/Logo";
import Row from "../../ReusableComponents/Row";
import Constant from "../../utils/Constant";
import styles from './Admin.module.css';

const AdminLayout = () => {
    return (
        <Row type="vertical" className={styles.adminBody}>
            <Row className={styles.adminHeader}>
                <Logo logoHeight="30%" logoWidth="70%"/>
            </Row>
            <Row className={styles.adminContent}>
                <Row type={Constant.StyledComponentTypes.Vertical}>

                </Row>
                <Row type={Constant.StyledComponentTypes.Vertical}>

                </Row>
            </Row>
        </Row>
    );
};

export default AdminLayout;