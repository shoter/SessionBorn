<template>
  <div id="Dashboard">
    <h2 class="header">Scenarios</h2>
    <b-card-group columns>
      <b-card  v-for="scenario in scenarios" :key="scenario.id" class="tile"
              v-bind:title="scenario.scenarioName"
              v-bind:sub-title="scenario.scenarioDesc">
        <div class="progress-bar">
          <div class="progress-bar-fill" :style="{ 'width': scenario.percentDone + '%'  }"></div>
        </div>
        <router-link :to="'scenario/' + scenario.id"
          class="card-link">See quests</router-link>
        <div v-if="scenario.completed" slot="footer">
          <small class="text-muted">Finished scenario!</small>
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
    /* this.$http.interceptors.get(function (request) {
      request.headers.set('X-CSRF-TOKEN', this.$cookie.get('skyrim_token'))
      request.headers.set('Authorization', 'Bearer TOKEN')
    }) */
    this.$http.get('http://arrowtotherest.azurewebsites.net/api/Scenario', {
      headers: {
        Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
      }
    }).then(response => {
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
    .progress-bar {
      background-color: black;
      height: 5px;
      &-fill {
        width: 100%;
        background-color: #a0e27a;
        height: 5px;
       }
    }
  }
</style>
