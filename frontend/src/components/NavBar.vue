<template>
  <b-navbar id="navbar" toggleable="md" type="dark" variant="info" class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">

    <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

    <b-navbar-brand class="brand" href="/">SessionBorn</b-navbar-brand>

    <b-collapse is-nav id="nav_collapse">

      <!-- Right aligned nav items -->

      <b-navbar-nav class="ml-auto">
        <b-nav-text class="line">
          <icon name="clock-o"></icon> Time:
          {{ time_string }}
        </b-nav-text>
      </b-navbar-nav>

      <b-navbar-nav class="ml-auto">

        <b-nav-item  class="line" href="#"><icon name="sign-out"></icon> Logout</b-nav-item>
      </b-navbar-nav>


    </b-collapse>
  </b-navbar>
</template>

<script>
    export default {
      name: 'nav-bar',
      data () {
        return {
          scores: '123232',
          now: new Date(),
          timer: ''
        }
      },
      created: function () {
        this.updateTime()
        this.timer = setInterval(this.updateTime, 100)
      },
      methods: {
        updateTime: function () {
          this.now = new Date()
        }
      },
      computed: {
        time_string: function () {
          return this.now.toTimeString().split(' ')[0]
        }
      }
    }
</script>

<style lang="scss" scoped>
  .navbar {
    .brand {
      font-family: 'DarkShadow', 'Gudea', Helvetica, Arial, sans-serif;
      font-size: 2rem;
    }
  }
.line {
  line-height: 30px;
}
</style>
