<template>
  <v-app>
    <div id="features"> 
        <div class="mx-auto mt-5">
          <h1 class="display-1">Модули</h1>
        </div>
        <v-container fluid>
          <v-row
            align="center"
            justify="center"
          >
            <div id="pad">
              <FeatureCard title="Просмотр счетов" imgName="bills.jpg" linkTo="bills" />
            </div>
            <div id="pad">
              <FeatureCard title="Список задач" imgName="tasks.jpg" linkTo="tasklist" />
            </div>
            <div id="pad">
              <FeatureCard title="Финансовый результат" imgName="fin.jpg" linkTo="/finres" />
            </div>
          </v-row>
          <v-row
            align="center"
            justify="center"
          >
            <div id="pad">
              <FeatureCard title="Экспертиза" imgName="expertise.jpg" linkTo="/expertise" />
            </div>
          </v-row>
        </v-container>
    </div>
  </v-app>
</template>

<script>
import FeatureCard from '../components/FeatureCard'

export default {
  components: {
    FeatureCard
  }
}
</script>

<style scoped>
  #features h1 {
    color: #1B7656;
  }

  #pad {
    padding: 1rem;
  }
  
</style>