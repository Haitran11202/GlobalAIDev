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
  faArrowRight,
  faBold,
  faItalic,
  faStrikethrough,
  faCode,
  faParagraph,
  faQuoteLeft,
  faList,
  faImage,
  faUndo,
  faRedo,
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
  faTimes,
  faArrowRight,
  faBold,
  faItalic,
  faStrikethrough,
  faCode,
  faParagraph,
  faQuoteLeft,
  faList,
  faImage,
  faUndo,
  faRedo



  


);

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component("font-awesome-icon", FontAwesomeIcon);
});
