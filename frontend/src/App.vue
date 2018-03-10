<template>
  <div id="app">
  <navbar></navbar>
    <img src="./assets/logo.png">
    <router-view></router-view>
  </div>
</template>

<script>
  import NavBar from './components/NavBar'

export default {
    name: 'app',
    components: {
      'navbar': NavBar
    }
}
</script>

<style lang="scss" scoped>
  @import 'scss/main.scss';
</style>

