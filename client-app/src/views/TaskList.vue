<template>
    <div id="tasklist">
        <v-app>
            <v-card>
                <v-card-title>
                    <h1 class="display-1 mx-auto mt-5">Список задач</h1>
                    <v-btn 
                        color=#1B7656
                        dark
                        @click="getTasklists()"
                    >
                        Обновить
                    </v-btn>            
                </v-card-title>
                <v-data-table
                    :headers = "headers"
                    :items = "task"
                    dense
                    :single-select="true"
                    v-model="selectedTask"
                    show-select
                    item-key="id"
                >
                <template v-slot:[`item.buttonDelete`]="{ item }">
                    <span>
                        <v-icon
                            @click="deleteTask(item.id); getTasklists()"
                            color="red"
                        >
                            mdi-delete
                        </v-icon>
                    </span>
                </template>
                <template v-slot:[`item.dateStarted`]="{ item }">
                    <span>{{new Date(item.dateStarted).toLocaleString()}}</span>
                </template>
                <template v-slot:[`item.isImportant`]="{ item }">
                    <span>
                        <div v-if = "item.isImportant==-1">
                            <v-icon color="red">mdi-alert</v-icon>
                        </div>
                        <div v-else></div>
                    </span>
                </template>
                <template v-slot:[`item.text`]="{ item }">
                    <span>
                        <div v-if = "item.isCompleted==-1">
                            <div id="is-complete">
                                {{ item.text }}
                            </div>
                        </div>
                        <div v-else>
                            <div>
                                {{ item.text }}
                            </div>
                        </div>
                    </span>
                </template>
                </v-data-table>
                <v-card-actions>
                    <v-text-field
                        hint="Напишите задачу"
                        v-model="TaskInput"
                    />
                    <v-btn 
                        color=#1B7656
                        dark
                        @click="createTask(TaskInput); getTasklists()"
                    >
                        Добавить задачу
                    </v-btn>  
                </v-card-actions>
            </v-card>
        </v-app>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    methods: {
        async getTasklists() {
            await axios({
                method: 'get',
                url: 'http://localhost:3000/CrudApi/GetTasklists'
            })
                .then(res => this.task = res.data);
        },
        createTask(newText) {
            if (newText != null) {
                axios({
                    method: 'post',
                    url: 'http://localhost:3000/CrudApi/CreateTask', params: {
                        Text: newText
                    }
                })
            }            
        },
        deleteTask(delId) {
            if (delId != null) {
                confirm('Are you sure you want to delete this task?') &&
                axios({
                    method: 'delete',
                    url: 'http://localhost:3000/CrudApi/DeleteTask', params: {
                        Id: delId
                    }
                })
            }            
        }
    },
    data: function() {
        return {
            task: [],
            TaskInput: '',
            selectedTask: [],
            headers: [
                { text: 'Айди задачи', align: 'start', value: 'id' },
                { text: 'Задача', value: 'text' },
                { text: 'Важность', value: 'isImportant' },
                { text: 'Дата начала', value: 'dateStarted' },
                { text: 'Дата завершения', value: 'dateFinished' },
                { text: "", value: "buttonDelete", sortable: false }
            ]
        }        
    },
    created() {
        axios({
            method: 'get',
            url: 'http://localhost:3000/CrudApi/GetTasklists'
        })
            .then(res => this.task = res.data);
    }
}
</script>

<style scoped>
    #tasklist h1 {
        color: #1B7656
    }

    #is-complete {
        text-decoration: line-through;
    }
</style>