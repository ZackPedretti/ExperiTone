<script setup lang="ts">
import type {Annotation} from "~/entities/Annotation";

const { t } = useI18n();

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
      <v-col class="pb-0">
        <v-card-title class="pb-0">{{ annotation.title }}</v-card-title>
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
      <v-card-text>{{ annotation.description ?? '' }}</v-card-text>
    </v-row>
    <v-row class="ml-4 mb-1" align="center">
      <v-avatar size="32">
        <img :src="author?.image ?? defaultPicture" alt=""/>
      </v-avatar>
      <v-card-text>{{ author.name }}</v-card-text>
    </v-row>
    <v-card-actions>
      <v-btn class="text-body-2" prepend-icon="mdi-play"> {{ t('song-page.annotation-card.play-btn') }}</v-btn>
    </v-card-actions>
  </v-card>
</template>

<style scoped>
</style>