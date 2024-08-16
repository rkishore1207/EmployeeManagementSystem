export interface UserLogin{
    email:string,
    password:string
}

export interface User{
    uid?:string,
    managerUID?:string,
    firstName:string,
    lastName:string,
    employeeID:string,
    password:string,
    confirmPassword:string,
    address:string,
    phoneNumber:string,
    email?:string,
    userRole?:string,
    managerName?:string,
    designation?:string,
    isActive?:boolean,
    dateOfBirth:Date,
    dateOfJoin:Date,
    location:string,
    maritalStatus:string,
    gender:string,
    bloodGroup:string,
    emergencyNumber:string,
    about:string,
    school:string,
    college:string,
    previouCompany?:string,
    privilegeLeave?:number,
    wellnessLeave?:number,
    optionalLeave?:number,
    compOff?:number,
    lossOfPay?:number,
    earnedLeave?:number
}