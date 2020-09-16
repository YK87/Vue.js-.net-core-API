<template>
    <div id="finres">
        <h1>Просмотр счетов</h1>
        <table align="left">
            <tr>
                <td align="left">
                    <label>Регион</label>
                </td>
                <td align="right">
                    <select v-model="selectedRegion">
                        <option disabled value="">Выберите регион</option>
                        <option>77</option>
                        <option>50</option>
                    </select>
                </td>
                <td>                    
                    <p>{{ getRegion(selectedRegion) }}</p>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <label>Период</label>
                </td>
                <td align="right">
                    <select v-model="selectedPeriod">
                        <option disabled value="">Выберите период</option>
                        <option>01/01/2020</option>
                        <option>01/02/2020</option>
                        <option>01/03/2020</option>
                        <option>01/04/2020</option>
                        <option>01/05/2020</option>
                        <option>01/06/2020</option>
                        <option>01/07/2020</option>
                        <option>01/08/2020</option>
                    </select>
                </td>
                <td>
                    <p>{{ getPeriod(selectedPeriod) }}</p>
                </td>
            </tr>
            <tr>
                <td id='btn' @click="getFinres(selectedRegion, selectedPeriod)">Вывести данные</td>
            </tr>

        </table>

        <table align="center">
            <tr>
                <td align="center" >Id</td>
                <td align="center">CodeMo</td>
                <td align="center">AccountSum</td>
                <td align="center">AccountDeduction</td>
            </tr>
            <tr v-for="l in lpu" :key="l.id">
                <td align="center">{{ l.ID }}</td>
                <td align="center">{{ l.CODE_MO }}</td>
                <td align="right">{{ l.SUMMAV }}</td>
                <td align="right">{{ l.SANK_MEK }}</td>
            </tr>
        </table>
    </div>

</template>

<script>
import axios from 'axios'

export default {
    methods: {
        async getFinres(reg, per) {
            console.log(reg, per);
            await axios({
                method: 'get',
                url: 'http://localhost:3000/MyApi', params: {
                    Reg: reg,
                    Per: per
                }
            })
                .then(res => this.lpu = res.data)
        },
        getRegion: function(curRegion) {
            if(curRegion == 77) {
                return "Москва"
            }
            else if(curRegion == 50) {
                return "Московская область"
            }
            else {
                return "Выберите регион"
            }
        },
        getPeriod: function(curPeriod) {
            if(curPeriod != null) {
                return curPeriod
            }           
            else {
                return "Выберите период"
            }
        }
    },
    data: function() {
        return {
            lpu: [],
            selectedRegion: 'Выберите регион',
            selectedPeriod: 'Выберите период'
        }
    }
}
</script>

<style scoped>
    #finres {
        padding: 10px;
    }
    #finres h1{
        color: #1B7656;
    }
    #finres label{
        color: #1B7656;
    }

    #finres table {
        border-style: groove;
        border-color: #1B7656;
    }

    #btn {
    font-family: "Roboto";
    border: none;
    background: #1B7656;
    color: #fff;
    padding: 10px;
    cursor: pointer;
    font-size: medium;
    text-decoration: none;
  }

  #tr {
      border-style: groove;
      border-color: #1B7656;
  }
</style>