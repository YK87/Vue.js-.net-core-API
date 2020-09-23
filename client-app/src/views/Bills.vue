<template>
    <v-app>
    <div id="bills">
        <v-card 
            width="400" 
            class="mx-auto mt-5"
            elevation="0"    
        >
            <v-card-title>
                <h1 class="display-1">Просмотр счетов</h1>
            </v-card-title>
            <v-card-text>
                <v-form>
                    <v-text-field
                        label="Регион"
                        type="number" 
                        hint="77, 57, 69 ..."
                        counter="2"
                        :rules = "rules"
                        prepend-icon="mdi-earth"
                        v-model="selectedRegion"
                    />
                    <v-text-field
                        label = "Период"
                        type="datetime-local"
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
                url: 'http://localhost:3000/MyApi/GetBills', params: {
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
                { text: 'Айди счета', align: 'start', value: 'id' },
                { text: 'Год', value: 'year' },
                { text: 'Месяц', value: 'month' },
                { text: 'Айди региона', value: 'regionId' },
                { text: 'Регион', value: 'regionName' },
                { text: 'Айди компании', value: 'companyId' },
                { text: 'Компания', value: 'companyName' },
                { text: 'Код МО', value: 'codeMo' },
                { text: 'Наименование МО', value: 'moName' },
                { text: 'Сумма счета', value: 'accountSum' },
                { text: 'Удержанная сумма', value: 'accountDeduction' }
            ]
        }        
    }
}
</script>

<style scoped>
    #bills h1{
        color: #1B7656;
    }

</style>