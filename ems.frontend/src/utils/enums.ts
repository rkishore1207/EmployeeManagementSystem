export enum HttpStatusCodes{
    UnAuthorized = 401,
    InternalServerError = 500,
    NotFound = 404,
    Forbidden = 403
}

export enum CustomException{
    IncorrectPassword = 1002,
    DuplicateUser = 1001,
    NoUsersRegistered = 1003,
    InValidEmail = 1004
}

export enum AdminRightPanelActive{
    Home,
    Finance,
    Summary
}