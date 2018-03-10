<template>
<div id="Map" class="mapContainer">
  <gmap-map
    :center="center"
    :zoom="7"
    style="width: 100%; height: 100%"
  >
    <gmap-marker
      :key="index"
      v-for="(m, index) in markers"
      :position="m.position"
      :clickable="true"
      :draggable="false"
      @click="m.messageVisible=!m.messageVisible"
    >
      <gmap-info-window :opened="m.messageVisible">
        <span class="maptitle"> {{m.title}}</span>
        <p>{{ m.desc }}</p>
      </gmap-info-window>
    </gmap-marker>
  </gmap-map>
</div>
</template>

<script>
  import * as VueGoogleMaps from 'vue2-google-maps'
  import Vue from 'vue'

  Vue.use(VueGoogleMaps, {
    load: {
      key: 'AIzaSyC29gafI4xkrUgA-P_ezy6NIOuwLfNWCTU',
      libraries: 'places,drawing,visualization'
    }
  })

  export default {
    name: 'map_comp',
    data () {
      return {
        center: {lat: 0.0, lng: 0.0},
        markers: []
      }
    },
    mounted: function () {
      if (this.$route.params.lon != null && this.$route.params.lat != null) {
        alert('B1')
        let pos = {lat: Number(this.$route.params.lat), lng: Number(this.$route.params.lon)}
        this.markers = [
          {
            position: pos,
            title: this.$route.params.title,
            messageVisible: true
          }]
        this.center = pos
      } else {
        this.markers = [{
          position: {lat: 10.0, lng: 10.0},
          title: 'Kolos',
          desc: 'dsadsadsadsad sdsad saesfd sdfs',
          messageVisible: true
        }, {
          position: {lat: 11.0, lng: 11.0},
          title: 'Something',
          desc: 'dsadsadsadsad sdsad saesfd sdfs',
          messageVisible: false
        }]
      }
    }
  }
</script>

<style lang="scss" scoped>
  .mapContainer{
    margin: auto;

    height: 80vh;
    width: 70vw;
  }

  .maptitle{
    font-size: large;
  }

</style>
