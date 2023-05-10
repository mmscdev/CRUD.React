import { useEffect, useState } from "react";
import "./App.css";
import AtividadeForm from "./pages/atividades/AtividadeForm";
import AtividadeLista from "./pages/atividades/AtividadeLista";
import api from "./api/atividade";
import { Button, Modal } from "react-bootstrap";
import Title from "./components/TitlePage";

function App() {
  const [atividades, setAtividades] = useState([]);
  const [atividade, setAtividade] = useState({ id: 0 });
  const [showAtividadeModal, setShowAtividadeModal] = useState(false);
  const [smShowConfirmModal, setsmShowConfirmModal] = useState(false);

  const handleAtividadeModal = () => setShowAtividadeModal(!showAtividadeModal);
  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const atividade = atividades.filter((atividade) => atividade.id === id);
      setAtividade(atividade[0]);
    } else {
      setAtividade({ id: 0 });
    }
    setsmShowConfirmModal(!smShowConfirmModal);
  };
  const obterTodas = async () => {
    const response = await api.get("atividade");
    return response.data;
  };

  useEffect(() => {
    const getAtividades = async () => {
      const todasAtividades = await obterTodas();
      if (todasAtividades) setAtividades(todasAtividades);
    };
    getAtividades();
  }, []);

  function editarAtividade(id) {
    const atividade = atividades.filter((atividade) => atividade.id === id);
    setAtividade(atividade[0]);
    handleAtividadeModal();
  }

  const deletarAtividade = async (id) => {
    if (await api.delete(`atividade/${id}`)) {
      const atividadesFiltradas = atividades.filter(
        (atividade) => atividade.id !== id
      );
      setAtividades([...atividadesFiltradas]);
    }
  };
  const addAtividade = async (ativ) => {
    handleAtividadeModal();
    const response = await api.post("atividade", ativ);
    setAtividades([...atividades, response.data]);
  };
  const atualizarAtividade = async (ativ) => {
    setAtividades(
      atividades.map((item) => (item.id === ativ.id ? ativ : item))
    );
    setAtividade({ id: 0 });
  };
  function cancelarAtividade(ativ) {
    setAtividade({ id: 0 });
    handleAtividadeModal();
  }
  const novaAtividade = () => {
    setAtividade({ id: 0 });
    handleAtividadeModal();
  };
  return (
    <>
      <Title title={"Atividade" + (atividade.id !== 0 ? atividade.id : "")}>
        <Button variant="outline-secondary" onClick={novaAtividade}>
          <i className="fas fa-plus"></i>
        </Button>
      </Title>
      <AtividadeLista
        atividades={atividades}
        editarAtividade={editarAtividade}
        handleConfirmModal={handleConfirmModal}
      />

      <Modal show={showAtividadeModal} onHide={handleAtividadeModal}>
        <Modal.Header closeButton>
          <Modal.Title>Atividade {atividade.id}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AtividadeForm
            addAtividade={addAtividade}
            atividades={atividades}
            ativSelecionada={atividade}
            atualizarAtividade={atualizarAtividade}
            cancelarAtividade={cancelarAtividade}
          />
        </Modal.Body>
      </Modal>

      <Modal size="sm" show={smShowConfirmModal} onHide={handleConfirmModal}>
        <Modal.Header closeButton>
          <Modal.Title>Excluindo atividade {atividade.id}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja excluir a Atividade {atividade.id} ?
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-between">
          <button
            className="btn btn-outline-success me-2"
            onClick={() => deletarAtividade(atividade.id)}
          >
            <i className="fas fa-check me-2"></i>
            Sim
          </button>
          <button
            className="btn btn-danger me-2"
            onClick={() => handleConfirmModal(0)}
          >
            <i className="fas fa-times me-2"></i>
            Não
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default App;
