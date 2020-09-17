<template>
  <v-app>
    <div id="home">
      <v-simple-table class="mx-auto mt-5">
        <tr>
          <td><img src="../assets/reso_med_viber_1000.png" width="300" /></td>
        </tr>
        <tr>       
          <td>
            <v-btn
              color=#1B7656
              dark
              x-large
              @click=router-link to="/Features"
            >
              Get started
            </v-btn>
          </td>
        </tr>
      </v-simple-table> 
    </div>
  </v-app>
</template>

<script>

export default {

}
</script>

<style scoped>
  #home {
    font-family: "Roboto"; 
  }

</style>