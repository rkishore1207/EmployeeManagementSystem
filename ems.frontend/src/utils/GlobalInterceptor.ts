/* eslint-disable @typescript-eslint/no-explicit-any */
import axios, { AxiosError } from "axios";
import { HttpStatusCodes } from "./enums";


class GlobalInterceptor{

    public async init(){
        axios.interceptors.request.use((request)=>{
            request.headers["Accept"] =  "text/plain";
            request.headers.Authorization = `Bearer ${sessionStorage.getItem("token")}`;
            console.log(request);
            return request;
        });

        axios.interceptors.response.use((response)=>{
            console.log(response);
            return response;
        },async (error:AxiosError)=>{
            await this.handleResponseError(error);
        })
    }

    private handleResponseError = async (error:AxiosError) : Promise<any> => {
        if(error.response?.status === HttpStatusCodes.UnAuthorized)
        {
            return Promise.reject(error);
        }
        return Promise.reject(error);
    }

}

export default new GlobalInterceptor();