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
        <button class="botonhome" @click="AccionScrollDown">{{ $t('PresentacionCine.text3') }}</button>
      </div>
    </div>
    <canvas ref="animacionCanvas" class="animacion-canvas"></canvas>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue';

const AccionScrollDown = () => {
  window.scrollBy({ top: 1000, behavior: 'smooth' });
};

const animacionCanvas = ref<HTMLCanvasElement | null>(null);
let idFrameAnimacion: number;

// lo que dibuja la animaciomn
const dibujarAnimacion = (ctx: CanvasRenderingContext2D, contadorFrames: number, desplazamientoX: number) => {
  const canvas = ctx.canvas;

  // la resolucion del canvas
  const dpr = window.devicePixelRatio || 1;
  canvas.width = canvas.clientWidth * dpr;
  canvas.height = canvas.clientHeight * dpr;

  // limpiar el canvas
  ctx.clearRect(0, 0, canvas.width, canvas.height);

  // dibjuar la animacion con degradado
  const gradiente = ctx.createLinearGradient(0, 0, canvas.width, 0);
  gradiente.addColorStop(0, '#FF1461');
  gradiente.addColorStop(0.5, '#18FF92');
  gradiente.addColorStop(1, '#5A87FF');
  ctx.strokeStyle = gradiente;
  ctx.lineWidth = Math.abs(Math.sin(contadorFrames * 0.05) * 3) + 1; // Cambio de grosor
  ctx.beginPath();
  for (let i = 0; i < canvas.width; i++) {
    const y = 20 * Math.sin(0.01 * (i + desplazamientoX) + contadorFrames * 0.05);
    ctx.lineTo(i, canvas.height / 2 + y);
  }
  ctx.stroke();
};

onMounted(() => {
  if (!animacionCanvas.value) return;

  const canvas = animacionCanvas.value;
  const ctx = canvas.getContext('2d');
  if (!ctx) return;

  let contadorFrames = 0;
  const bucle = () => {
    contadorFrames++;
    dibujarAnimacion(ctx, contadorFrames, 0);
    idFrameAnimacion = requestAnimationFrame(bucle);
  };

  bucle();
});

onUnmounted(() => {
  cancelAnimationFrame(idFrameAnimacion);
});
</script>

<style scoped>

.animacion-canvas {
  position: absolute;
  bottom: 120px; 
  left: 0;
  width: 100%;
  height: 20px; 
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
