import '../Styles/app.scss';
import { componentFactory } from "./components-factory";

document.addEventListener('DOMContentLoaded', () => {
    console.log('PAGE WAS LOADED!!!');

    const components = [
        'AppNotifications'
    ];

    components.forEach((component) => {
        componentFactory(component).init();
    });
});
