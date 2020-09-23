<template>
  <v-app>
    <v-card width="300" elevation="0" class="mx-auto mt-5">
            <v-img
              width="300"
              src="../assets/reso_med_viber_1000.png"
            >
            </v-img>
            <!-- пока просто форма ввода -->
            <v-text-field
              label="Login"
              hint="Введите логин"
              prepend-icon="mdi-account"
            />
            <v-text-field
              label="Password"
              type="password"
              hint="Введите пароль"
              prepend-icon="mdi-shield-lock"
            />
            <v-card-actions>
              <v-btn
                color=#1B7656
                dark
                class="mx-auto"
                to="/features"
              >
                Log in
              </v-btn>
            </v-card-actions>
        </v-card>
  </v-app>
</template>

<script>

export default {

}
</script>

<style scoped>
  #home {
    font-family: "Roboto"; 
    padding: 1rem;
  }

</style>