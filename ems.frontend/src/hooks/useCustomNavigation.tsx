import { useNavigate } from "react-router-dom";

const useCustomNavigation = (route:string) => {

    const navigate = useNavigate();

    return () => navigate(route);
};

export default useCustomNavigation;