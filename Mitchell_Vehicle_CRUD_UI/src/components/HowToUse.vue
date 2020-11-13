<template>
  <div>
    <div class="modal-backdrop">
      <v-flex lg4>
        <v-card>
          <v-card-title primary-title>
            <span>
              <h2>HOW TO USE</h2>
            </span>
          </v-card-title>
          <v-card-text>
            <p>
              - In .en.development file in root of this project folder, please
              change the VUE_APP_API_URL to your backend server ip address.
            </p>
            <p>
              -Backend database is made by Code First approach. Everytime
              backend server restarts, the database will be dropped and
              populated with some initial data.
            </p>
            <p>- You can skip the data seeding by going to VS Project - Data_Access - VehicleContext.cs and comment out
              Database.SetInitializer(new VehicleDBInitializer());
            <p>
              - It will take awhile to load all vehicle at first time . - Search feature will return
              all data if none of paramater is given
            </p>

            <v-btn color="info" @click="close"> Close </v-btn>
          </v-card-text>
        </v-card>
      </v-flex>
    </div>
  </div>
</template>
 

<script>
export default {
  name: "HowToUSe",
  methods: {
    close() {
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