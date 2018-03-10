<template>
  <b-navbar id="navbar" toggleable="md" type="dark" variant="info" class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">

    <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

    <b-navbar-brand href="#">SessionBorn</b-navbar-brand>

    <b-collapse is-nav id="nav_collapse">

      <!-- Right aligned nav items -->

      <b-navbar-nav class="ml-auto">
        <b-nav-text>
          <icon name="star-o"></icon> Points: {{ scores }}
        </b-nav-text>
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto">

        <b-nav-item href="#"><icon name="sign-out"></icon> Logout</b-nav-item>
      </b-navbar-nav>


    </b-collapse>
  </b-navbar>
</template>

<script>
    export default {
      name: 'nav-bar',
      data () {
        return {
          scores: '123232'
        }
      }
    }
</script>

<style lang="scss" scoped>

</style>
