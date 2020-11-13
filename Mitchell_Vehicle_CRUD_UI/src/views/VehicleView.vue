<template>
    <div id="view-vehicles">
        <v-card-title>
        Vehicles 
        <v-spacer></v-spacer>
        <v-flex>
            <v-btn color="warning" @click="getVehicle">
         Get All Vehicles
        </v-btn>
        </v-flex>

        <v-flex>
            <v-btn color ="normal" >New vehicle</v-btn>
        </v-flex>
        
        <v-flex>
            <v-btn color="success" @click="getVehicle">
         Search
        </v-btn>
        </v-flex>
        

        
      </v-card-title>
      <v-data-table
        :headers="headers"
        :items="vehicles"
        :search="search"
        class="elevation-1"
        >
        <template v-slot:item.Controls="props">
           
            
           
                <v-btn @click="showModal(props.item)" alt="Edit">
                    <v-icon dark>mdi-pen</v-icon>
                        
                        </v-btn>
                        <v-btn @click="deleteVehicle(props.item)">
                    <v-icon dark>mdi-heart</v-icon>
                        
                        </v-btn>
        </template>
        </v-data-table>

        <VehicleTableModal v-if="isModalVisible" v-bind:passedVehicle="modalVehicle" @close="closeModal"/>
    </div>
</template>

<script>
import axios from "axios"
import VehicleTableModal from "@/components/VehicleTableModal.vue"
//import { apiURL } from '@/const.js'
export default {
    name: "VehicleManager",
    components:{
        VehicleTableModal
    },
    data: function(){
        return{
            search: '',
            params:{
                make:'',
                model:'',
                year:'',
            },          
            vehicles:[],
            modalVehicle:null,
            isModalVisible:false,
            headers:[
                {
                    text: 'Vehicle Id',
                    align: 'start',
                    value: 'Id'
                },
                {
                    text: 'Make',
                    value: 'Make'
                },
                {
                    text: 'Model',
                    value: 'Model'
                },
                {
                    text: 'Year',
                    value: 'Year'
                },

                {
                    text: '',
                    value: 'Controls'
                },

            ]
            
        };
    },
    methods: {
        async getVehicle(){
            const url = `https://localhost:44396/api/vehicles`
            await axios
            .get(url,this.params)
            .then(response => (this.vehicles = response.data));
        },

        async deleteVehicle(vehicle){
            const url = `https://localhost:44396/api/vehicles/`
            await axios
            .delete(url + vehicle.Id)
            .then(
                response => { if (response.status ==200){
                const deletedIndex = this.vehicles.findIndex(v =>v.Id == vehicle.Id)
                this.vehicles.splice(deletedIndex,1)
                }
                });
            console.log("modal clicked" + vehicle);
           
        },

        showModal(vehicle){
            this.modalVehicle = vehicle;
            this.isModalVisible = true; 
            
        },
        closeModal(){
           
            this.isModalVisible =false;
        },

    }
};
</script>