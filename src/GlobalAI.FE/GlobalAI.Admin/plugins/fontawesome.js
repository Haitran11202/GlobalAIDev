/* import the fontawesome core */
import { library } from "@fortawesome/fontawesome-svg-core";

/* import font awesome icon component */
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

/* import specific icons */
import {
  faDownload,
  faPrint,
  faUser,
  faBook,
  faFileWord,
  faAngleLeft,
  faUserSecret,
  faAngleRight,
  faFileExcel,
  faCircleXmark,
  faStar,
  faSearch,
  faClock,
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
  faUser,
  faAngleLeft,
  faUserSecret,
  faFileExcel,
  faCircleXmark,
  faClock,
  faSearch,
  faBook,
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
