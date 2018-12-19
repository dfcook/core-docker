<template>
  <v-form 
    v-model="valid" 
    prevent-default>
    <v-text-field
      v-model="todo"
      label="Thing to do"
    />
    <v-btn @click="submit">Create</v-btn>
  </v-form>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  data () {
    return {
      valid: true,
      todo: ''
    }
  },
  methods: {
    ...mapActions(['addTodo']),
    submit () {
      this.addTodo(this.todo)
    }
  }
}
</script>

