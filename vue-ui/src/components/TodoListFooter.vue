<template>
  <v-container 
    px-0
    py-1
  >
    <v-layout align-center>
      <v-flex xs6>
        {{ outstanding }} items outstanding
      </v-flex>
      <v-flex
        xs6
        text-xs-right
      >
        <v-btn
          :class="getButtonClass('ALL')"
          @click="updateFilter('ALL')"
        >
          ALL
        </v-btn>
        <v-btn
          :class="getButtonClass('ACTIVE')"
          @click="updateFilter('ACTIVE')"
        >
          ACTIVE
        </v-btn>
        <v-btn
          :class="getButtonClass('COMPLETED')"
          @click="updateFilter('COMPLETED')"
        >
          COMPLETED
        </v-btn>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  computed: {
    ...mapState([ 'filter' ]),
    ...mapState({
      outstanding: ({ todos }) => todos.filter(t => !t.isCompleted).length
    })
  },
  methods: {
    ...mapActions([ 'updateFilter' ]),
    getButtonClass(btnFilter) {
      return btnFilter === this.filter ? 'primary' : ''
    }
  }
}
</script>

