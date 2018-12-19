<template>
  <v-app id="app">
    <v-container>
      <v-layout>
        <v-flex 
          xs8 
          offset-xs2 
          text-xs-center>
          <h1>Things To Do</h1>
        </v-flex>
      </v-layout>
      <v-layout>
        <v-flex 
          xs8 
          offset-xs2>
          <TodoForm />
        </v-flex>
      </v-layout>
      <v-layout>
        <v-flex 
          xs8 
          offset-xs2>
          <TodoList />
        </v-flex>
      </v-layout>
    </v-container>
  </v-app>
</template>

<script>
import TodoList from './components/TodoList'
import TodoForm from './components/TodoForm'

export default {
  name: 'App',
  components: {
    TodoForm,
    TodoList
  }
}
</script>
