<template>
  <div class="modal-backdrop">
    <v-flex xs10 md10 lg4 offset-xs1 offset-sm3 offset-md1 offset-lg4>
      <v-card>
        <form>
          <v-card-title primary-title>
            <span>
              <h2>Search Vehicle</h2>
            </span>
          </v-card-title>
          <v-card-text>
            <v-text-field v-model="vehicle.Make" label="Make"></v-text-field>

            <v-text-field v-model="vehicle.Model" label="Model"></v-text-field>

            <v-text-field v-model="vehicle.Year" label="Year"></v-text-field>

            <v-btn class="mr-4" @click="submit"> submit </v-btn>
            <v-btn @click="cancel"> Cancel </v-btn>
          </v-card-text>
        </form>
      </v-card>
    </v-flex>
  </div>
</template>

<script>
export default {
  name: "SearchVehicleModal",

  data: function () {
    return {
      vehicle: {
        Make: "",
        Model: "",
        Year: "",
      },
    };
  },

  methods: {
    //Method to send search vehicle action to Vuex store.js
    async submit() {
      this.$Progress.start()
      await this.$store
        .dispatch("searchVehicle", this.vehicle)
        .then(
          this.$emit("close"),
          this.$Progress.finish())
        .catch((error) => {
          alert(error)
      })
      
    },

    // To close this modal
    cancel() {
      this.$emit("close");
    },
  },
};
</script>

<style scoped>
.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}
.modal {
  background: #ffffff;
  box-shadow: 2px 2px 20px 1px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
}
.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}
.modal-header {
  border-bottom: 1px solid #eeeeee;
  color: #4aae9b;
  justify-content: space-between;
}
.modal-footer {
  border-top: 1px solid #eeeeee;
  justify-content: flex-end;
}
.modal-body {
  position: relative;
  padding: 20px 10px;
}
.btn-close {
  border: none;
  font-size: 20px;
  padding: 20px;
  cursor: pointer;
  font-weight: bold;
  color: #4aae9b;
  background: transparent;
}
.btn-green {
  color: white;
  background: #4aae9b;
  border: 1px solid #4aae9b;
  border-radius: 2px;
}
.modal-fade-enter,
.modal-fade-leave-active {
  opacity: 0;
}
.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.5s ease;
}
</style>