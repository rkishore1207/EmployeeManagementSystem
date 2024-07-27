import './App.css'
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Login from './Pages/login/Login';
import Register from './Pages/register/Register';
import GlobalStyle from './utils/GlobalStyles';

const App = () => {

  return (
    <>
      <GlobalStyle/>
      <BrowserRouter>
        <Routes>
          <Route index element={<Navigate replace to="login"/>}/>
          <Route path='login' element={<Login/>}/>
          <Route path='register' element={<Register/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App;
