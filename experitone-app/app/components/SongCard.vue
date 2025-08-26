<script setup lang="ts">
import type { Song } from "~/entities/Song";

defineProps<{
  song: Song
}>()
</script>

<template>
<p>{{ song }}</p>
</template>

<style scoped>

</style>