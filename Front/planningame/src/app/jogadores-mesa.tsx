"use client"

import React, { useState, useEffect } from "react";
import Table from "./table";
import { Rodada } from "./classes/rodada";
import JogadoresCirculo from "./components/jogadores";

const JogadoresMesa = ({rodadaId, refreshTrigger, triggerRefresh}) => {
  const [rodada, setRodada] = useState<Rodada>(new Rodada);
  const [refreshBrinde, setRefresh] = useState(0);

  const triggerRefreshBrinde = () => {
    debugger
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
      <JogadoresCirculo rodada={rodada}></JogadoresCirculo>
    </div>
  );
};

export default JogadoresMesa;
