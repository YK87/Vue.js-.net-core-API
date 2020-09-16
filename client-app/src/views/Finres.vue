<template>
    <v-app>
    <div id="finres">
        <v-card width="400" class="mx-auto mt-5">
            <v-card-title>
                <h1 class="display-1">Просмотр счетов</h1>
            </v-card-title>
            <v-card-text>
                <v-form>
                    <v-text-field
                        label="Регион" 
                        hint="77, 57, 69 ..."
                        counter="2"
                        :rules = "rules"
                        prepend-icon="mdi-earth"
                        v-model="selectedRegion"
                    />
                    <v-text-field
                        label = "Период"
                        hint = "дата в формате дд/мм/гггг"
                        counter = "10"
                        prepend-icon="mdi-alarm-check"
                        v-model="selectedPeriod"
                    />
                <v-card-actions>
                    <v-btn 
                        color=#1B7656
                        dark
                        @click="getFinres(selectedRegion, selectedPeriod)"
                    >
                        Вывести данные
                    </v-btn>
                </v-card-actions>
                </v-form>
            </v-card-text>
        </v-card>

        <v-card>
            <v-card-title>
                <h1 class="display-1">Счета</h1>
                <v-spacer></v-spacer>
                <v-text-field
                    v-model="search"
                    append-icon="mdi-magnify"
                    label="Search"
                    single-line
                    hide-details
                ></v-text-field>
            </v-card-title>
            <v-data-table
                :headers = "headers"
                :items = "lpu"
                dense
            >
            </v-data-table>
        </v-card>
    </div>
    </v-app>
</template>

<script>
import axios from 'axios'

export default {
    methods: {
        async getFinres(reg, per) {
            await axios({
                method: 'get',
                url: 'http://localhost:3000/MyApi', params: {
                    Reg: reg,
                    Per: per
                }
            })
                .then(res => this.lpu = res.data);
        }
    },
    data: function() {
        return {
            lpu: [],
            selectedRegion: '',
            selectedPeriod: '',
            rules: [v => v.length <= 2 || 'Не более 2-х символов'],
            headers: [
                { text: 'Id', align: 'start', value: 'ID' },
                { text: 'CodeMo', value: 'CODE_MO' },
                { text: 'AccountSum', value: 'SUMV' },
                { text: 'AccountDeduction', value: 'SANK_MEK' }
            ]
        }        
    }
}
</script>

<style scoped>
    #finres h1{
        color: #1B7656;
    }

</style>