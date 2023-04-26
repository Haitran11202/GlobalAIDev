<template>
  <div class="border border-gray-400 rounded-md my-2">
    <div
      :editor="editor"
      v-if="editor"
      class="flex flex-row space-x-2 border-b border-b-gray-400 p-2 text-gray-500"
    >
      <button @click.prevent="() => editor?.chain().focus().toggleBold().run()">
        <font-awesome-icon :icon="['fas', 'bold']" />
      </button>
      <button
        @click.prevent="() => editor?.chain().focus().toggleItalic().run()"
      >
        <font-awesome-icon :icon="['fas', 'italic']" />
      </button>

      <button
        :class="{ 'font-bold': editor?.isActive('strike') }"
        @click.prevent="editor?.chain().focus().toggleStrike().run()"
      >
        <font-awesome-icon :icon="['fas', 'strikethrough']" />
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('code') }"
        @click.prevent="editor?.chain().focus().toggleCode().run()"
      >
        <font-awesome-icon :icon="['fas', 'code']" />
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('paragraph') }"
        @click.prevent="editor?.chain().focus().setParagraph().run()"
      >
        <font-awesome-icon :icon="['fas', 'paragraph']" />
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('heading', { level: 1 }) }"
        size="small"
        @click.prevent="
          editor?.chain().focus().toggleHeading({ level: 1 }).run()
        "
      >
        H1
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('heading', { level: 2 }) }"
        @click.prevent="
          editor?.chain().focus().toggleHeading({ level: 2 }).run()
        "
      >
        H2
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('heading', { level: 3 }) }"
        @click.prevent="
          editor?.chain().focus().toggleHeading({ level: 3 }).run()
        "
      >
        H3
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('blockquote') }"
        @click.prevent="editor?.chain().focus().toggleBlockquote().run()"
      >
        <font-awesome-icon :icon="['fas', 'quote-left']" />
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('blockquote') }"
        @click.prevent="toggleHTML()"
      >
        HTML
      </button>

      <button
        :class="{ 'is-active': editor?.isActive('bulletList') }"
        @click.prevent="editor?.chain().focus().toggleBulletList().run()"
      >
        <font-awesome-icon :icon="['fas', 'list']" />
      </button>

      <button @click.prevent="showImageModal()">
        <font-awesome-icon :icon="['fas', 'image']" />
      </button>

      <button @click.prevent="editor?.chain().focus().undo().run()">
        <font-awesome-icon :icon="['fas', 'undo']" />
      </button>

      <button @click.prevent="editor?.chain().focus().redo().run()">
        <font-awesome-icon :icon="['fas', 'redo']" />
      </button>
    </div>
    <div class="p-2 text-gray-950 overflow-y-auto max-h-40">
      <EditorContent :editor="editor" />
    </div>
    <ImageModalVue
      name="imageModal"
      @upload-image-success="(data) => uploadImageSuccess(data)"
    />
  </div>
</template>

<script setup>
import { ref } from "vue";
import { useEditor, EditorContent, FloatingMenu } from "@tiptap/vue-3";
import { Editor, Extension } from "@tiptap/core";
import Blockquote from "@tiptap/extension-blockquote";
import Document from "@tiptap/extension-document";
import Paragraph from "@tiptap/extension-paragraph";
import Text from "@tiptap/extension-text";
import StarterKit from "@tiptap/starter-kit";
import Image from "@tiptap/extension-image";
import ImageModalVue from "./ImageModal.vue";
import { $vfm } from "vue-final-modal";

const props = defineProps({
  modelValue: {
    type: String,
    default: "",
  },
});

const emits = defineEmits(["update:modelValue"]);
const config = useRuntimeConfig();

const editor = useEditor({
  extensions: [StarterKit, Document, Text, Paragraph, Blockquote, Image],
  content: props.modelValue,
  onUpdate: () => {
    emits("update:modelValue", editor.value?.getHTML());
    // emits("update:modelValue", editor.value?.getText());
  },
});

watch(
  () => props.modelValue,
  (value) => {
    // HTML
    // const isSame = editor.value?.getHTML() === value;
    const isSame = editor.value?.getText() === value;

    // JSON
    // const isSame = JSON.stringify(this.editor.getJSON()) === JSON.stringify(value)

    if (isSame) {
      return;
    }

    editor.value?.commands.setContent(value, false);
  }
);

const showImageModal = () => {
  $vfm.show("imageModal");
};

const toggleHTML = () => {
  const html = editor.value?.getHTML();
  const text = editor.value?.getText();
  console.log(html, text);

  // if (text != html) {
   editor.value?.commands.setContent('<code><h1>1223432432</h1></code>'); 
  // }

}

const uploadImageSuccess = (data) => {
  const baseUrl = config.public.apiEndpoint;
  editor.value.commands.setImage({
    src: `${baseUrl}/${data}`,
  });
  $vfm.hide("imageModal");
};
</script>

<style lang="scss" scoped>
:deep(.ProseMirror) {
  outline: none;

  > * + * {
    margin-top: 0.75em;
  }

  code {
    background-color: rgba(#616161, 0.1);
    color: #616161;
  }

  ul {
    padding: 0 1rem;
    list-style: disc !important;
  }

  ol {
    padding: 0 1rem;
    list-style: decimal !important;
  }

  h1 {
    display: block;
    font-size: 2em;
    margin-top: 0.67em;
    margin-bottom: 0.67em;
    margin-left: 0;
    margin-right: 0;
    font-weight: bold;
  }

  h2 {
    display: block;
    font-size: 1.5em;
    margin-top: 0.83em;
    margin-bottom: 0.83em;
    margin-left: 0;
    margin-right: 0;
    font-weight: bold;
  }

  h3 {
    display: block;
    font-size: 1.17em;
    margin-top: 1em;
    margin-bottom: 1em;
    margin-left: 0;
    margin-right: 0;
    font-weight: bold;
  }

  img {
    width: 100px;
  }
}

:deep(.ProseMirror:focus) {
  outline: none;
}
</style>
