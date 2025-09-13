<script setup lang="ts">
import type {Annotation} from "~~/entities/Annotation";
import AnnotationCard from "~/components/AnnotationCard.vue";
import type {PutAnnotation} from "~~/entities/PutAnnotation";

const route = useRoute()
const videoId = route.params.videoId as string

const annotations = ref<Annotation[]>([])

const { t } = useI18n();

const exampleAnnotation: PutAnnotation = {
  startTimestamp: 128,
  title: 'TEST ANNOTATION',
  description: 'THIS IS A TEST',
  endTimestamp: undefined,
};

function putAnnotation(annotation: PutAnnotation) {
  $fetch(`/api/annotations/${videoId}`, {
    method: 'PUT',
    body: annotation,
  })
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
            <AnnotationCard :annotation="annotation" class="pa-2" />
            <v-divider v-if="index < annotations.length -1" />
          </v-list-item>
        </v-list>
        <v-btn prepend-icon="mdi-plus" color="primary" flat @click="putAnnotation(exampleAnnotation)">{{ t("song-page.add-btn") }}</v-btn>
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
</style>
