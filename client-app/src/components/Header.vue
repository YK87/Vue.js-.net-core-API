<template>
    <div>
        <v-toolbar
        color=#1B7656
        dark
      >
        <v-app-bar-nav-icon @click="drawer=true"></v-app-bar-nav-icon>
        <v-toolbar-title>
          <router-link to="/">
            <v-img width="90" src="../assets/reso_logo.jpg"></v-img>
          </router-link>
        </v-toolbar-title>
        
        <v-spacer></v-spacer>
        <v-btn icon>
          <v-icon>mdi-magnify</v-icon>
        </v-btn>
      </v-toolbar>
      
      <v-navigation-drawer
        v-model="drawer"
        absolute
        temporary
      >
        <v-list
          nav
        >
          <v-btn
            color=#1B7656
            dark
            @click=router-link to="/bills"
            class="mx-auto mt-5"
            block
          >
            Просмотр счетов
          </v-btn>
          <v-btn
            color=#1B7656
            dark
            @click=router-link to="/tasklist"
            class="mx-auto mt-5"
            block
          >
            Список задач
          </v-btn>
          <v-btn
            color=#1B7656
            dark
            @click=router-link to="/finres"
            class="mx-auto mt-5"
            block
          >
            Финансовый результат
          </v-btn>
          <v-btn
            color=#1B7656
            dark
            @click=router-link to="/expertise"
            class="mx-auto mt-5"
            block
          >
            Экспертиза
          </v-btn>
          <v-btn
            color=#1B7656
            dark
            @click=router-link to="/about"
            class="mx-auto mt-5"
            block
          >
            О программе
          </v-btn>
        </v-list>
      </v-navigation-drawer>
    </div>
</template>

<script>
export default {
    name: "Header",
    data: function() {
    return {
      drawer: false
    }
  }
}
</script>

<style scoped>

</style>