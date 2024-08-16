
import { useQuery } from "@tanstack/react-query";
import adminService from '../../../services/adminService';
import { User } from "../../../models/user/User";
import Loader from "../../../Components/Spinner/Loader";

const AdminHome = () => {
    console.log("adminHome");
    const handleEmployees = async () =>{
        console.log("employees");
        await adminService.getUnApprovedEmployees().then((response:User) => 
            console.log(response)
        ).catch(()=>{});
    };

    const {isLoading, data:users, error} = useQuery({
        queryKey:['users'],
        queryFn:handleEmployees
    });

    if(isLoading) return(<Loader/>);

    if(error) return(<></>);

    return (
        <div>
            
        </div>
    );
};

export default AdminHome;