import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from '@/components/Dashboard'
import Map from '@/components/Map'
import Quests from '@/components/Quests'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Dashboard',
      component: Dashboard
    },
    {
      path: '/scenario/:id',
      name: 'Quests',
      component: Quests
    },
    {
      path: '/map/:lon/:lat/:title',
      name: 'Map',
      component: Map
    },
    {
      path: '/map',
      name: 'Map_all',
      component: Map
    }
  ]
})
