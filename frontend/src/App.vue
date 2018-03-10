<template>
  <div id="app">
    <template v-if="authFlag">
      <navbar></navbar>
      <div class="row">
        <sidebar></sidebar>
        <div class="col-sm-10 main">
          <router-view></router-view>
        </div>
      </div>
    </template>
    <template v-else>
      <login-form></login-form>
    </template>
  </div>
</template>

<script>
  import NavBar from './components/NavBar'
  import SideBar from './components/Sidebar'
  import LoginForm from './components/LoginForm'

export default {
    name: 'app',
    components: {
      LoginForm,
      'navbar': NavBar,
      'sidebar': SideBar,
      'login-form': LoginForm
    },
    data () {
      return {
        authFlag: true
      }
    }
}
</script>

<style lang="scss" scoped>
  @import 'scss/main.scss';
</style>

