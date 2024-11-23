import React, { useEffect, useState } from "react";
import { Paper } from "@mui/material";
import { Rodada } from "../classes/rodada";

const Resultado = ({refresh, rodadaId}) => {
    const [rodada, setRodada] = useState<Rodada>(new Rodada());
    const [mediaVoto, setRefresh] = useState(0);

    const fetchRodadaInfo = async () => {
        try {
          const response = await fetch(`https://localhost:44303/api/Rodada/Info/${rodadaId}`);
          const data = await response.json();
          setRodada(data); 
        } catch (error) {
          console.error("Failed to fetch icon count:", error);
        }

        if (rodada.brindou){
            const response = await fetch(`https://localhost:44303/api/Rodada/CalculoVoto/${rodadaId}`);
            const data = await response.json();
            setRefresh(data.voto);
        }
      };
      
      useEffect(() => {
          fetchRodadaInfo();
      }, [refresh]);

      if (!rodada.brindou)
        return;

        return (
            <Paper sx={{position: "fixed",
                top: "5vh",
                left: "4vw",
                width: "200px",
                height: "100px",
                backgroundColor: "#5f708d",
                color: "white",
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                boxShadow: "0 4px 8px rgba(0, 0, 0, 0.2)",
                borderRadius: "4px",
                padding: "10px"
    
            }} elevation={1}>
                <div style={{display:"flex", flexDirection:"column", alignItems:"center", justifyContent:"space-between"}}>
                <p>Média</p>
                <p style={{fontSize:"40px"}}>{mediaVoto}</p>
                </div>
                
            </Paper>
        );
    }

  export default Resultado;