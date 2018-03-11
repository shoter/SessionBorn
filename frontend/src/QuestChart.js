// LineChart.js
import { Line } from 'vue-chartjs'

export default {
  extends: Line,
  mounted: function () {
    this.$http.get('http://arrowtotherest.azurewebsites.net/api/Statistics/GetMonthCompletions', {
      headers: {
        Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
      }
    }).then(response => {
      // get body data
      console.log(response.body)

      let self = this
      let qestFreq = {
        labels: [],
        datasets: [
          {
            label: 'Quest Frequency',
            data: []
          }
        ]
      }
      response.body.forEach(function (reportElement) {
        qestFreq.labels.push(reportElement.monthName)
        qestFreq.datasets[0].data.push(reportElement.completionCount)
        self.renderChart(qestFreq, {responsive: true, maintainAspectRatio: false})
      })
    }, response => {
      this.$snotify.error('Unable to download quest freqency data', 'error')
      this.error = response.error
    })
  }
}
