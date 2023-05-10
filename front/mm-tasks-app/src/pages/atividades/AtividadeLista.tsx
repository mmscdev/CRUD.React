import React from 'react';
import AtividadeItem from './AtividadeItem';
import { AtividadeListaProps } from './../../model/atividadesProps';

const AtividadeLista: React.FC<AtividadeListaProps> = ({
        atividades,
        obterAtividade,
        handleConfirmModal
    }: AtividadeListaProps
    ) => {
    return (
        <div className='mt-3'>
            {atividades.map((ativ) => (
                <AtividadeItem
                    key={ativ.id}
                    ativ={ativ}
                    obterAtividade={obterAtividade}
                    handleConfirmModal={handleConfirmModal}
                />
            ))}
        </div>
    );
}

export default AtividadeLista;