<template>

  <div id="container" class="chartMainContainer">
    <div class="row">
      <div class="col-sm chartContainer">
        <h1>Quest Frequency</h1>
        <line-chart class="lineChart">
        </line-chart>
      </div>
      <div class="col-sm chartContainer">
        <h1>Focus chart</h1>
        <focus-chart class="lineChart">
        </focus-chart>
      </div>
      <div class="col-sm chartContainer">
        <h1>Focus chart</h1>
        <task-chart class="lineChart">
        </task-chart>
      </div>
    </div>
    <div class="row">
      <div class="col-sm chartContainer">
        <h1>Points</h1>
        <points-chart class="lineChart">
        </points-chart>
      </div>
    </div>

  </div>
</template>

<script>
  import LineChart from '../QuestChart.js'
  import FocusChart from '../FocusChart.js'
  import PointsChart from '../PointsChart.js'
  import TaskNumberChart from '../TaskNumberChart.js'

  export default {
    components: {
      'line-chart': LineChart,
      'focus-chart': FocusChart,
      'points-chart': PointsChart,
      'task-chart': TaskNumberChart
    }
  }
</script>

<style scoped>
  .chartContainer{
    margin:5px;
    padding: 10px;
    background-color: rgba(255,255,255,0.7);

  }
  .chartContainer h1{
    text-align: center;
    font-size: 10pt;
  }

  .lineChart{
    height: 25vh;
  }

  .chartMainContainer{
    padding: 10px;
  }
</style>
