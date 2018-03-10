<template>
  <div id="app">
  <navbar></navbar>
    <div class="row">
      <sidebar></sidebar>
      <div class="col-sm-10 main">
        <img src="./assets/logo.png">
        <router-view></router-view>
      </div>
    </div>

  </div>
</template>

<script>
  import NavBar from './components/NavBar'
  import SideBar from './components/Sidebar'

export default {
    name: 'app',
    components: {
      'navbar': NavBar,
      'sidebar': SideBar
    }
}
</script>

<style lang="scss" scoped>
  @import 'scss/main.scss';
</style>

