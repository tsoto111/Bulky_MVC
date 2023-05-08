import '../Styles/app.scss';
import { componentFactory } from "./components-factory";

document.addEventListener('DOMContentLoaded', () => {
    const components = [
        'AppNotifications'
    ];

    components.forEach((component) => {
        componentFactory(component).init();
    });
});
