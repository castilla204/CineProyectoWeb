<template>
  <header>
      <nav class="header">
          <div class="left">
              <img src="../../multimedia/logosinletra.svg" class="logocine">
          </div>
          <ul class="right">
              <li><a href="index.html" class="promo">Promos</a></li>
              <li><a href="index.html" class="pelis">Películas</a></li>
              <li><a href="index.html" class="billetes">Boletos</a></li>
          </ul>
      </nav>
  </header>
</template>

<style>
/* Header */
.header {
  background-color: rgb(196, 0, 0);
  height: 90px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-family: 'Helvetica';
}

.logocine {
  height: 60px;
}

.right {
  display: flex;
  justify-content: space-between;
  list-style: none;
  font-size: 20px;
}

.right a {
  color: white;
  text-decoration: none; /* Elimina el subrayado */
}

.promo,
.pelis,
.billetes {
  margin-right: 30px;
  margin-left: 30px;
}

.left,
.right {
  margin: 20px 40px;
}
/* Header */
</style>