import { Stack } from "react-bootstrap";
import { AdminEmployeeItem } from "../../../models/user/User";
import Constant from "../../../utils/Constant";
import { BsCheckCircle } from "react-icons/bs";
import { IconContext } from "react-icons";
import { MdOutlineCancel } from "react-icons/md";

interface EmployeeItemProps{
    type:string,
    employee:AdminEmployeeItem
}

const EmployeeItem = ({type,employee}:EmployeeItemProps) => {
    console.log(type);
    return (
        <Stack direction="horizontal">
            <img src={employee.image} alt={`${employee.firstName}, ${employee.lastName} profile`}/>
            <p>{employee.lastName}, {employee.firstName}</p>
            <p>{employee.dateOfJoin.toLocaleDateString()}</p>
            <>
                {
                    type === Constant.admin.approvedEmployee ?
                    <>
                        <IconContext.Provider value={{color:"green"}}>
                            <BsCheckCircle />
                        </IconContext.Provider>

                        <IconContext.Provider value={{color:"red"}}>
                            <MdOutlineCancel />
                        </IconContext.Provider>
                    </> : <>
                        <p>{employee.manager}</p>
                        <p>{employee.designation}</p>
                    </>
                }
            </>
        </Stack>
    );
};

export default EmployeeItem;