import { useState, useEffect } from "react";
const atividadeInicial = {
  id: 0,
  titulo: "",
  prioridade: 0,
  descricao: "",
};

export default function AtividadeForm(props) {
  const [atividade, setAtividade] = useState(atividadeAtual());

  useEffect(() => {
    if (props.ativSelecionada.id !== 0) {
      setAtividade(props.ativSelecionada);
    }
  }, [props.ativSelecionada]);

  const handleCancelar = (e) => {
    e.preventDefault();

    props.cancelarAtividade();

    setAtividade(atividadeInicial);
  };
  const inputTextHandler = (e) => {
    const { name, value } = e.target;
    console.log(value);
    setAtividade({ ...atividade, [name]: value });
  };

  function atividadeAtual() {
    if (props.ativSelecionada.id !== 0) {
      return props.ativSelecionada;
    } else {
      return atividadeInicial;
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('handleSubmit');
    if (props.ativSelecionada.id !== 0) {
      props.atualizarAtividade(atividade);
    } else {
      props.addAtividade(atividade);
    }
    setAtividade(atividadeInicial);
  }

  return (
    <>
      <h1>
        {atividade.id !== 0 && atividade.id !== undefined
          ? "Atividade" + atividade.id
          : "Atividades"}
      </h1>
      <form className="row g-3" onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Título</label>
          <input
            id="titulo"
            name="titulo"
            type="text"
            className="form-control"
            onChange={inputTextHandler}
            value={atividade.titulo}
          />
        </div>
        <div className="col-md-6">
          <label for="inputState" className="form-label">
            Prioridade
          </label>
          <select
            name="prioridade"
            id="prioridade"
            className="form-select"
            value={atividade.prioridade}
            onChange={inputTextHandler}
          >
            <option selected>Selecionar...</option>
            <option value="1">Baixa</option>
            <option value="2">Normal</option>
            <option value="3">Alta</option>
          </select>
        </div>
        <div className="col-md-12">
          <label className="form-label">Descrição</label>
          <textarea
            id="descricao"
            name="descricao"
            type="text"
            className="form-control"
            onChange={inputTextHandler}
            value={atividade.descricao}
          />
          <hr></hr>
        </div>
        <div className="col-12 mt-0">
          {
            props.atividades && props.atividades.length === 0 ?
             (
            <button className="btn btn-outline-secondary" type="submit">
              <i className="fas fa-plus me-2"></i>
              Atividade
            </button>
          ) : (
            <>
              <button className="btn btn-outline-secondary me-2" type="submit">
                <i className="fas fa-plus me-2"></i>
                Salvar
              </button>
              <button
                className="btn btn-outline-secondary"
                onClick={handleCancelar}
              >
                +Cancelar
              </button>
            </>
          )}
        </div>
      </form>
    </>
  );
}
