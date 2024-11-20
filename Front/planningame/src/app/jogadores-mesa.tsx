"use client"

import React, { useState, useEffect } from "react";
import Table from "./table";
import Image from "next/image";
import { createTheme } from "@mui/material";
import { Rodada } from "./classes/rodada";

  const theme = createTheme({
    palette: {
      primary: {
        main: "#ffffff"
      },
      secondary:{
        main: "#fff55a"
      }
    },
  });

const JogadoresMesa = ({rodadaId, refreshTrigger, triggerRefresh}) => {
  const [rodada, setRodada] = useState<Rodada>(new Rodada);
  const [refreshBrinde, setRefresh] = useState(0);

  const triggerRefreshBrinde = () => {
    setRefresh((prev) => prev + 1);
  };

const fetchRodadaInfo = async () => {
    try {
      const response = await fetch(`https://localhost:44303/api/Rodada/Info/${rodadaId}`);
      const data = await response.json();
      setRodada(data); 
    } catch (error) {
      console.error("Failed to fetch icon count:", error);
    }
  };
  
  useEffect(() => {
      fetchRodadaInfo();
  }, [refreshTrigger, rodadaId, refreshBrinde]);

  const radius = 180;

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100vh",
        position: "relative",
      }}
    >
      <Table rodada={rodada} rodadaId={rodadaId} refreshBrinde={triggerRefreshBrinde} triggerRefresh={triggerRefresh}></Table>
      {rodada.jogadores.map((jogador, index) => {
        const angle = (index / rodada.numeroJogadores) * 2 * Math.PI;
        const x = Math.cos(angle) * radius;
        const y = Math.sin(angle) * radius;

        return (
          <div
            key={index}
            style={{
              position: "absolute",
              top: `calc(50% + ${y}px)`,
              left: `calc(50% + ${x}px)`,
              width: "50px",
              height: "50px",
              borderRadius: "50%",
              display: "flex",
              justifyContent: "center",
              flexDirection:"column",
              alignItems: "center",
              transform: "translate(-50%, -50%)",
            }}
          >
             <label htmlFor="oii">{jogador.nome}</label>
             <Image
              src={jogador.votou ? "/assets/cerveja-com-espuma-cheio.png" : "/assets/cerveja-com-espuma-vazio.png"}
              width={120}
              height={120}
              alt={`${index + 1}`}
              style={{
                objectFit: "cover",
              }}
            />
          </div>
        );
      })}
    </div>
  );
};

export default JogadoresMesa;
