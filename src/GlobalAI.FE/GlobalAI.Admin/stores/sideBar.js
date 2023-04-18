import { defineStore } from "pinia";

export const useSideBarStorage = defineStore("sideBar", {
  state: () => ({
    showSideBar: true,
  }),
  getters: {
    getShowSideBar: (state) => state.showSideBar,
  },
  actions: {
    changeShowSideBar(payload) {
      this.showSideBar = payload;
    },
  },
  persist: true,
});
