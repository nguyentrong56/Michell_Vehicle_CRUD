import axios from 'axios'
import Vuex from 'vuex'
import Vue from 'vue'
import { apiURL } from "@/const.js"


Vue.use(Vuex)
//to handle state
const url = `${apiURL}/vehicles`

//This class store the state of vehicle dataset
//Vehicles object is shared accross UI components
export default new Vuex.Store({

    state: {
        vehicles: []
    },

    //to handle state
    getters: {
        allVehicles: (state) => state.vehicles
    },

    //to handle actions 
    actions: {

        // Action to get all vehicles
        getVehicles({ commit }) {
            return new Promise((resolve, reject) => {
                axios
                    .get(url)
                    .then(response => {
                        commit('SET_VEHICLES', response.data)
                    })
                    .catch((error) => {
                        reject(error)
                    })


            })
        },
        // Action to update vehicle
        updateVehicle({ commit }, vehicle) {
            return new Promise((resolve, reject) => {
                axios
                    .put(url, vehicle)
                    .then(response => {
                        commit('UPDATE_VEHICLE', response.data)
                    }

                    )
                    .catch((error) => {
                        reject(error)
                    })
            })
        },

        //Action to create new vehicle
        createVehicle({ commit }, vehicle) {

            return new Promise((resolve, reject) => {
                axios
                    .post(url, vehicle)
                    .then(response => {
                        commit('CREATE_VEHICLE', response.data)
                    }


                    )
                    .catch((error) => {
                        reject(error)
                    })
            })



        },

        //Action to search for vehicle using params
        searchVehicle({ commit }, vehicle) {

            return new Promise((resolve, reject) => {
                axios
                    .get(url, { params: vehicle })
                    .then(response => {
                        commit('SET_VEHICLES', response.data)
                    }

                    )
                    .catch((error) => {
                        reject(error)
                    })
            })

        },

        //Action to delete vehicle using Id 
        deleteVehicle({ commit }, vehicle) {
            return new Promise((resolve, reject) => {
                axios
                    .delete(`${url}/${vehicle.Id}`)
                    .then(response => {
                        commit('DELETE_VEHICLE', response.data)
                    }

                    )
                    .catch((error) => {
                        reject(error)
                    })
            })

        }
    },


    mutations: {
        //Mutation to update state of vehicles
        SET_VEHICLES(state, vehicles) {
            state.vehicles = vehicles
        },

        //Mutation to replace a vehicle with new vehicle in dataset
        UPDATE_VEHICLE(state, vehicle) {
            const index = state.vehicles.findIndex(v => v.Id == vehicle.Id)
            Vue.set(state.vehicles, index, vehicle)

        },

        //Mutation to add newly created vehicle to dataset
        CREATE_VEHICLE(state, vehicle) {
            state.vehicles.push(vehicle)
        },

        //Mutation to remove vehicle from dataset
        DELETE_VEHICLE(state, vehicle) {
            const index = state.vehicles.findIndex(v => v.Id == vehicle.Id)
            state.vehicles.splice(index, 1)
        }
    },



}
)








