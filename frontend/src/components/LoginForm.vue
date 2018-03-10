<template>
  <div class="container" id="login-form">
    <h1 class="apkName">SessionBorn</h1>
    <div class="holder">
    <form class="form-signin">
      <h2 class="form-signin-heading">Please sign in</h2>
      <label for="inputLogin" class="sr-only">Login</label>
      <input id="inputLogin" class="form-control" placeholder="Login"  v-model="credentials.login" required autofocus>
      <label for="inputPassword" class="sr-only">Password</label>
      <input type="password" id="inputPassword" class="form-control" placeholder="Password"   v-model="credentials.password" required>
      <button class="btn btn-lg btn-primary btn-block" type="submit" @click="submit()">Sign in</button>
    </form>
    </div>

  </div>
</template>

<script>
  export default {
    data () {
      return {
        credentials: {
          login: '',
          password: ''
        },
        error: ''
      }
    },
    methods: {
      submit () {
        var credentials = {
          login: this.credentials.login,
          password: this.credentials.password
        }
        alert('Username' + credentials.login)
        // We need to pass the component's this context
        // to properly make use of http in the auth service
        // auth.login(this, credentials, 'secretquote')
      }
    },
    name: 'login-form'
  }
</script>

<style scoped>
  @import "./../scss/variables.scss";
  .container{
    padding-top: 100px;
  }
  .apkName{
    text-align: center;
    color: white;
    font-weight: bold;
    font-size: 5rem;
  }
  .holder{
    margin:auto;
    max-width: 400px;
    background-color: white;
    border-radius: 10px;
  }
  .form-signin {
    max-width: 330px;
    padding: 15px;
    margin: 0 auto;
  }
  .form-signin .form-signin-heading,
  .form-signin {
    margin-bottom: 10px;
  }

  .form-signin .form-control {
    position: relative;
    height: auto;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
    font-size: 16px;
  }

  .form-signin input, .form-signin button, .form-signin h2 {
    margin-bottom: 10px;
    margin-top: 10px;
  }


</style>
