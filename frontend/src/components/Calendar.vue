<template>
  <div id="container_calendar" class="calendar_container">
    <full-calendar :events="events"  :config="config"></full-calendar>
  </div>
</template>

<script>
    export default {
      name: 'calendar',
      data () {
        return {
          events: []
        }
      },
      mounted: function () {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Quest', {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          // get body data
          console.log(response.body)
          let self = this
          this.events = []
          response.body.forEach(function (question) {
            self.events.push({
              title: question.name,
              start: question.date,
              description: question.description,
              allDay: false
            })
          })
        }, response => {
          this.error = response.status
        })
      }
    }
</script>

<style scoped>
  @import '~fullcalendar/dist/fullcalendar.css';
  .calendar_container{
    background-color: whitesmoke;
    padding: 15px;
    border-radius: 10px;
  }



</style>
