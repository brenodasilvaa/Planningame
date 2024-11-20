'use-client'
import React, { useEffect, useState } from "react";
import BotaoDeEscolha from "../../app/components/botaoDeEscolha";
import JogadoresMesa from "../../../src/app/jogadores-mesa";
import { useRouter } from "next/router";
import RootLayout from "../../app/layout";
import NovoUsuario from "../../app/novo-usuario";
import Resultado from "../../app/components/resultado";

export default function Home() {
  const router = useRouter();
  const [rodadaId, setPartida] = useState("");
  const [usuarioExiste, setUsuario] = useState(false);
  const [refresh, setRefresh] = useState(0);

  const triggerRefresh = () => {
    setRefresh((prev) => prev + 1);
  };

  useEffect(() => {
    if (!router.isReady || !router.query.id) return; // Ensure router is ready and id is available

    const fetchData = async () => {
      try {

        const cookies = document.cookie;
        if (cookies.includes("PlanningGame")) {
          setUsuario(true);
        }

        const response = await fetch(
          `https://localhost:44303/api/partida/rodadaativa/${router.query.id}`
        );

        const result = await response.json();
        setPartida(result.rodadaId);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, [router.isReady, router.query.id]); // Dependency array includes router.isReady and router.query.id

  if (!rodadaId) {
    return <p>Loading...</p>; // Optionally show a loading state
  }

  if(!usuarioExiste){
    return(<NovoUsuario partidaId={router.query.id}></NovoUsuario>);
  }

  return (
    <RootLayout>
      <Resultado refresh={refresh} rodadaId={rodadaId}></Resultado>
      <div className="center-container">
       <div className="center-div">
          <JogadoresMesa rodadaId={rodadaId} refreshTrigger={refresh} triggerRefresh={triggerRefresh} />
       </div>
       <BotaoDeEscolha triggerRefresh={triggerRefresh}></BotaoDeEscolha>
      </div>
    </RootLayout>
  );
}
