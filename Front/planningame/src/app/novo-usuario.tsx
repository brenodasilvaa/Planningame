'use client'

import { useRouter } from "next/navigation";
import React, { useState } from "react";
import Cookies from "js-cookie";

const NovoUsuario = ({partidaId}) => {
  const [jogador, setJogador] = useState("");
  const [loading, setLoading] = useState(false);
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      const response = await fetch("http://192.168.0.67:44303/api/jogadores", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ nome: jogador, partidaId }),
      });

      if (!response.ok) {
        throw new Error("Failed to create partida");
      }
      
      const { id } = await response.json();
      Cookies.set("PlanningGame", JSON.stringify({nome: jogador, jogadorId: id, partidaId: partidaId}), { expires: 7 });
    } catch (error) {
      console.error("Error creating usuer:", error);
      alert("Failed to create user. Please try again.");
    } finally {
      router.refresh();
    }
  };

  return (
    <div style={{ display:"flex", flexDirection:"column", alignItems:"center", textAlign: "center", marginTop: "100px" }}>
      <h1>Como deseja ser chamado?</h1>
      <form  style={{ display:"flex", flexDirection:"column", width:"30vw"}} onSubmit={handleSubmit}>
        <input
          type="text"
          value={jogador}
          onChange={(e) => setJogador(e.target.value)}
          placeholder="Seu nome"
          required
          style={{ padding: "10px", fontSize: "16px", width: "300px" }}
        />
        <br />
        <button
          type="submit"
          disabled={loading}
          style={{
            marginTop: "20px",
            padding: "10px 20px",
            fontSize: "16px",
            background: "blue",
            color: "white",
            border: "none",
            cursor: "pointer",
          }}
        >
          {loading ? "Creating..." : "Start Game"}
        </button>
      </form>
    </div>
  );
};

export default NovoUsuario;