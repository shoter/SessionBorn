// LineChart.js
import { Doughnut } from 'vue-chartjs'

export default {
  extends: Doughnut,
  mounted: function () {
    this.renderChart({
      labels: ['Programowanie', 'Unix', 'Matematyka I', 'Elektronika', 'Algebra'],
      datasets: [
        {
          label: '',
          data: [10, 5, 7, 2, 11]
        }
      ]
    }, {responsive: true, maintainAspectRatio: false})
  }
}
