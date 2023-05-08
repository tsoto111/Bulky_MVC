/**
 * Components Factory
 *
 * This components factory is based off of the shared article 'JavaScript Design Patterns Part 1: The Factory Pattern'.
 * This factory will allow devs to initialize a component class object without having to define
 * `const componentClass = new Component()` first.
 *
 * Doc: https://medium.com/@thebabscraig/javascript-design-patterns-part-1-the-factory-pattern-5f135e881192
 */

import AppNotifications from "./Components/AppNotifications";

const components = {
    AppNotifications
}

/**
* Component Factory
*
* This is a factory method used to initialize Component based classes. Instead of having to import the
* component class file, define the class, and initialize it... you can just import this component
* factory and define/initialize at the same time. In addition, you only have to import this one file
* to use any component that gets configured here!
*
* Example Usage:
*
* import { componentFactory } from '../components-factory';
* ...
* componentFactory('AccoFeatCard').init();
*
* @param {string} type  String representation of the desired Class object definition that you would like to
*                       instanciate. String has to be represented in the `components` object above.
* @param {any} attributes Optional attributes that you would like to pass to your Class object. You can handle
*                       these attributes within the class's `constructor` method block.
* @returns {Class}      Will return an initialized class object based off of the passed in type.
*/

function componentFactory(type, attributes) {
    const ComponentType = components[type]

    return new ComponentType(attributes);
}

export { componentFactory };
