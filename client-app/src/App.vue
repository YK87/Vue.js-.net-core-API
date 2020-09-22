<template>
  <v-app>
    <div id="app">     
      <Header />
      <transition name="fade">
        <router-view/>
      </transition>  
    </div>
  </v-app>   
</template>

<script>
import Header from './components/Header'

export default {
  components: {
    Header
  }
}
</script>
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

.fade-enter-active,
.fade-leave-active {
  transition-property: opacity;
  transition-duration: 1s;
}

.fade-enter-active {
  transition-delay: 1s;
}

.fade-enter,
.fade-leave-active {
  opacity: 0;
}

</style>