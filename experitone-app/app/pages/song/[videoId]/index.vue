<script setup lang="ts">
import type { Annotation } from "~/entities/Annotation";

const route = useRoute()
const videoId = route.params.videoId as string

const annotations = ref<Annotation[]>([])

onMounted(async () => {
  annotations.value = await $fetch<Annotation[]>(`/api/annotations/get-annotations-of-song?videoId=${videoId}`)
})
</script>

<template>
<p v-for="annotation in annotations" :key="annotation.annotationId">{{ annotation }}</p>
</template>

<style scoped>

</style>