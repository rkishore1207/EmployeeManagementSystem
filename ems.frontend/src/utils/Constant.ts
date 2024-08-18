const Constant = {
    StyledComponentTypes:{
        Vertical:"vertical",
        Horizontal:"horizontal",
        Primary:"primary",
        Success:"success",
        Danger:"danger",
        buttonDisable:"buttonDisable"
    },
    apiUrls:{
        BASE_URL:"https://localhost:7098/api",
        login:"/user/userLogin",
        register:"/user/userRegister",
        uploadImage:"/user/uploadImage",
        admin:{
            GetEmployees:"",
            GetUnApprovedEmployees:"/admin/unApprovedEmployees"
        }
    },
    admin:{
        approvedEmployee:"approvedemployee",
        unApprovedEmployee:"unapprovedemployee"
    }
}

export default Constant;