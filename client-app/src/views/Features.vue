<template>
  <v-app>
    <div id="features"> 
        <div class="mx-auto mt-5">
          <h1 class="display-1">Модули</h1>
        </div>
          <v-card width="300" class="mx-auto mt-5">
            <v-img
              width="300"
              src="../assets/finres.jpg"
            >
            </v-img>
            <v-card-actions>
              <v-btn
                color=#1B7656
                dark
                @click=router-link to="/finres"
                class="mx-auto"
              >
                Просмотр счетов
              </v-btn>
            </v-card-actions>
          </v-card>
          <v-card width="300" class="mx-auto mt-5">
            <v-img
              width = 300
              src="../assets/schets.jpg"
            >
            </v-img>
            <v-card-actions>
              <v-btn
                color=#1B7656
                dark
                @click=router-link to="/tasklist"
                class="mx-auto"
              >
                Список задач
              </v-btn>
            </v-card-actions>
          </v-card>
          <v-card width="300" class="mx-auto mt-5">
            <v-img
              width = 300
              src="../assets/expertise.jpg"
            >
            </v-img>
            <v-card-actions>
              <v-btn
                color=#1B7656
                dark
                @click=router-link to="/"
                class="mx-auto"
              >
                Эспертиза
              </v-btn>
            </v-card-actions>
          </v-card>
    </div>
  </v-app>
</template>

<script>

export default {
  
}
</script>

<style scoped>
  #features h1 {
    color: #1B7656;
  }

</style>