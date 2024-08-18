/* eslint-disable @typescript-eslint/no-explicit-any */
import axios, { AxiosError } from "axios";
import { toast } from "sonner";


class GlobalInterceptor{

    public async init(){
        axios.interceptors.request.use((request)=>{
            request.headers["Accept"] =  "text/plain";
            const user = JSON.parse(sessionStorage.getItem("user") || '');
            request.headers.Authorization = `Bearer ${user.token}`;
            console.log(request);
            return request;
        });

        axios.interceptors.response.use((response)=>{
            console.log(response);
            return response;
        },async (error:AxiosError)=>{
            console.log(error);
            await this.handleResponseError(error);
        })
    }

    private handleResponseError = async (error:AxiosError) : Promise<any> => {
        const errorMessage:any = error.response?.data;
        // if(error.response?.status === HttpStatusCodes.UnAuthorized)
        //     toast.error(errorMessage);
        // else if(error.response?.status === HttpStatusCodes.InternalServerError)
        //     toast.error(errorMessage)
        toast.error(errorMessage.Message);
        return Promise.reject(error);
    }

}

export default new GlobalInterceptor();