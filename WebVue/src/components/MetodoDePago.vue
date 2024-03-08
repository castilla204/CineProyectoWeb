<template>
    <div class="contenedor-pago">
      <h2 class="titulo">Método de pago</h2>
      <div class="opcion">
        <input type="radio" id="tarjeta" name="pago" class="radio-custom">
        <label for="tarjeta" class="label-custom">
          <span class="metodo-texto">Tarjeta de crédito</span>
          <img src="../../multimedia/visa.png" alt="Visa" class="icono-pago">
        </label>
      </div>
      <div class="opcion">
        <input type="radio" id="efectivo" name="pago" class="radio-custom">
        <label for="efectivo" class="label-custom">
          <span class="metodo-texto">Efectivo en el lugar</span>
          <img src="../../multimedia/dinero.png" alt="Efectivo" class="icono-pago">
        </label>
      </div>
      <div class="opcion">
        <input type="radio" id="paypal" name="pago" class="radio-custom">
        <label for="paypal" class="label-custom">
          <span class="metodo-texto">PayPal</span>
          <img src="../../multimedia/paypal.png" alt="PayPal" class="icono-pago">
        </label>
      </div>
    </div>
  </template>
  
  <style scoped>
  .contenedor-pago {
    background-color: #757575;
    border-radius: 15px;
    padding: 30px;
    margin: 20px auto;
    max-width: 70%;
    color: #ffffff;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.5);
  }
  
  .titulo {
    color: #ffffff;
    font-family: 'Helvetica';
    margin-bottom: 2%;
  }
  
  .opcion {
    background-color: #1f1f1f;
    border-radius: 15px;
    margin-bottom: 20px;
    padding: 15px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    font-family: 'HelveticaThin';
  }
  
  .radio-custom {
    accent-color: #e6b31e;
  }
  
  .label-custom {
    display: flex;
    align-items: center;
    width: 100%;
  }
  
  .metodo-texto {
    margin-left: 20px;
    font-size: 18px;
    flex-grow: 1;
  }
  
  .icono-pago {
    width: 40px;
    height: auto;
    transition: transform 0.3s ease;
  }
  
  .label-custom:hover .icono-pago {
    transform: scale(1.1);
  }

  </style>