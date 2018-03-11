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
            <b-button v-if="quest.isQuiz" variant="info" size="sm" v-bind:disabled="quest.completed" :to="'/quiz/' + quest.id">Solve quiz</b-button>
          <b-button v-else variant="success" size="sm" v-bind:disabled="quest.completed" @click="getSolveQuestModal(quest.id)">Complete</b-button>
            <b-button variant="secondary" size="sm"
                      v-bind:href = "mapLink(quest.Latitude,quest.Longitude,quest.name)" class="card-link"
                      v-bind:disabled="checkMapParams(quest.Latitude,quest.Longitude)">Show on map</b-button>
            <b-button variant="danger" size="sm" v-bind:disabled="quest.completed">Resign</b-button>
          </b-button-group>
        </b-card>
      </b-card-group>
      <b-modal id="addQuestModal"
               title="Add new quest"
               @ok="sendQuest"
               @shown="clearQuestModal">
        <div class="form-group">
          <label for="newQuestName" >Name</label>
          <input id="newQuestName" class="form-control" placeholder="Name"  v-model="newQuest.name" required autofocus>
          <label for="newQuestDesc" >Description</label><br/>
          <textarea class="form-control" rows="3" id="newQuestDesc" v-model="newQuest.description"></textarea>
          <label for="newQuestType" >Type</label>
          <b-form-select id="newQuestType" name="newQuestType" v-model="newQuest.type" :options="questType" class="form-control"/>
          <label for="newQuestDate" >Due date</label>
          <input type="datetime-local" id="newQuestDate" class="form-control" placeholder="Due date"  v-model="timestamp" required autofocus>
          <label for="newQuestPoints" >Points</label>
          <input type="number" id="newQuestPoints" min="0" class="form-control" placeholder="ECTS points"  v-model="newQuest.points" required autofocus>
          <div class="row">
            <div class="col-6">
              <label for="newQuestLat" >Latitude</label>
              <input type="number" id="newQuestLat" min="0" class="form-control" placeholder="Latitude"  v-model="newQuest.Latitude">
            </div>
            <div class="col-6">
              <label for="newQuestLon" >Longitude</label>
              <input type="number" id="newQuestLon" min="0" class="form-control" placeholder="Longitude"  v-model="newQuest.Longitude">

            </div>
          </div>
        </div>
      </b-modal>
      <b-modal
        hide-footer
        ref="solveQuestModal"
        id="SolveQuestModal"
        v-bind:title="questNow.name"
        @hidden="clearModal()"
        class="quiz-dialog">
        <p class="my-4">Do you wanna finish this quest?</p>
        <b-btn class="mt-3" variant="success" block @click="solveQuest(questNow.id)" v-bind:disabled="!questNow.canSolve">Acquire reward</b-btn>
      </b-modal>
    </div>
</template>

<script>
  import { EventBus } from './../bus/event-bus.js'

  export default {
    name: 'Quests',
    data () {
      return {
        msg: 'Welcome to Your Vue.js App',
        quests: null,
        error: null,
        timestamp: Date.now(),
        newQuest: {
          name: '',
          scenarioId: this.$route.params.id,
          type: 0,
          dueDate: Date.now(),
          Latitude: 0.0,
          Longitude: 0.0,
          description: '',
          points: 0
        },
        questType: [
          {
            text: 'Test',
            value: 1
          },
          {
            text: 'Exam',
            value: 2
          },
          {
            text: 'Meeting',
            value: 3
          },
          {
            text: 'Quiz',
            value: 4
          }
        ],
        questNow: {
          id: 0,
          name: '',
          canSolve: false
        }
      }
    },
    watch: {
      timestamp: function (val) {
        this.newQuest.dueDate = val.toLocaleString()
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
        return '/#/map/' + lon + '/' + lan + '/' + name.replace(' ', '%20')
      },
      sendQuest: function () {
        this.newQuest.dueDate = this.newQuest.dueDate.toLocaleString()
        console.log(this.newQuest)
        this.$http.post('http://arrowtotherest.azurewebsites.net/api/Quest/add', this.newQuest, {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          this.$snotify.success('Quest added', 'Success')
          this.clearQuestModal()
          this.getQuests()
        }, response => {
          this.$snotify.error('Please check data: ' + response.status, 'Error')
          this.error = response.status
        })
      },
      clearQuestModal: function () {
        this.newQuest = {
          name: '',
          scenarioId: this.$route.params.id,
          type: '',
          dueDate: Date.now(),
          Latitude: 0.0,
          Longitude: 0.0,
          description: '',
          points: 0
        }
      },
      getQuests: function () {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Scenario/' + this.$route.params.id + '/Quests', {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
            // get body data
          this.quests = response.body
        }, response => {
          this.error = response.status
        })
      },
      getSolveQuestModal: function (id) {
        this.$http.post('http://arrowtotherest.azurewebsites.net/api/Quest/' + id + '/canComplete', {
          questID: id
        }, {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          if (response.body.isSuccess) {
            this.questNow.id = id
            this.questNow.name = this.quests.find((elem) => elem.id === id).Name
            this.questNow.canSolve = response.body.isSuccess
          }
        }, response => {
          this.error = response.status
        })
        this.$refs.solveQuestModal.show()
      },
      solveQuest: function (id) {
        this.$http.post('http://arrowtotherest.azurewebsites.net/api/Quest/' + id + '/complete', {
          questID: id
        }, {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          EventBus.$emit('reward-send')
          console.log('EMITED BUS')
          this.$refs.solveQuestModal.hide()
          this.getQuests()
        }, response => {
          this.error = response.status
        })
      },
      clearModal: function () {
        this.questNow.id = 0
        this.questNow.name = ''
        this.questNow.canSolve = false
      }
    },
    mounted: function () {
      this.getQuests()
      EventBus.$on('quiz-send', this.getQuests)
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
