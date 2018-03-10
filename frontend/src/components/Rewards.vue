<template>
    <div class="scenario-detail">
      <h2 class="header">Rewards</h2>
      <b-card-group columns>
        <b-card  v-for="reward in rewards" :key="reward.RewardID" class="tile"
                 v-bind:title="reward.Name"
                 v-bind:sub-title="reward.Description">
          <div slot="header"
              class="mb-0 row">
            <div class="col-6"><icon name="star"></icon></div>
            <div class="col-6 text-right"><b>{{ reward.Cost }}</b></div>
          </div>

          <b-button-group>
          <b-button v-b-modal="'reward' + reward.RewardID" variant="success" size="sm" @click="getReward(reward.RewardID)">Get reward</b-button>
          </b-button-group>
          <b-modal v-bind:id="'reward' + reward.RewardID" v-bind:title="reward.Name">
            <p class="my-4">Do you wanna get your reward?</p>
          </b-modal>
        </b-card>
      </b-card-group>
    </div>
</template>

<script>
    export default {
      name: 'Rewards',
      data () {
        return {
          msg: 'Welcome to Your Vue.js App',
          rewards: null,
          user_points: 30,
          error: null,
          canBuy: null
        }
      },
      methods: {
        getReward: function (id) {
          alert('Reward' + id)
        }
      },
      mounted: function () {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Reward', {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          // get body data
          this.rewards = response.body
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
  .modal-content {
    color: $main-dark;
  }

</style>
