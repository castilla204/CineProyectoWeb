<template>
    <header>
        <nav class="header">
                <div class="left">
                    <img src="../../multimedia/logosinletra.svg" class="logocine">
                </div>
                <ul class="right">
                    <a href="index.html"><li class="promo">Promos</li></a>
                    <a href="index.html"><li class="pelis">Películas</li></a>
                    <a href="index.html"><li class="billetes">Boletos</li></a>
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
}

.logocine {
  height: 60px;
}

.right {
  display: flex;
  justify-content: space-between;
  list-style: none;
  color: white;
  font-size: 20px;
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