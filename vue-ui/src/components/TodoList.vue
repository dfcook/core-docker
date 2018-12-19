<template>
  <v-data-table
    :items="todos"
    :headers="headers"
    hide-actions
    item-key="id"
    class="elevation-1"
  >
    <template
      slot="items"
      slot-scope="props">
      <td class="text-xs-left">{{ props.item.text }}</td>
      <td class="text-xs-right">{{ props.item.isCompleted }}</td>
    </template>
  </v-data-table>
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
  data () {
    return {
      headers: [
        { text: 'Thing to do', value: 'text' },
        { text: 'Completed', value: 'isCompleted' }
      ]
    }
  },
  computed: mapState(['todos']),
  mounted () {
    this.loadTodos()
  },
  methods: mapActions(['loadTodos']),
}
</script>
