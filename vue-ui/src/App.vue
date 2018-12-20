<template>
  <v-app id="app">
    <v-container
      justify-center
      align-center
    >
      <v-layout>
        <v-flex
          xs12
          text-xs-center>
          <h1>Things To Do</h1>
        </v-flex>
      </v-layout>
      <v-layout>
        <v-flex xs12>
          <TodoForm />
        </v-flex>
      </v-layout>
      <v-layout>
        <v-flex xs12>
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

<style scoped>
h1 {
  width: 100%;
  font-size: 70px;
  font-weight: bold;
  text-align: center;
  margin-top: 100px;
  color: #b3b3b3;
  text-shadow: -1px -1px rgba(0, 0, 0, 0.2);
}

#app {
  background-color: #eaeaea;
}
</style>
