import { Alert, Slide } from "@mui/material";
import React from "react";
import CheckIcon from '@mui/icons-material/Check';

const FeedbackAlerta = ({linkCopied}) => {
   
    if (linkCopied){
        return (
            <Slide 
                direction="right" in={linkCopied} mountOnEnter unmountOnExit>
                { <Alert  sx={{position: "fixed",
                bottom: "20vh",
                left: "4vw"}} icon={<CheckIcon fontSize="inherit" />} severity="success">
                Link copiado!
              </Alert>}
            </Slide>
        );
    }
  };
  
  export default FeedbackAlerta;