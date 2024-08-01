
import Constant from "../utils/Constant";
import { UserLogin, UserRegister } from "../models/user/User";
import axios from "axios";

class adminService{

    async getEmployees(){
        const employees = await axios.get(`${Constant.apiUrls.BASE_URL}${Constant.apiUrls.admin.GetEmployees}`);
        return employees.data;
    }

    async login(loginRequest:UserLogin){
        const response = await axios.post(`${Constant.apiUrls.BASE_URL}${Constant.apiUrls.login}`,loginRequest);
        return response.data;
    }

    async register(registerRequest:UserRegister){
        const response = await axios.post(`${Constant.apiUrls.BASE_URL}${Constant.apiUrls.register}`,registerRequest);
        return response.data;
    }

    async uploadImage(formData:FormData){
        const response = await axios.post(`${Constant.apiUrls.BASE_URL}${Constant.apiUrls.uploadImage}`,formData);
        return response.data;
    }
}

export default new adminService();