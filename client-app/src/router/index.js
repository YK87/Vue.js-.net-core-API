import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Features from '../views/Features.vue'
import Bills from '../views/Bills.vue'
import TaskList from '../views/TaskList.vue'
import Finres from '../views/Finres.vue'
import Expertise from '../views/Expertise.vue'

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
    path: '/bills',
    name: 'Bills',
    component: Bills
  },
  {
    path: '/tasklist',
    name: 'tasklist',
    component: TaskList
  },
  {
    path: '/finres',
    name: 'finres',
    component: Finres
  },
  {
    path: '/expertise',
    name: 'expertise',
    component: Expertise
  }
]

const router = new VueRouter({
  routes
})

export default router
