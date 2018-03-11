// LineChart.js
import { Radar } from 'vue-chartjs'

export default {
  extends: Radar,
  mounted: function () {
    this.renderChart({
      labels: ['Programowanie', 'Unix', 'Matematyka I', 'Elektronika', 'Algebra'],
      datasets: [
        {
          label: '',
          data: [100, 85, 70, 90, 30]
        }
      ]
    }, {responsive: true, maintainAspectRatio: false})
  }
}
