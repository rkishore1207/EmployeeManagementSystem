import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import GlobalInterceptor from './utils/GlobalInterceptor.ts'
import axios from 'axios';

await GlobalInterceptor.init();

ReactDOM.createRoot(document.getElementById('root')!).render(
    <App />
)

export default axios;
