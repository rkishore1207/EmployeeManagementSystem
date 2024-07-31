import './App.css'
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Login from './Pages/login/Login';
import Register from './Pages/register/Register';
import GlobalStyle from './utils/GlobalStyles';
import { Toaster } from 'sonner';
import {PageRoute} from './utils/Routes';

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
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App;
