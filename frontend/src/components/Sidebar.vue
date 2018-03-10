<template>
  <div id="sidebar" class="sidebar col-sm-2">
    <div class="user-profile px-2 my-4">
      <h5 class="user-name text-uppercase">{{ user.name }}</h5>
      <div class="user-photo"><img v-bind:src="user.photoLink" alt="avatar"></div>
      <div class="user-stats row">
        <div class="col-8 user-exp">{{ user.exp }}/{{ user.nextExp }} EXP</div>
        <div class="col-4 user-lvl"> {{ user.lvl }} LVL</div>
      </div>
      <div class="progress-bar">
        <div class="progress-bar-fill" :style="{ 'width': user.levelPercentage*100 + '%'  }"></div>
      </div>
    </div>
    <div class="menu">
      <h6 class="menu-header text-uppercase">Menu</h6>
      <b-nav vertical>
        <b-nav-item  v-for="item in menu"  :key="item.name" active class="menu-item" v-bind:href="item.link">
          <div class="row">
          <span class="icon col-3"><icon v-bind:name="item.icon"></icon></span>
          <span class="name col-9">{{ item.name }}</span>
          </div>
        </b-nav-item>
      </b-nav>
    </div>
  </div>
</template>

<script>
    export default {
      name: 'Sidebar',
      data () {
        return {
          user: {
            name: '',
            photoLink: '',
            lvl: 0,
            exp: 0 },
          menu: [
            { link: '/', name: 'Dashboard', icon: 'home' },
            { link: '/#/rewards', name: 'Awards', icon: 'star' },
            { link: '/#/map', name: 'Map', icon: 'map' },
            { link: '#', name: 'Statistics', icon: 'area-chart' }
          ]
        }
      },
      mounted: function () {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Sidebar', {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        })
          .then(response => {
            this.user = response.body
          }, response => {
            this.error = response.error
          })
      }
    }
</script>

<style lang="scss" scoped>
  @import "./../scss/variables.scss";
  .sidebar {
    background-color: $main-sidebar-color;
    padding-top: 50px;
    overflow-x: hidden;
    text-align: center;
    color: $text-color;
    .user-profile {
      .user-photo {
        img {
          object-fit: cover;
          object-position: center;
          width: 150px;
          height: 150px;
          border: $main-border;
          border-radius: 50%;
        }
      }
      .progress-bar {
        background-color: black;
        height: 5px;
        &-fill {
           width: 100%;
           background-color: #207CCA;
           height: 5px;
         }
      }
    }
  .menu {
    width: 100%;
  .menu-item {
      background: $menu-secondary;
      border-right: $main-border;
      text-align: left;
      width: 100%;
      height: 50px;
      padding: 0;
      line-height: 50px;
      .nav-link {
          padding: 0;
          height: 100%;
        margin-left: 15px;
          .icon {
            background: $text-color;
            color: $main-sidebar-color;
          }
          .name {
            color: $main-sidebar-color;
          }
      }
      :hover {
        background: $text-color;
        color: $menu-secondary;
        transition: color,background-color 0.2s ease-out;
      }
      }
    }
  }

</style>
