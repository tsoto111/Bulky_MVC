import { fadeOut } from '../Utils/helpers';

/**
 * App Notifications
 * 
 * Since we use Bootstrap 5 alert components for notification messages. We will
 * add our custom logic for our app notifications here. Currently, we will fade 
 * out alert notifications after 3 seconds to mimic a "toast" notification.
 */
class AppNotifications {
    constructor() {
        this.alerts = document.querySelectorAll('.alert');
    }

    init() {
        if (this.alerts.length > 0) {
            this.alerts.forEach((alertElement) => {
                fadeOut(alertElement);
            })
        }
    }
}

export default AppNotifications;