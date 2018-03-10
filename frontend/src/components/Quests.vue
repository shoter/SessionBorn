<template>
    <div class="scenario-detail">
      <h2 class="header">Scenario no. {{ $route.params.id }}</h2>
      <b-card-group columns>
        <b-card  v-for="quest in quests" :key="quest.id" class="tile"
                 v-bind:title="quest.name"
                 v-bind:sub-title="quest.description">
          <div slot="header"
              class="mb-0"><b>Points:</b> {{ quest.points }}</div>
          <div slot="footer">
            <small v-if="quest.completed" class="text-muted">Finished quest!</small>
            <small v-else class="due-date">{{ updateTime(quest.dueDate) }} days left</small>
          </div>

          <router-link :to="'/map/'"
                       class="card-link">
            <b-button variant="secondary">Show on map</b-button></router-link>
        </b-card>
      </b-card-group>
      {{ error }}
    </div>
</template>

<script>
    export default {
      name: 'Quests',
      data () {
        return {
          msg: 'Welcome to Your Vue.js App',
          quests: null,
          error: null
        }
      },
      methods: {
        updateTime: function (date) {
          let dayConst = 86400 * 1000
          return Math.floor((Date.parse(date) - Date.now()) / dayConst)
        }
      },
      mounted: function () {
        this.$http.get('http://localhost:8080/static/quest.json').then(response => {
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
      color: firebrick;
    }
  }

</style>
