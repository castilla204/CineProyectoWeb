<template>
    <div class="contenedor-boton">
      <a href="index.html">
        <router-link to="/" ><button class="boton">Comprar</button></router-link>
      </a>
    </div>
  </template>
  
  <style scoped>
  .contenedor-boton {
    display: flex;
    justify-content: center;
    margin-top: 20px;
  }
  
  .boton {
    padding: 15px 30px;
    font-size: 18px;
    background-color: rgb(196, 0, 0);
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease;
  }
  
  .boton:hover {
    background-color: #990000;
  }
  </style>