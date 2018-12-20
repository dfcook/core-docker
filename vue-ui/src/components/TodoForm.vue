<template>
  <v-text-field
    v-model="todo"
    label="What needs to be done?"
    @keyup="onKeyUp"
  />
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
    onKeyUp (e) {
      if (e.key === 'Enter') {
        this.addTodo(this.todo);
        this.todo = '';
      }
    }
  }
}
</script>

