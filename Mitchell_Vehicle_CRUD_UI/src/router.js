import Vue from 'vue'
import Router from  'vue-router'
import VehicleView from '@/views/VehicleView.vue'

Vue.use(Router)
export default new Router({
    routes: [
        {
            path:"/",
            name: "VehicleView",
            component:VehicleView
        },
    ]
})