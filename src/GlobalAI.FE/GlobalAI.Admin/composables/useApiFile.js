import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const postFile = async (file) => {
  try {
    const api = `${API_ENDPOINT.postImages}?folder=test`;

    const formData = new FormData();
    console.log(111111111111111, file);
    formData.append('file', file, file?.name);
    const res = await http.post(
      api, formData
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
