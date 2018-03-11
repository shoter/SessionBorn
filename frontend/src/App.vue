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
    <vue-snotify></vue-snotify>
  </div>
</template>

<script>
  import NavBar from './components/NavBar'
  import SideBar from './components/Sidebar'
  import LoginForm from './components/LoginForm'

  export default {
    name: 'app',
    components: {
      'navbar': NavBar,
      'sidebar': SideBar,
      'login-form': LoginForm
    },
    data () {
      // this.$refs.toastr.Add('ERRROR MESSAGE')
      // this.$refs.toastr.Add('SUCCESS MESSAGE')
      return {
        authFlag: false
      }
    },
    mounted: function () {
      let cookie = this.$cookie.get('skyrim_token')
      if (cookie != null) {
        this.authFlag = true
      }
    }
}
</script>

<style lang="scss" scoped>
  @import 'scss/main.scss';
</style>

