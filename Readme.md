# Employee Management System

## Packages
### Backend
* Microsoft.Data.SqlClient
* Microsoft.Extensions.Configuration
* Microsoft.Extensions.Configuration.Binder
* Microsoft.Extensions.DependencyInjection
* AutoMapper
* Microsoft.IdentityModels.Tokens.Jwt
* Newtonsoft.Json
* Azure.Storage.Blobs
* Microsoft.AspNetCore.Http

### Frontend
* react-router-dom
* react-icons
* axios
* sonner (toaster)
* react-dropzone


## WorkBook Open XML
![OpenXML](https://github.com/user-attachments/assets/09c98e8a-2dde-4fb4-aa14-c124d41beff6)

> While disposing object we need to call `Garbage Collector` and execute **SupressFinalize** with the current **object**.

``` C#
    //Regular way
    if(document is not null)
        document.Dispose();

    //Null Propagation way
    document?.Dispose();
```