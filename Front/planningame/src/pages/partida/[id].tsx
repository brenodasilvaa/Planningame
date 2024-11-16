'use-client'
import React, { useEffect, useState } from "react";
import Footer from "../../../src/app/footer";
import JogadoresMesa from "../../../src/app/jogadores-mesa";
import { useRouter } from "next/router";

export default function Home() {
  const router = useRouter();
  const [rodadaId, setPartida] = useState("");

  useEffect(() => {
    if (!router.isReady || !router.query.id) return; // Ensure router is ready and id is available

    const fetchData = async () => {
      try {
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

  return (
    <div className="center-container">
      <div className="center-div">
        <JogadoresMesa rodadaId={rodadaId} />
      </div>
      <Footer />
    </div>
  );
}
