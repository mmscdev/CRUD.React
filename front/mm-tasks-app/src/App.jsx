import "./App.css";
import Atividade from "./pages/atividades/Atividade";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Cliente from './pages/clientes/Cliente';
import Dashboard from "./pages/dashboard/dashboard";
import ClienteForm from './pages/clientes/ClienteForm';
import PageNotFound from './pages/home/PageNotFound';

export default function App() {
  return (
      <Routes>
        <Route path="/" Component={Dashboard} />
        <Route path="/atividade/lista" Component={Atividade} />
        <Route path="/cliente/lista" Component={Cliente} />
        <Route path="/cliente/detalhe/:id?" Component={ClienteForm} />
        <Route path="/home" Component={Home} />
        <Route path='*' Component={PageNotFound} />
      </Routes>
  );
}
const Home = () => {
  return(<div><h1>HOME</h1></div>);
};

