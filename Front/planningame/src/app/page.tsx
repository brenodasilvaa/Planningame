'use client'

import { useRouter } from "next/navigation";
import React, { useState } from "react";

const HomePage: React.FC = () => {
  const [partida, setPartida] = useState("");
  const [jogador, setJogador] = useState("");
  const [loading, setLoading] = useState(false);
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      const response = await fetch("https://localhost:44303/api/partida", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ nome: partida, jogador: {nome: jogador} }),
      });

      if (!response.ok) {
        throw new Error("Failed to create partida");
      }

      const { id } = await response.json(); // Assume the API returns the created game's `id`
      router.push(`/partida/${id}`); // Redirect to the dynamic page
    } catch (error) {
      console.error("Error creating partida:", error);
      alert("Failed to create partida. Please try again.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ display:"flex", flexDirection:"column", alignItems:"center", textAlign: "center", marginTop: "100px" }}>
      <h1>Vamos começar?</h1>
      <form  style={{ display:"flex", flexDirection:"column", width:"30vw"}} onSubmit={handleSubmit}>
        <input
          type="text"
          value={partida}
          onChange={(e) => setPartida(e.target.value)}
          placeholder="Descriçao da partida"
          required
          style={{ padding: "10px", fontSize: "16px", width: "300px" }}
        />
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

export default HomePage;