import React from "react";
import Image from "next/image";
import '../styles/jogador.css';

const Jogador = ({jogador, brindou, index, x, y}) => {

    if (!brindou){
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
        }

    return <>
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
        <label htmlFor="oii">{jogador.votou ? `${jogador.voto}` : ""}</label>
        <Image
            src={jogador.votou ? "/assets/amendoim.png" : "/assets/interrogacao.png"}
            width={120}
            height={120}
            alt={`${index + 1}`}
            style={{
            objectFit: "cover",
            }}
        />
        </div>
    </>
}

export default Jogador;