import React from 'react';
import './styles/table-div.css';
import NovaRodada from './components/novaRodada';

const Table = ({rodada, rodadaId, refreshBrinde, triggerRefresh}) => {
  
  const handleClick = async () => {

    await fetch(`http://192.168.0.67:44303/api/rodada/brindar/${rodadaId}`, {
      method: "PUT"
    });
    
    triggerRefresh();
  };

  if (!rodada.brindou){
    return (
      <div className="wood-div">
         <button 
         onClick={async () => 
          {
            await handleClick();
            refreshBrinde()
          }} disabled={!rodada.todosVotaram} className='buttonView'>Brindar!</button>
      </div>
    );
  }

  return (
    <div className="wood-div">
      <NovaRodada></NovaRodada>
    </div>
  );
};

export default Table;