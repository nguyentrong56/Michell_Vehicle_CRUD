<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <v-img
          alt="Logo"
          class="shrink mr-2"
          contain
          src="./assets/logo.png"
          transition="scale-transition"
          width="80"
        />
      </div>
     <v-btn
        class="ma-2"
        rounded
        color="indigo"
        @click="showHowToUse"
      >
        How to use
      </v-btn>

      <v-spacer></v-spacer>
      <h1> Vehicle Manager </h1>
    </v-app-bar>
    <v-main>
      
      <HowToUse v-if ="IsHowToUseVisible" @close="closeModal"/>
      <vue-progress-bar> </vue-progress-bar>
      <router-view> </router-view>
    </v-main>
  </v-app>
</template>

<script>
import HowToUse from '@/components/HowToUse.vue'
export default {
  name: "app",
  components:{HowToUse},
  data: function() {return{
    IsHowToUseVisible: false
  }},

  methods:{
    showHowToUse(){
      this.IsHowToUseVisible = true
    },
    closeModal(){
      this.IsHowToUseVisible = false
    }
  }
};
</script>
