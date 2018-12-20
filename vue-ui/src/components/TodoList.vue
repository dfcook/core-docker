<template>
  <v-data-table
    :items="filteredTodos"
    :headers="headers"
    hide-actions
    item-key="id"
    class="elevation-1"
  >
    <template
      slot="items"
      slot-scope="props">
      <td class="text-xs-center">
        <input
          :checked="props.item.isCompleted"
          type="checkbox"
          @click="toggleTodo(props.item)"
        >
      </td>
      <td
        :class="{ completed: props.item.isCompleted }"
        class="text-xs-left"
      >
        <span class="font-weight-bold">{{ props.index + 1 }}.</span>
        {{ props.item.text }}
      </td>
      <td class="text-xs-right">
        <v-btn @click="deleteTodo(props.item.id)">Delete</v-btn>
      </td>
    </template>
    <template slot="footer">
      <td colspan="3">
        <TodoListFooter />
      </td>
    </template>
  </v-data-table>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import TodoListFooter from './TodoListFooter'

export default {
  components: { TodoListFooter },
  data () {
    return {
      headers: [
        { width: '10%', sortable: false, value: 'isCompleted' },
        { text: 'Thing to do', value: 'text' },
        { width: '10%' }
      ]
    }
  },
  computed: mapState({
    filteredTodos: ({ filter, todos }) => {
      switch (filter) {
        case 'ACTIVE':
          return todos.filter(todo => !todo.isCompleted)
        case 'COMPLETED':
          return todos.filter(todo => todo.isCompleted)
        default:
          return todos
      }
    }
  }),
  mounted () {
    this.loadTodos()
  },
  methods: {
    ...mapActions(['loadTodos', 'deleteTodo', 'updateTodo']),
    toggleTodo (todo) {
      const updated = {
        ...todo,
        isCompleted: !todo.isCompleted
      }

      this.updateTodo(updated)
    }
  }
}
</script>

<style scoped>
  .completed {
    text-decoration: line-through;
  }
</style>

