import axios from 'axios'
import Vuex from 'vuex'
import Vue from 'vue'

Vue.use(Vuex)
//to handle state
const state = {
    vehicles: []
}

//to handle state
const getters ={
    allVehicles : (state) => state.vehicles
}

//to handle actions 
const actions = {
    getVehicles({commit}){
        const url = `https://localhost:44396/api/vehicles`
        axios
            .get(url,this.params)
            .then(response =>{
                commit('SET_VEHICLES', response.data)
            })
        },
    
    
    },
const mutations = {
    SET_VEHICLES(state, vehicles){
    state.vehicles = vehicles
    }     
}

        
    




//to handle mutations

const mutations = { 
SET_VEHICLES(state, vehicles)
{
    state.vehicles = vehicles

}
}

export default new Vue.Store({
    state,
    getters,
    actions,
    mutations
})



