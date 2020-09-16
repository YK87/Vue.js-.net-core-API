<template>
  <div id="app">
    <div id="nav">
      <div>
        <router-link to="/"><img src="./assets/reso_logo.jpg" /></router-link>
      </div>
      <div id="nav">        
        <router-link to="/features">Features</router-link>  
        <router-link to="/about">About</router-link>   
      </div>
    </div>
    <router-view/>
  </div>
</template>

<style>
@font-face {
  font-family: "Roboto";
  src: local("Roboto"),
    url(./fonts/Roboto-Regular.ttf) format("truetype");
}

#app {
  /* font-family: Avenir, Helvetica, Arial, sans-serif, Roboto; */
  font-family: "Roboto";
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  display: flex;
  background-color: #1B7656;
  padding-left: 10px;
  align-items: center;
}

#nav a {
  font-size: x-large;
  color: white;
  text-decoration: none;
  padding: 5px;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

</style>
