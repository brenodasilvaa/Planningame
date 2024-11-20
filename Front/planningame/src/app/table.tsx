import React from 'react';
import './table-div.css';

const Table = ({todosVotaram}) => {
  return (
    <div className="wood-div">
       <button disabled={!todosVotaram} className='buttonView'>Brindar!</button>
    </div>
  );
};

export default Table;