<template>
  <div id="home">
    <table align="center">
      <tr>
        <td rowspan="2"><img src="../assets/reso_med_viber_1000.png" width="300" /></td>
        <td><h1>Мы заинтеРЕСОваны в вашем здоровье!</h1></td>
      </tr>
      <tr>       
        <td><router-link to="/Features" id='btn'>Get started</router-link></td>
      </tr>
    </table> 
  </div>
</template>

<script>

export default {

}
</script>

<style scoped>
  #home {
    font-family: "Roboto";
    padding: 10px;  
  }
  #home h1 {
    padding: 10px;
    color: #1B7656;
  }

  #btn {
    font-family: "Roboto";
    display: inline-block;
    border: none;
    background: #1B7656;
    color: #fff;
    padding: 20px;
    cursor: pointer;
    font-size: x-large;
    text-decoration: none;
  }

</style>