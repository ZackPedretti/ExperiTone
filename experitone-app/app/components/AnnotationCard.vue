<script setup lang="ts">
import type {Annotation} from "~/entities/Annotation";
import type {Song} from "~/entities/Song";

const props = defineProps<{
  annotation: Annotation,
}
>()

const author = await $fetch<{name: string, image: string}>(`/api/users/get-by-id?userId=${props.annotation.authorId}`)
const defaultPicture = "/img/default.png"
</script>

<template>
  <v-card flat>
    <v-row class="w-100" align="center" justify="space-between">
      <v-col>
        <v-card-title>{{ annotation.title }}</v-card-title>
        <v-card-text class="pb-0">{{ annotation.description ?? '' }}</v-card-text>
      </v-col>
      <v-col>
        <v-row align="center">
          <v-btn class="rounded-full mx-2" flat>
            <v-icon>mdi-thumb-up</v-icon>
          </v-btn>

          <p>{{ annotation.votes }}</p>

          <v-btn class="rounded-full mx-2" flat>
            <v-icon>mdi-thumb-down</v-icon>
          </v-btn>
        </v-row>
      </v-col>
    </v-row>
    <v-row class="ml-4 mb-4" align="center">
      <v-avatar size="32">
        <img :src="author?.image ?? defaultPicture" alt=""/>
      </v-avatar>
      <v-card-text>{{ author.name }}</v-card-text>
    </v-row>
    <v-card-actions>

    </v-card-actions>
  </v-card>
</template>

<style scoped>
</style>