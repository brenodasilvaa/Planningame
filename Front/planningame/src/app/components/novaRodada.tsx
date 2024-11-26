import { ThemeProvider } from "@emotion/react";
import { createTheme, IconButton } from "@mui/material";
import React from "react";
import RefreshIcon from "@mui/icons-material/Refresh";
import { useRouter } from "next/router";

const NovaRodada = () => {
    const router = useRouter();
    const theme = createTheme({
        palette: {
          primary: {
            main: "#e9b261"
          }
        },
      });

      const novaRodada = async () => {
        console.log("Nova rodada")
        await fetch(`http://192.168.0.67:44303/api/rodada`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
              },
            body: JSON.stringify({ partidaId:  router.query.id })
          });

          window.location.reload();
      };
      
    return <>
    <ThemeProvider theme={theme}>
      <IconButton
      color="primary"
      onClick={async () => 
        {
          await novaRodada();
        }}
      style={{
        backgroundColor: "#f0f0f0",
        padding: "10px",
        borderRadius: "50%",
      }}
    >
      <RefreshIcon />
    </IconButton>
      </ThemeProvider></>
}

export default NovaRodada;
