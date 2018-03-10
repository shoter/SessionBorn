<template>
  <div id="sidebar" class="sidebar col-sm-2">
    <div class="user-profile px-2 my-4">
      <h5 class="user-name text-uppercase">{{ user.name }}</h5>
      <div class="user-photo"><img v-bind:src="user.photoLink" alt="avatar"></div>
      <div class="user-stats row">
        <div class="col-6 user-exp">{{ user.exp }} EXP</div>
        <div class="col-6 user-lvl"> {{ user.lvl }} LVL</div>
      </div>
    </div>
    <div class="menu">
      <h6 class="menu-header text-uppercase">Menu</h6>
      <b-nav vertical v-for="item in menu"  :key="item.name">
        <b-nav-item active class="menu-item" v-bind:href="item.link">
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
            name: 'Bruce Wayne',
            photoLink: '/static/wayne.jpg',
            lvl: 10,
            exp: 236 },
          menu: [
            { link: '#', name: 'Dashboard', icon: 'home' },
            { link: '#', name: 'Scenarios', icon: 'file-text' },
            { link: '#', name: 'Awards', icon: 'star' },
            { link: '#', name: 'Statistics', icon: 'area-chart' }
          ]
        }
      }
    }
</script>

<style lang="scss" scoped>
  @import "./../scss/variables.scss";
  $menu-secondary: darkgray;

  .sidebar {
    background-color: $main-sidebar-color;
    padding-top: 50px;
    overflow-x: hidden;
    text-align: center;
    .user-profile {
      .user-photo {
        img {
          max-width: 150px;
          max-height: 150px;
          border: $main-border;
          border-radius: 50%;
        }
      }
    }
  .menu {
  .menu-item {
      background: $menu-secondary;
      border-right: $main-border;
      text-align: left;
      height: 50px;
      padding: 0;
      line-height: 50px;
      .nav-link {
          padding: 0;
          height: 100%;
        margin-left: 15px;
          .icon {
            background: $text-color;
            color: $menu-secondary;
          }
          .name {
          }
      }
      :hover {
        background: $text-color;
        color: $menu-secondary;
        transition: color,background-color 1s ease-in;
      }
      }
    }
  }

</style>
