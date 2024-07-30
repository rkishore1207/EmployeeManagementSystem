import axios from "axios";
import Constant from "../utils/Constant";
import { UserLogin, UserRegister } from "../models/user/User";

const headers = {
    "accept": "text/plain",
    "Authorization": `Bearer ${sessionStorage.getItem("token")}`
}

class adminService{
    http = axios.create({
        baseURL:Constant.apiUrls.BASR_URL
    });

    async getEmployees(){
        const employees = await this.http.get(Constant.apiUrls.GetEmployees);
        return employees.data;
    }

    async login(loginRequest:UserLogin){
        const response = await this.http.post(Constant.apiUrls.login,loginRequest);
        return response.data;
    }

    async register(registerRequest:UserRegister){
        const response = await this.http.post(Constant.apiUrls.register,registerRequest);
        return response.data;
    }
}

export default new adminService();