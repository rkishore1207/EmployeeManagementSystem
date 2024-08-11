import { Container } from "react-bootstrap";
import Header from "../../../Components/Header/Header";
import SideBar from "../../../Components/SideBar/SideBar";
import AdminRightPanel from "../AdminRightPanel/AdminRightPanel";
import styles from './Admin.module.css';

const AdminLayout = () => {
    return (        
        <Container className="container-style" fluid>
            <Header/>
            <div className={styles.adminContentContainer}>
                <SideBar/>
                <AdminRightPanel activeTab=""/>
            </div>
        </Container>
    );
};

export default AdminLayout;