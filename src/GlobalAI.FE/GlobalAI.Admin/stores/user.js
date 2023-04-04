export const useUserStorage = defineStore('user', {
    state: () => ({
        accessToken: null,
        refreshToken: null,
        permissions: [],
    }),
    getters: {
        getAccessToken: (state) => state.accessToken,
        getRefreshToken: (state) => state.refreshToken,
        getPpermissions: (state) => state.permissions,
    },
    actions: {
        login(payload) {
            const { accessToken, refreshToken } = payload;

            this.accessToken = accessToken;
            this.refreshToken = refreshToken;
        },
        updatePermissions(payload) {
            this.permissions = Array.isArray(payload) ? payload : []
        },
        logout(state) {
            // Object.keys(this.$state).forEach(key => {
            //     state[key] = null;
            // })
        },
    }
});