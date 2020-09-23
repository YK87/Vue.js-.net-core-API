<template>
    <v-app>
        <div id="finres">
            <v-card 
                class="mx-auto mt-5"
                elevation="0" 
                width="95%"
            >
                <v-card-title>
                    <h1 class="display-1 mx-auto">Финансовый результат</h1>
                </v-card-title>
            <v-card-text>
                <v-simple-table>
                    <v-row>
                        <v-col>
                            <v-autocomplete
                                label="Регион"
                                prepend-icon="mdi-earth"
                                v-model="selectedRegion"
                                placeholder="Введите номер или название региона"
                                :items="regions"
                                search-input.sync
                                item-text="regionName"
                                item-value="regionid"
                                hide-no-data
                            />
                        </v-col>
                        <v-col>
                            <v-autocomplete
                                label="Компания"
                                prepend-icon="mdi-clipboard"
                                v-model="selectedCompany"
                                placeholder="Введите номер или название компании"
                                :items="companies"
                                search-input.sync
                                item-text="companyName"
                                item-value="companyid"
                                hide-no-data
                            />
                        </v-col>
                        <v-col>
                            <v-autocomplete
                                label = "Период"
                                prepend-icon="mdi-alarm-check"
                                v-model="selectedPeriod"
                                placeholder="Введите период"
                                :items="periods"
                                search-input.sync
                                item-text="period"
                                item-value="period"
                                hide-no-data
                            />
                        </v-col>                         
                    </v-row>
                </v-simple-table>
                <v-card-actions>
                    <v-btn 
                        color=#1B7656
                        dark
                        @click="getHeaders(selectedRegion); getStates(selectedCompany, selectedRegion, selectedPeriod)"
                    >
                        Вывести данные
                    </v-btn>
                </v-card-actions>
            </v-card-text>
        </v-card>
            <v-card>
                <v-card-title>
                    <v-spacer></v-spacer>
                    <v-text-field
                        v-model="search"
                        append-icon="mdi-magnify"
                        label="Поиск"
                        single-line
                        hide-details
                    ></v-text-field>
                </v-card-title>
                <v-data-table
                    :headers = "headers"
                    :items = "lpu"
                     :search="search"
                    dense
                >
                <template v-slot:[`item.actions`]="{ item }">
                    <v-icon
                        small
                        class="mr-2"
                        @click="editItem(item)"
                    >
                        mdi-pencil {{ item.id }}
                    </v-icon>
                </template>
                </v-data-table>
            </v-card>
            <v-dialog
                v-model="dialog"
                max-width="70%"
                >
                <v-card>
                    <v-card-title>
                        <div class="mx-auto" style="color:#1B7656;">
                            {{ editedItem.NAME }}
                        </div>   
                    </v-card-title>
                    <v-card-text>
                        <div v-for="head in headers" :key="head.value">
                            <div v-if="head.value!=='actions' && head.value!=='IDMO' && head.value!=='CODE_UR' && head.value!=='NAME'">
                                <v-text-field 
                                    :label=head.text
                                    dense
                                ></v-text-field>
                            </div>
                        </div>                       
                    </v-card-text>
                    <v-card-actions>
                    <v-btn
                        color= #1B7656
                        dark
                        class="mx-auto"
                        @click="dialog = false"
                    >
                        Круто!
                    </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </div> 
    </v-app>      
</template>

<script>
import axios from 'axios'

export default {
    methods: {
        async getHeaders(Reg) {
            let region = Reg.substring(0, Reg.indexOf("-"));
            await axios({
                method: 'get',
                url: 'http://localhost:3000/Finres/getHeader', params: {
                    reg: region
                }
            })
            .then(res => this.headers = [...this.headers, ...res.data]);
        },
        async getStates(Comp, Reg, Per) {
            let region = Reg.substring(0, Reg.indexOf("-"));
            let company = Comp.substring(0, 1);
            await axios({
                method: 'get',
                url: 'http://localhost:3000/Finres/getStates77', params: {
                    comp: company,
                    reg: region,
                    per: Per
                }
            })
            .then(res => {               
                this.lpu = res.data;
                for(var i = 0; i < this.lpu.length; i++){ 
                    for (var key in this.lpu[i]) {
                        if(key.toUpperCase() !== key){
                            this.lpu[i][key.toUpperCase()] = this.lpu[i][key];
                            delete this.lpu[i][key];
                        }
                    }
                }
            })      
        },
        editItem (item) {
            this.editedIndex = this.lpu.indexOf(item)
            this.editedItem = Object.assign({}, item)
            this.dialog = true
        }
    },
    data: function() {
        return {
            lpu: [],
            headers: [
                { text: 'Редактировать', value: 'actions', sortable: false },
                { text: 'Код МО', value: 'IDMO' },
                { text: 'Местный код', value: 'CODE_UR' },
                { text: 'Наименование МО', value: 'NAME' }
            ],
            selectedRegion: '',
            selectedPeriod: '',
            selectedCompany: '',
            regions: [],
            companies: [],
            periods: [],
            search: '',
            dialog: false,
            editedItem: {
                NAME: ''
            }
        }
    },
    created() {
        axios({
            method: 'get',
            url: 'http://localhost:3000/Finres/getRegions'
        })
            .then(res => this.regions = res.data);
        
        axios({
            method: 'get',
            url: 'http://localhost:3000/Finres/getCompanies'
        })
            .then(res => this.companies = res.data);
        
        axios({
            method: 'get',
            url: 'http://localhost:3000/Finres/getPeriods'
        })
            .then(res => this.periods = res.data);
    }
}
</script>

<style scoped>
    #finres h1 {
        color: #1B7656;
    }
</style>