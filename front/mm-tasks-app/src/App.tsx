import "./App.css";
import { Routes, Route } from "react-router-dom";
import Cliente from "./pages/clientes/Cliente";
import Dashboard from "./pages/dashboard/Dashboard";
import PageNotFound from "./pages/home/PageNotFound";
import ClienteForm from './pages/clientes/ClienteForm';
import React from "react";
import Atividade from "./pages/atividades/Atividade";

const App = () => {
  return (
    <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="/atividade/*" element={<Atividade />} />
      <Route path="/atividade/:id/cliente" element={<Cliente />} />
      <Route path="/cliente/*" element={<Cliente />} />
      <Route path="/cliente/:id/atividade" element={<Atividade />} />
      <Route path="/cliente/detalhe/" element={<ClienteForm />} />
      <Route path="/cliente/detalhe/:id" element={<ClienteForm />} />
      <Route element={<PageNotFound />} />
    </Routes>
  );
}

export default App;