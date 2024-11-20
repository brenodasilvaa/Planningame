import React, { useEffect, useState } from 'react';
import './footer-style.css';
import Cookies from "js-cookie";
import { useRouter } from 'next/router';

const BotaoDeEscolha = ({ triggerRefresh }) => {
  const [activeButton, setActiveButton] = useState(null);
  const router = useRouter();

  const handleClick = async (buttonId) => {
    setActiveButton(buttonId);
    const cookieValue = Cookies.get("PlanningGame");

    if (cookieValue) {
      const parsedCookie = JSON.parse(cookieValue);

        if (!router.isReady || !router.query.id) return;

        try {
            const responseRodadaAtiva = await fetch(
              `https://localhost:44303/api/partida/rodadaativa/${parsedCookie.partidaId}`
            );
    
            const result = await responseRodadaAtiva.json();

            const response = await fetch("https://localhost:44303/api/voto", {
              method: "POST",
              headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify({valor: buttonId + 1, jogadorId: parsedCookie.jogadorId, rodadaId: result.rodadaId }),
            });
           
          } catch (error) {
            console.error("Error fetching data:", error);
          }
    }
  };
  
  return (
    <div className="footer-fixed">
      {[...Array(10)].map((_, index) => (
        <button className='footer-item' onClick={async () => 
          {
            await handleClick(index);
            triggerRefresh();
          }} 
        style={{
          backgroundColor: activeButton === index ? "#5f708d" : "#aaa6a6",
          height: activeButton === index ? "11vh" : "11vh",
          transform: activeButton === index ? "translateY(-10px)" : "none"
        }}
        key={index}>
          {index + 1}
        </button>
      ))}
    </div>
  );
};

export default BotaoDeEscolha;