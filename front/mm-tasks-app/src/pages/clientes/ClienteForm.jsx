import React from "react";
import Title from "./../../components/TitlePage";
import { Button } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";

export default function ClienteForm() {
  let navigate = useNavigate();
  let { id } = useParams();
  return (
    <>
      <Title title={"Cliente Detalhes " + (id !== undefined ? id : "")}>
        <Button
          variant="outline-secondary"
          onClick={() => navigate("/cliente/lista")}
        >
          <i className="fas fa-arrow-left me-2"></i>
          Voltar
        </Button>
      </Title>
      <div></div>
    </>
  );
}
