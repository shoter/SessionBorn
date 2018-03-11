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
          events: [
            {
              title: 'event1',
              start: '2018-01-01'
            },
            {
              title: 'event2',
              start: '2018-01-05',
              end: '2018-01-07'
            },
            {
              title: 'event3',
              start: '2018-01-09T12:30:00',
              allDay: false
            }
          ],
          config: {
            weekends: false
          }
        }
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
