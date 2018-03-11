<template>
  <div id="container" class="quizContainer">
<h1>{{ quiz.title }}</h1>
<p>{{ quiz.description}}</p>
  <form  ref="quizForm"  v-on:submit.prevent="checkQuiz">
      <div v-for="question in quiz.questions" class="question">
        <div class="panel panel-default answerPanel">
          <div class="panel-heading">{{ question.question }}</div>
          <div class="panel-body">
            <div class="row">
              <div class="col-sm" v-for="answer in question.variants">
                <input type="radio" v-model="question.userAnswer" v-bind:value="answer" > {{ answer }}
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="submitContainer">
      <button class="btn btn-warning" type="submit" ><icon name="check"></icon>Check</button>
      </div>
    </form>

    <b-modal ref="resultModal" title="Quiz result">
      <p class="my-4">
        Your score: {{ points }}/{{ all }}<br/>
      </p>
      <div slot="modal-footer" >
        <b-btn variant="success" :disabled="points/all < 0.5" size="sm" @click="markAsFinished">
          Finish
        </b-btn>
        <b-btn size="sm" variant="info" @click="restartQuiz">
          Restart
        </b-btn>
      </div>

    </b-modal>
  </div>

  <!-- Modal Component -->
</template>

<script>
  import { EventBus } from './../bus/event-bus.js'
  import NavForm from 'bootstrap-vue/es/components/nav/nav-form'
  function shuffleArray (array) {
    for (let i = array.length - 1; i > 0; i--) {
      let j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]]
    }
  }
  export default {
    components: {NavForm},
    name: 'quiz',
    data () {
      return {
        quiz: {},
        points: 0,
        all: 0,
        empty: 0
      }
    },
    mounted: function () {
      this.$http.get('http://arrowtotherest.azurewebsites.net/api/Quiz?quizID=' + this.$route.params.id, {
        headers: {
          Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
        }
      }).then(response => {
          // get body data
        console.log(response.body)
        this.quiz = response.body
        this.quiz.questions.forEach(function (question) { shuffleArray(question.variants) })
      }, response => {
        this.error = response.error
      })
    },
    methods: {
      markAsFinished: function () {
        console.log('sent')
        let answer = {
          quizID: parseInt(this.$route.params.id),
          score: (this.points / this.all).toFixed(2) * 100
        }
        console.log(answer)
        this.$http.post('http://arrowtotherest.azurewebsites.net/Api/Quiz/Answer', answer, {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          EventBus.$emit('quiz-send')
          this.$snotify.success('You solved quiz', 'Solved')
        }, response => {
          this.$snotify.error('Please check data: ' + response.error, 'Error')
          this.error = response.error
        })
        this.restartQuiz()
      },
      restartQuiz: function () {
        this.$refs.resultModal.hide()
        this.quiz.questions.forEach(function (question) { question.userAnswer = undefined })
      },
      checkQuiz: function () {
        console.log(this.quiz)
        let points = 0
        let empty = 0
        let all = 0

        this.quiz.questions.forEach(function (question) {
          all += 1
          console.log(question)
          if (question.userAnswer === undefined) {
            empty += 1
          } else if (question.userAnswer === question.answer) {
            points += 1
          }
        })

        this.points = points
        this.all = all
        this.empty = empty

        this.$refs.resultModal.show()
      }
    }
  }
</script>

<style lang="scss" scoped>
  @import "./../scss/variables.scss";
.answerPanel{
  margin: 10px 0px;
}
  .answerPanel .panel-heading{
  padding: 2px 10px;
    min-width: 100px;
  width: fit-content;
  border-top-left-radius: 10px;
  border-top-right-radius: 10px;
    color: white;
  background-color: $main-dark;
}
  .quizContainer{
    padding: 10px;
  }

.answerPanel .panel-body{
  padding: 15px;
  background-color:rgba(125, 125, 125, 0.3);
  border: 1px solid $main-dark;
}

.submitContainer >*{
  float:right;
}


</style>
