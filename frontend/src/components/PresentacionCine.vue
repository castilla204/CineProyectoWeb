<template>
  <div class="home">
    <div class="izquierda">
      <img :src="'multimedia/fotopalomitas.png'" alt="Palomitas de maíz" class="fotopalomitas">
    </div>
    <div class="derecha">
      <div class="textopresentacion">
        <p class="f1">ZARAGOZA</p>
        <p class="f2">{{ $t('PresentacionCine.text1') }}</p>
        <p class="f3">{{ $t('PresentacionCine.text2') }}</p>
        <button class="botonhome" @click="accionScrollDown">{{ $t('PresentacionCine.text3') }}</button>
      </div>
    </div>
    <canvas ref="animacionCanvas" class="animacion-canvas"></canvas>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue';

// funcion para desplazar la pagina hacia abajo
const accionScrollDown = () => {
  window.scrollBy({ top: 1000, behavior: 'smooth' });
};


let animationFrameId: number | null = null;

// funcion para iniciar la animacion
const startAnimation = () => {
  const canvas = document.querySelector('.animacion-canvas') as HTMLCanvasElement;
  const ctx = canvas.getContext('2d');

  if (!ctx) {
    console.error('No se pudo obtener el contexto del canvas');
    return;
  }

  // ajustar el tamano del canvas
  canvas.width = 200;
  canvas.height = 200;

  // parametros de la animacion
  let posXtriangulo = 100; // restablecer la posicion inicial del triangulo
  let anguloRotacion = 0;
  let velocidadRotacion = Math.PI / 45;
  let velocidadMovimiento = 4;
  let colorHover = "red";
  let colorNormal = "white";
  let ratonEncima = false;
  let animacionActiva = true;

  // funcion para dibujar la animacion en el canvas
  const dibujar = () => {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // dibujar los elementos de la animacion
    ctx.beginPath();
    ctx.arc(60, 65, 30, 0, Math.PI * 2);
    ctx.fillStyle = "white";
    ctx.fill();

    ctx.beginPath();
    ctx.arc(140, 55, 40, 0, Math.PI * 2);
    ctx.fill();

    ctx.fillStyle = 'white';
    ctx.fillRect(50, 100, 100, 100);

    ctx.save();
    ctx.translate(posXtriangulo + 25, 150);
    ctx.rotate(anguloRotacion);
    ctx.beginPath();
    ctx.moveTo(-25, -50);
    ctx.lineTo(-25, 50);
    ctx.lineTo(25, 0);
    ctx.closePath();
    ctx.fillStyle = ratonEncima ? colorHover : colorNormal;
    ctx.fill();
    ctx.restore();

    // actualizar parametros de la animacion
    if (animacionActiva) {
      anguloRotacion += velocidadRotacion;
    }

    if (posXtriangulo < 150 && animacionActiva) {
      posXtriangulo += velocidadMovimiento;
    }

    if (anguloRotacion >= Math.PI && posXtriangulo >= 150 && animacionActiva) {
      setTimeout(() => {
        posXtriangulo = 100; // restablecer la posicion inicial del triangulo
        anguloRotacion = 0;
        animacionActiva = true;
      }, 1000);
      animacionActiva = false;
    }

    // solicitar el siguiente cuadro de animacion
    animationFrameId = requestAnimationFrame(dibujar);
  };

  // manejar eventos del raton
  canvas.addEventListener('mouseover', () => {
    ratonEncima = true;
  });

  canvas.addEventListener('mouseout', () => {
    ratonEncima = false;
  });

  // iniciar la animacion
  dibujar();
};

// ejecutar la funcion de inicio de la animacion cuando se monta el componente
onMounted(() => {
  startAnimation();
});

// cancelar la animacion cuando se desmonta el componente
onUnmounted(() => {
  if (animationFrameId) {
    cancelAnimationFrame(animationFrameId);
  }
});
</script>

<style scoped>

.animacion-canvas {
  position: absolute;
  bottom: 120px; 
  left: 75%;
}


.home {
  display: flex;
  justify-content: space-between;
  margin-top: 5%;
  margin-bottom: 5%;
}

.izquierda {
  margin-left: 12%;
}


.textopresentacion {
  margin-top: 7%;
  margin-left: 20%;
}


.f1 {
  color: white;
  font-family: 'HelveticaCursiva';
  font-size: 100px;
  margin-bottom: -28px;
  margin-left: 1%;
}


.botonhome {
  margin-left: 1%;
  margin-top: 3%;
  font-family: 'HelveticaBold';
  display: inline-block;
  padding: 15px 30px;
  border-radius: 30px;
  background-color: red;
  color: black;
  text-decoration: none;
  border: none;
  cursor: pointer;
}


.f2 {
  color: white;
  font-family: 'HelveticaBold';
  font-size: 110px;
  margin: 0;
}


body {
  padding: 0;
  margin: 0;
  background: black;
  font-family: 'Helvetica';
}


.f3 {
  color: white;
  font-family: 'HelveticaThin';
  font-size: 28px;
  margin: 0;
  margin-left: 1%;
  max-width: 70%;
}


.izquierda img {
  height: 600px;
}


@media screen and (max-width: 768px) {
  .home {
    flex-direction: column;
    align-items: center;
    margin-top: 20px;
    margin-bottom: 20px;
  }

  .izquierda,
  .derecha {
    width: 100%;
    text-align: center;
    margin-left: 0;
  }

  .fotopalomitas {
    display: none;
  }


  .textopresentacion {
    margin-top: 10%;
    margin-left: 0;
  }

  .f1,
  .f2,
  .f3 {
    font-size: 40px;
    margin: 0;
    max-width: 100%;
  }

  .f3 {
    display: block;
    font-size: 20px;
  }

  .botonhome {
    margin-top: 20px;
    margin-left: 0;
  }
  .animacion-canvas{
  display: none;
}
}
</style>