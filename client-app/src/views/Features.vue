<template>
  <div id="features"> 
    <h1>Модули</h1>
    <table align="center">
      <tr>
        <td><img src="../assets/finres.jpg" /></td>
        <td><img src="../assets/schets.jpg" /></td>
        <td><img src="../assets/expertise.jpg" /></td>
      </tr>
      <tr>
        <td id="btn"><router-link to="/finres" id="btn">Просмотр счетов</router-link></td>
        <td id="btn"><router-link to="/exchange" id="btn">Журнал обмена</router-link></td>
        <td id="btn"><router-link to="/" id="btn">Эспертиза</router-link></td>
      </tr>
    </table> 
  </div>
</template>

<script>

export default {
  
}
</script>

<style scoped>
  #features h1 {
    color: #1B7656;
  }
  #btn {
    font-family: "Roboto";
    border: none;
    background: #1B7656;
    color: #fff;
    padding: 20px;
    cursor: pointer;
    font-size: large;
    text-decoration: none;
  }

</style>