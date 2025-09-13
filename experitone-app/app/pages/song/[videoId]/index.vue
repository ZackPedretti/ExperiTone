<script setup lang="ts">
import type {Annotation} from "~~/entities/Annotation";
import AnnotationCard from "~/components/AnnotationCard.vue";
import {newPutAnnotation, type PutAnnotation} from "~~/entities/PutAnnotation";
import NewAnnotationCard from "~/components/NewAnnotationCard.vue";

const route = useRoute()
const videoId = route.params.videoId as string
const annotations = ref<Annotation[]>([])
const newAnnotations = ref<PutAnnotation[]>([])

const {t} = useI18n();

function putAnnotation(annotation: PutAnnotation) {
  $fetch(`/api/annotations/${videoId}`, {
    method: 'PUT',
    body: annotation,
  })
}

function openNewAnnotation() {
  newAnnotations.value.push(newPutAnnotation(undefined))
}

onMounted(async () => {
  console.log(await $fetch<Annotation[]>(`/api/annotations/${videoId}`))
  annotations.value = (await $fetch<Annotation[]>(`/api/annotations/${videoId}`)).sort((a, b) => a.startTimestamp - b.startTimestamp)
})
</script>

<template>
  <div class="main-container">
    <YoutubePlayer :videoId="videoId" class="video-col"/>

    <div class="annotation-col">
      <div class="inner-annotation-container">
        <v-list>
          <v-list-item
              v-for="(annotation, index) in annotations"
              :key="annotation.annotationId"
          >
            <AnnotationCard :annotation="annotation" class="pa-2"/>
            <v-divider v-if="index < annotations.length -1"/>
          </v-list-item>
          <v-list-item
              v-for="(newAnnotation, index) in newAnnotations"
              :key="'new' + index"
              class="new-annotation">
            <v-divider/>
            <NewAnnotationCard :annotation="newAnnotation" class="pa-2"/>
          </v-list-item>
        </v-list>
        <v-btn prepend-icon="mdi-plus" color="primary" flat @click="openNewAnnotation">{{
            t("song-page.add-btn")
          }}
        </v-btn>
      </div>
    </div>
  </div>
</template>

<style scoped>
.main-container {
  display: flex;
  gap: 16px;
  overflow: hidden;
  max-height: 70vh;
}

.video-col {
  flex: 2.5;
  min-width: 0;
}

.annotation-col {
  flex: 1;
  min-width: 250px;
  max-width: 600px;
  overflow-y: auto;
  border-left: 1px solid #ddd;
  max-height: 100%;
  padding: 8px;
}

.inner-annotation-container {
  display: flex;
  flex-direction: column;
  height: 100%;
  justify-content: space-between;
}

.new-annotation {
}
</style>
