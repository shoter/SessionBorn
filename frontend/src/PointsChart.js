// LineChart.js
import { Line } from 'vue-chartjs'

export default {
  extends: Line,
  mounted: function () {
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: '',
          data: [15, 40, 60, 100, 32, 56, 32]
        }
      ]
    }, {responsive: true, maintainAspectRatio: false})
  }
}
