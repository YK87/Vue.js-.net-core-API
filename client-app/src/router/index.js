import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Features from '../views/Features.vue'
import Finres from '../views/Finres.vue'
import Exchange from '../views/Exchange.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/features',
    name: 'Features',
    component: Features
  },
  {
    path: '/finres',
    name: 'Finres',
    component: Finres
  },
  {
    path: '/exchange',
    name: 'exchange',
    component: Exchange
  }
]

const router = new VueRouter({
  routes
})

export default router
