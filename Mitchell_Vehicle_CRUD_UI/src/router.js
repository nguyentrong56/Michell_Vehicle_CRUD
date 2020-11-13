import Vue from 'vue'
import Router from  'vue-router'
import VehicleView from '@/views/VehicleView.vue'
import CreateVehicle from '@/views/CreateVehicle.vue'

Vue.use(Router)
export default new Router({
    routes: [
        {
            path:"/",
            name: "VehicleView",
            component:VehicleView
        },
        {
            path:"/create",
            name: "CreateVehicle",
            component:CreateVehicle
        }
    ]
})