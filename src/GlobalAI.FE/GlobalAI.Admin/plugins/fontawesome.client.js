/* import the fontawesome core */
import { library } from "@fortawesome/fontawesome-svg-core";

/* import font awesome icon component */
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

/* import specific icons */
import {
  faDownload,
  faPrint,
  faFileWord,
  faAngleLeft,
  faUserSecret,
  faAngleRight,
  faFileExcel,
  faCircleXmark,
  faStar,
  faSearch,
  faArrowLeft,
  faDoorOpen,
  faClose,
  faReply,
  faCheck,
  faHand,
  faEnvelope,
  faFolderOpen,
  faThumbsDown,
  faHourglassStart,
  faEye,
  faInfo,
  faCircleInfo,
  faBars,
  faTimes,
  faTruckMoving,

} from "@fortawesome/free-solid-svg-icons";

/* add icons to the library */
library.add(
  faFileWord,
  faStar,
  faDownload,
  faPrint,
  faAngleLeft,
  faUserSecret,
  faFileExcel,
  faCircleXmark,
  faSearch,
  faTruckMoving,
  faAngleRight,
  faArrowLeft,
  faDoorOpen,
  faClose,
  faReply,
  faCheck,
  faHand,
  faEnvelope,
  faFolderOpen,
  faHourglassStart,
  faThumbsDown,
  faInfo,
  faCircleInfo,
  faBars,
  faTimes

);

export default defineNuxtPlugin((nuxtApp) => {
    nuxtApp.vueApp.component("font-awesome-icon", FontAwesomeIcon);
});
