<template>
    <div class="scenario-detail">
      <h2 class="header">Achievments</h2>
      <b-card-group columns>
        <b-card  v-for="achievment in achievments" :key="achievment.achievementName" class="tile"
                 v-bind:title="achievment.achievementName">
          <div slot="header"
              class="mb-0 row">
            <div class="col-6"><icon name="diamond"></icon></div>
          </div>
        </b-card>
      </b-card-group>
    </div>
</template>

<script>
  export default {
    name: 'Achievments',
    data () {
      return {
        achievments: null,
        error: null
      }
    },
    mounted: function () {
      this.$http.get('http://arrowtotherest.azurewebsites.net/api/Achievement', {
        headers: {
          Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
        }
      }).then(response => {
          // get body data
        this.achievments = response.body
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
