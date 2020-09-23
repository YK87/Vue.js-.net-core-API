<template>
  <div>
    <v-card 
      width="300" 
      elevation="10" 
      shaped
      class="mx-auto mt-5"
    >
      <v-img
         width="300"
        :src="require('../assets/' + imgName)"
      >
      </v-img>
      <v-card-actions>
        <v-btn
          color=#1B7656
          dark
          class="mx-auto"
          :to=linkTo
        >
          {{ title }}
        </v-btn>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script>
export default {
    props: {
        title: String,
        imgName: String,
        linkTo: String
    }
}
</script>

<style scoped>

</style>