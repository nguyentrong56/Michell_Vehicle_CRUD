<template>
  <div id="view-vehicles">
    <v-card-title>
      Vehicles
      <v-spacer></v-spacer>
      <v-flex>
        <v-btn color="warning" @click="getVehicle"> Get All Vehicles </v-btn>
      </v-flex>

      <v-flex>
        <v-btn color="normal" @click="showCreateVehicleModal"
          >Create New vehicle</v-btn
        >
      </v-flex>

      <v-flex>
        <v-btn color="success" @click="showSearchVehicleModal"> Search </v-btn>
      </v-flex>
    </v-card-title>
       

    <v-data-table
      :headers="headers"
      :items="vehicles"
      class="elevation-1"
    >
      <template v-slot:item.Controls="props">
        <v-btn @click="showVehicleInfoModal(props.item)" alt="Edit">
          <v-icon dark>mdi-pen</v-icon>
        </v-btn>
        <v-btn @click="deleteVehicle(props.item)">
          <v-icon dark>mdi-delete</v-icon>
        </v-btn>
      </template>
    </v-data-table>

    <VehicleTableModal
      v-if="isModalVehicleInfoVisible"
      v-bind:passedVehicle="selectedVehicle"
      @close="closeModal"
    />
    <CreateVehicleModal
      v-if="isModalCreateVehicleVisible"
      @close="closeModal"
    />
    <SearchVehicleModal
      v-if="isModalSearchVehicleVisible"
      @close="closeModal"
    />
    
  </div>
</template>

<script>
import VehicleTableModal from "@/components/VehicleTableModal.vue";
import CreateVehicleModal from "@/components/CreateVehicleModal.vue";
import SearchVehicleModal from "@/components/SearchModal.vue";


import { mapState } from "vuex";
//import { apiURL } from '@/const.js'
export default {
  name: "VehicleManager",
  components: {
    VehicleTableModal,
    CreateVehicleModal,
    SearchVehicleModal,
    
  },

  data: function () {
    return {
      // to store selected vehicle which later passed into VehicleTableModal
      selectedVehicle: "",
      //for loading bard
      loading: false,

       // bool values used to switch modals on/off
      isModalVehicleInfoVisible: false,
      isModalCreateVehicleVisible: false,
      isModalSearchVehicleVisible: false,


      headers: [
        {
          text: "Vehicle Id",
          align: "start",
          value: "Id",
        },
        {
          text: "Make",
          value: "Make",
        },
        {
          text: "Model",
          value: "Model",
        },
        {
          text: "Year",
          value: "Year",
        },

        {
          text: "",
          value: "Controls",
        },
      ],
    };
  },

  computed: mapState(["vehicles"]),

  methods: {
    //Method to send getVehicle action to Vuex store
    async getVehicle() {
      this.$Progress.start();
      await this.$store.dispatch("getVehicles")
      .catch((error) => {
          alert(error)
      })
       this.$Progress.finish()
    },

    //Method to send deleteVehicle action to Vuex store    
    async deleteVehicle(vehicle) {
      this.$Progress.start()
      await this.$store.dispatch("deleteVehicle", vehicle)
      .then( this.$Progress.finish())
      .catch((error) => {
          alert(error)
      })
     
    },

    //Method to switch on VehicleInfoModal
    showVehicleInfoModal(vehicle) {
      this.selectedVehicle = vehicle;
      this.isModalVehicleInfoVisible = true;
    },

    //Method to switch on eate
    showCreateVehicleModal() {
      this.isModalCreateVehicleVisible = true;
    },

    //Method to switch on CreateVehicle modal 
    showSearchVehicleModal() {
      this.isModalSearchVehicleVisible = true;
    },
    

    //To close modals
    closeModal() {
      this.isModalSearchVehicleVisible = false;
      this.isModalCreateVehicleVisible = false,
      this.isModalVehicleInfoVisible = false ;
    },
  },
};
</script>