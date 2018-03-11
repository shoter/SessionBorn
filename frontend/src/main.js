// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import VueResource from 'vue-resource'
import VueCookie from 'vue-cookie'
import App from './App'
import router from './router'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'vue-awesome/icons'
import 'vue-snotify/styles/material.css' // or dark.css or simple.css
import Snotify from 'vue-snotify'

Vue.use(Snotify)
Vue.use(VueResource)
Vue.use(VueCookie)
Vue.use(BootstrapVue)
Vue.config.productionTip = false

import Icon from 'vue-awesome/components/Icon'
Vue.component('icon', Icon)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
