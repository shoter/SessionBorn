<template>
  <div id="Dashboard">

    <div class="row">
    <h2 class="header">Scenarios <b-button class="mx-3 py-1" variant="success" size="sm" @click="displayScenarioModal"> Add scenario </b-button></h2>
    </div>
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

    <b-modal ref="addScenarioModal" title="Add scenario">
      <div class="form-group">
        <label for="newScenarioName" >Name</label>
        <input id="newScenarioName" class="form-control" placeholder="Name"  v-model="newScenario.scenarioName" required autofocus>
        <label for="newScenarioDesc" >Description</label><br/>
        <textarea class="form-control" rows="5" id="newScenarioDesc" v-model="newScenario.scenarioDesc"></textarea>
      </div>

      <div slot="modal-footer" >
        <b-btn variant="success" size="sm" @click="addScenario">
          Add
        </b-btn>
        <b-btn size="sm" variant="info" @click="cancelScenarioAdd">
          Cancel
        </b-btn>
      </div>

    </b-modal>
  </div>
</template>

<script>
export default {
  name: 'hello',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      scenarios: null,
      error: null,
      newScenario: {
        scenarioName: '',
        scenarioDesc: ''
      }
    }
  },
  methods: {
    addScenario: function () {
      this.$http.post('http://arrowtotherest.azurewebsites.net/api/Scenario/add', this.newScenario, {
        headers: {
          Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
        }
      }).then(response => {
        this.$snotify.success('Scenario added', 'Success')
        this.newScenario.scenarioDesc = ''
        this.newScenario.scenarioName = ''
        this.$refs.addScenarioModal.hide()
        this.getScenario()
      }, response => {
        this.$snotify.error('Please check data: ' + response.error, 'Error')
        this.error = response.error
      })
    },
    cancelScenarioAdd: function () {
      this.newScenario.scenarioDesc = ''
      this.newScenario.scenarioName = ''
      this.$refs.addScenarioModal.hide()
    },
    displayScenarioModal: function () {
      this.$refs.addScenarioModal.show()
    },
    getScenario: function () {
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
  },
  mounted: function () {
    this.getScenario()
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
