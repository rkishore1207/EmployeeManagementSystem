import './App.css'
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import GlobalStyle from './utils/GlobalStyles';
import { Toaster } from 'sonner';
import {PageRoute} from './utils/Routes';
import { lazy, Suspense } from 'react';
import { QueryClientProvider, QueryClient } from '@tanstack/react-query';
import Loader from './Components/Spinner/Loader';

const Login = lazy(()=>import('./Pages/login/Login'));
const Register = lazy(()=>import('./Pages/register/Register'));
const AdminLayout = lazy(()=>import('./Pages/admin/AdminLayout/AdminLayout'));
const AdminHome = lazy(()=>import('./Pages/admin/AdminHome/AdminHome'));



const App = () => {

  const queryClient = new QueryClient();

  return (
    <>
      <QueryClientProvider client={queryClient}>
        <GlobalStyle/>
        <Toaster position='top-right' richColors duration={1000}/>
          <BrowserRouter>
            <Suspense fallback={<Loader/>}>
              <Routes>
                <Route index element={<Navigate replace to={PageRoute.Login}/>}/>
                <Route path={PageRoute.Login} element={<Login/>}/>
                <Route path={PageRoute.Register} element={<Register/>}/>
                <Route path={PageRoute.Admin} element={<AdminLayout/>}>
                  <Route path={PageRoute.AdminHome} element={<AdminHome/>}/>
                </Route>
              </Routes>
            </Suspense>
          </BrowserRouter>
      </QueryClientProvider>
    </>
  )
}

export default App;
