import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from '@/components/Dashboard'
import Map from '@/components/Map'
import Quests from '@/components/Quests'
import Rewards from '@/components/Rewards'
import Achievments from '@/components/Achievments'
import Quiz from '@/components/Quiz'

// import Toastr
// import toastr less file: need webpack less-loader
// Register vue component

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
    },
    {
      path: '/rewards',
      name: 'Rewards',
      component: Rewards
    },
    {
      path: '/stats',
      name: 'Stats',
      component: Achievments
    },
    {
      path: '/quiz/:id',
      name: 'Quiz',
      component: Quiz
    }
  ]
})
