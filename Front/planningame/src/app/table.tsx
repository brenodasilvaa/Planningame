import React, { useState } from 'react';
import './table-div.css';
import IconButton from "@mui/material/IconButton";
import RefreshIcon from "@mui/icons-material/Refresh";
import { createTheme, ThemeProvider } from '@mui/material';

const theme = createTheme({
  palette: {
    primary: {
      main: "#e9b261"
    }
  },
});

const Table = ({rodada, rodadaId, refreshBrinde, triggerRefresh}) => {
  
  const handleClick = async () => {

    await fetch(`https://localhost:44303/api/rodada/brindar/${rodadaId}`, {
      method: "PUT"
    });
    
    triggerRefresh();
  };

  const novaRodada = async () => {
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
      <ThemeProvider theme={theme}>
      <IconButton
      color="primary"
      onClick={() => 
        {
          novaRodada(); 
          refreshBrinde();
        }}
      style={{
        backgroundColor: "#f0f0f0",
        padding: "10px",
        borderRadius: "50%",
      }}
    >
      <RefreshIcon />
    </IconButton>
      </ThemeProvider>
    
    </div>
  );


};

export default Table;