import { Button } from "@mui/material";
import SendIcon from '@mui/icons-material/Send';
import React from "react";

const BotaoConvite = ({triggerLinkCopied}) => {
    
    const handleClick = async () => {
        navigator.clipboard.writeText(location.href);
        triggerLinkCopied();
    };
    
    return (
      
         <Button   variant="contained" endIcon={<SendIcon />} 
            sx={{position: "fixed",
            top: "5vh",
            right: "5vw"}} 
            onClick={handleClick}>
                Convidar jogadores
         </Button>
    );
  };
  
  export default BotaoConvite;