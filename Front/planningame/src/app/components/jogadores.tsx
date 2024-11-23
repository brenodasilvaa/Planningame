import React from "react";
import Jogador from "./jogador";

const JogadoresCirculo = ({rodada}) => {

    const radius = 180;

    return <>
        {rodada.jogadores.map((jogador, index) => {
        const angle = (index / rodada.numeroJogadores) * 2 * Math.PI;
        const x = Math.cos(angle) * radius;
        const y = Math.sin(angle) * radius;

        return <Jogador key={index} jogador={jogador} brindou={rodada.brindou} index={index} x={x} y={y}></Jogador>
      })}
    </>
}

export default JogadoresCirculo;