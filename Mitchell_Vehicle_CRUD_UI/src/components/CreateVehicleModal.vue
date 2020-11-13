<template>
  <div class="modal-backdrop">
    <v-flex xs10 md10 lg4 offset-xs1 offset-sm3 offset-md1 offset-lg4>
      <v-card>
        <form>
          <v-card-title primary-title>
            <span>
              <h2>Create Vehicle</h2>
            </span>
          </v-card-title>
          <v-card-text>
            <v-text-field
              v-model="vehicle.Make"
              :error-messages="makeErrors"
              label="Make"
              required
              @input="$v.vehicle.Make.$touch()"
              @blur="$v.vehicle.Make.$touch()"
            ></v-text-field>

            <v-text-field
              v-model="vehicle.Model"
              :error-messages="modelErrors"
              label="Model"
              required
              @input="$v.vehicle.Model.$touch()"
              @blur="$v.vehicle.Model.$touch()"
            ></v-text-field>

            <v-text-field
              v-model="vehicle.Year"
              :error-messages="yearErrors"
              label="Year"
              required
              @input="$v.vehicle.Year.$touch()"
              @blur="$v.vehicle.Year.$touch()"
            ></v-text-field>

            <v-btn class="mr-4" @click="submit"> submit </v-btn>
            <v-btn @click="cancel"> Cancel </v-btn>
          </v-card-text>
        </form>
      </v-card>
    </v-flex>
  </div>
</template>

<script>
import { validationMixin } from "vuelidate";
import { required, between } from "vuelidate/lib/validators";
export default {
  name: "CreateVehicleModal",
  mixins: [validationMixin],
  // Define validations for empty Make, empty Model, empty and range of Year
  validations: {
    vehicle: {
      Make: { required },
      Model: { required },
      Year: { required, between: between(1950, 2050) },
    },
  },

  data: function () {
    return {
      vehicle: {
        Make: "",
        Model: "",
        Year: "",
      },
    };
  },

  computed: {
    // Error checking for empty Make
    makeErrors() {
      const errors = [];
      if (!this.$v.vehicle.Make.$dirty) return errors;
      !this.$v.vehicle.Make.required && errors.push("Make is required.");
      return errors;
    },

    // Error checking for empty model
    modelErrors() {
      const errors = [];
      if (!this.$v.vehicle.Model.$dirty) return errors;
      !this.$v.vehicle.Model.required && errors.push("Model is required.");
      return errors;
    },

    // Error checking for empty year and range of year allowed
    yearErrors() {
      const errors = [];
      if (!this.$v.vehicle.Year.$dirty) return errors;
      !this.$v.vehicle.Year.required && errors.push("Year is required");
      !this.$v.vehicle.Year.between &&
        errors.push("Year has to be between 1950 and 2050");
      return errors;
    },
  },

  methods: {
    // Method to dispatch create new vehicle command to Vuex store.js
    async submit() {
      this.$v.$touch();
      if (!this.$v.$invalid) {
        this.$Progress.start()
       await this.$store
          .dispatch("createVehicle", this.vehicle)
          .then(
              this.$Progress.finish(),
              this.$emit("close"))
          .catch((error) => {
            alert(error);
          });
      }
    },

    // To close the modal
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