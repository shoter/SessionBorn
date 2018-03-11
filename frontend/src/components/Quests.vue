<template>
    <div class="scenario-detail">
      <div class="row"><h2 class="header">Scenario no. {{ $route.params.id }}</h2> <div class="mx-3 py-1"><b-button v-b-modal.addQuestModal size="sm" variant="success">Add new quest</b-button></div></div>
      <b-card-group columns>
        <b-card  v-for="quest in quests" :key="quest.id" class="tile"
                 v-bind:title="quest.name"
                 v-bind:sub-title="quest.description">
          <div slot="header"
              class="mb-0 row">
            <div class="col-6"><b>Points:</b> {{ quest.points }}</div>
            <div class="col-6 text-right"><b>{{ quest.type }}</b></div>
          </div>
          <div slot="footer">
            <small v-if="quest.completed" class="text-muted">Finished quest!</small>
            <small v-else class="due-date">{{ updateTime(quest.dueDate) }} days left</small>
          </div>

          <b-button-group>
            <b-button v-if="quest.isQuiz" variant="info" size="sm" v-bind:disabled="quest.completed">Solve quiz</b-button>
          <b-button v-else variant="success" size="sm" v-bind:disabled="quest.completed">Complete</b-button>
            <b-button variant="secondary" size="sm"
                      v-bind:href = "mapLink(quest.Latitude,quest.Longitude,quest.name)" class="card-link"
                      v-bind:disabled="checkMapParams(quest.Latitude,quest.Longitude)">Show on map</b-button>
            <b-button variant="danger" size="sm" v-bind:disabled="quest.completed">Resign</b-button>
          </b-button-group>
        </b-card>
      </b-card-group>
      <b-modal id="addQuestModal" title="Add new quest">
        <p class="my-4">Hello from modal!</p>
      </b-modal>
    </div>
</template>

<script>
    export default {
      name: 'Quests',
      data () {
        return {
          msg: 'Welcome to Your Vue.js App',
          quests: null,
          error: null,
          newQuest: {
            name: '',
            scenarioId: this.$route.params.id,
            type: '',
            dueDate: Date.now(),
            Latitude: 0.0,
            Longitude: 0.0,
            description: '',
            points: 0
          }
        }
      },
      methods: {
        updateTime: function (date) {
          let dayConst = 86400 * 1000
          return Math.floor((Date.parse(date) - Date.now()) / dayConst)
        },
        checkMapParams: function (lan, lon) {
          return lan == null || lon == null
        },
        mapLink: function (lan, lon, name) {
          return '/#/map/' + lan + '/' + lon + '/' + name.replace(' ', '%20')
        }
      },
      mounted: function () {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Scenario/' + this.$route.params.id + '/Quests', {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          // get body data
          this.quests = response.body
        }, response => {
          this.error = response.error
        })
      }
    }
</script>

<style lang="scss" scoped>
  @import "./../scss/variables.scss";
  .tile {
    background-color: $main-dark;
    color: $text-color;
    border-right: $main-border;
    .due-date {
      color: #e22727;
    }
  }

</style>
