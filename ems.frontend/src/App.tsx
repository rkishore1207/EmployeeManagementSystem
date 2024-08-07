import './App.css'
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import GlobalStyle from './utils/GlobalStyles';
import { Toaster } from 'sonner';
import {PageRoute} from './utils/Routes';
import { lazy } from 'react';

const Login = lazy(()=>import('./Pages/login/Login'));
const Register = lazy(()=>import('./Pages/register/Register'));
const AdminLayout = lazy(()=>import('./Pages/admin/AdminLayout'));


const App = () => {

  return (
    <>
      <GlobalStyle/>
      <Toaster position='top-right' richColors duration={1000}/>
      <BrowserRouter>
        <Routes>
          <Route index element={<Navigate replace to={PageRoute.Login}/>}/>
          <Route path={PageRoute.Login} element={<Login/>}/>
          <Route path={PageRoute.Register} element={<Register/>}/>
          <Route path={PageRoute.Admin} element={<AdminLayout/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App;
