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
        let pos = {lat: Number(this.$route.params.lat), lng: Number(this.$route.params.lon)}
        this.markers = [
          {
            position: pos,
            title: this.$route.params.title,
            messageVisible: true
          }]
        this.center = pos
      } else {
        this.$http.get('http://arrowtotherest.azurewebsites.net/api/Location', {
          headers: {
            Authorization: 'Bearer ' + this.$cookie.get('skyrim_token')
          }
        }).then(response => {
          this.markers = []
          let self = this
          console.log(response.body)
          response.body.forEach(function (quest) {
            if (quest.latitude != null && quest.longitude != null) {
              console.log(self)
              self.markers.push({
                position: {lat: quest.latitude, lng: quest.longitude},
                title: '[' + quest.scenarioTitle + ']' + quest.questTitle,
                desc: quest.description,
                messageVisible: true
              })
            }
          })

          if (self.markers.length > 0) {
            self.center = self.markers[0].position
          }
        }, response => {
          this.$snotify.error('Unable to download map data', 'Error')
          this.error = response.error
        })
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
