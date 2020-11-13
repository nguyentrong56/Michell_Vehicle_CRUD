<template>
    <div>
        <form>
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

            <v-btn
            class="mr-4"
            @click="submit"
             >
             submit
            </v-btn>
            <v-btn @click="clear">
            clear
             </v-btn>
                
        </form>

    </div>
</template>

<script>
import axios from 'axios'
import {validationMixin} from 'vuelidate'
import {required,between}  from "vuelidate/lib/validators"
export default {
    name:"CreateVehicle",
    mixins:[validationMixin],
    validations: {
        vehicle:{
            Make: {required},
            Model:{required},
            Year:{required, between:between(1950,2050)},

        }
    },

    data:function(){
        return{
            vehicle:{
                Make: "",
                Model:"",
                Year:""
            }
        };
    },

    computed: {
        makeErrors(){
            const errors = []
            if(!this.$v.vehicle.Make.$dirty) return errors
            !this.$v.vehicle.Make.required && errors.push('Make is required.')
            return errors
        },

        modelErrors(){
            const errors = []
            if(!this.$v.vehicle.Model.$dirty) return errors
            !this.$v.vehicle.Model.required && errors.push('Model is required.')
            return errors
        },

        yearErrors(){
            const errors = []
            if(!this.$v.vehicle.Year.$dirty) return errors
            !this.$v.vehicle.Year.required && errors.push('Year is required')
            !this.$v.vehicle.Year.between && errors.push("Year has to be between 1950 and 2050")
            return errors
        },

    },

    methods:{
        async submit(){
            const url = `https://localhost:44396/api/vehicles`
        
            await axios
            .post(url, this.vehicle )
            .then(response => alert(response.data))
            .catch(err =>alert(err.response.data) )
        },
        clear() {
            this.$v.$reset()
            this.vehicle.Make =''
            this.vehicle.Model=''
            this.vehicle.Year=''
        }

        
    }



}
</script>