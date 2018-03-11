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
          <b-button variant="success" size="sm" @click="getRewardModal(reward.RewardID)">Get reward</b-button>
          </b-button-group>
        </b-card>
      </b-card-group>
      <b-modal
        hide-footer
        ref="rewardModal"
        id="RewardModal"
        v-bind:title="rewardNow.name"
        @hidden="clearModal()"
        class="reward-dialog">
        <p class="my-4">Do you wanna get your reward?</p>
        <b-btn class="mt-3" variant="success" block @click="sendReward(rewardNow.id)" v-bind:disabled="!rewardNow.canBuy">Acquire reward</b-btn>
      </b-modal>
    </div>
</template>

<script>
  import { EventBus } from './../bus/event-bus.js'

  export default {
    name: 'Rewards',
    data () {
      return {
        msg: 'Welcome to Your Vue.js App',
        rewards: null,
        error: null,
        rewardNow: {
          id: 0,
          name: '',
          canBuy: false
        }
      }
    },
    methods: {
      getRewardModal: function (id) {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Reward/CanBuy?rewardID=' + id, {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          if (response.body.isSuccess) {
            this.rewardNow.id = id
            this.rewardNow.name = this.rewards.find((elem) => elem.RewardID === id).Name
            this.rewardNow.canBuy = response.body.isSuccess
          }
        }, response => {
          this.error = response.error
        })
        this.$refs.rewardModal.show()
      },
      sendReward: function (id) {
        this.$http.post('http://arrowtotherest.azurewebsites.net/api/Reward/BuyReward?rewardID=' + id, {}, {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          EventBus.$emit('reward-send')
          console.log('EMITED BUS')
          this.$refs.rewardModal.hide()
        }, response => {
          this.error = response.error
        })
      },
      clearModal: function () {
        this.rewardNow.id = 0
        this.rewardNow.name = ''
        this.rewardNow.canBuy = false
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
  .reward-dialog {
    color: $main-dark;
  }

</style>
