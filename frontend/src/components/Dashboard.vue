<template>
  <div id="Dashboard">
    <b-card-group columns>
      <b-card  v-for="scenario in scenarios" :key="scenario.id" class="tile"
              v-bind:title="scenario.scenarioName"
              v-bind:sub-title="scenario.scenarioDesc">
        <p class="card-text">
          Some quick example text to build on the <em>card title</em> and make up the bulk of the card's content.
        </p>
        <a href="#"
           class="card-link">Card link</a>
        <b-link href="#"
                class="card-link">Another link</b-link>
        <div slot="footer">
          <small class="text-muted">Last updated 3 mins ago</small>
        </div>
      </b-card>
    </b-card-group>
  </div>
</template>

<script>
export default {
  name: 'hello',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      scenarios: null,
      error: null
    }
  },
  mounted: function () {
    this.$http.get('http://localhost:8080/static/scenarios.json').then(response => {
      // get body data
      this.scenarios = response.body
    }, response => {
      this.error = response.error
    })
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss" scoped>
  @import "./../scss/variables.scss";
  .tile {
    background-color: $main-dark;
    color: $text-color;
    border-right: $main-border;
  }
</style>
