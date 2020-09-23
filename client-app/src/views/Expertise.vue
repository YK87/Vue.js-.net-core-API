<template>
    <v-app>
        <div id="expertise">
            <v-card 
                width="500" 
                elevation="10" 
                shaped="true" 
                class="mx-auto mt-5"
            >
                <v-card-title>
                    <h1 class="display-1">Экспертиза</h1>              
                </v-card-title>
            <v-img 
                width="800"
                max-height="300" 
                src="../assets/under_construction.jpg"
                class="mx-auto"
            />
                <v-card-actions>
                    <v-btn
                        color=#1B7656
                        dark
                        class="mx-auto"
                        to="/features"
                    >
                        Go back
                    </v-btn>
                </v-card-actions>            
            </v-card>
        </div>
    </v-app>      
</template>

<script>
export default {
    
}
</script>

<style scoped>
    #expertise {
        padding: 1rem;
    }
    #expertise h1{
        color: #1B7656;
    }
</style>