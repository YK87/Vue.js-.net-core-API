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
              <FeatureCard title="Просмотр счетов" imgName="finres.jpg" linkTo="finres" />
            </div>
            <div id="pad">
              <FeatureCard title="Список задач" imgName="schets.jpg" linkTo="tasklist" />
            </div>
            <div id="pad">
              <FeatureCard title="Эспертиза" imgName="expertise.jpg" linkTo="" />
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