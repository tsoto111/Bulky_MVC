/**
 * Fade Out
 * 
 * Use of global "Animate Found Out" scss animation. We use css3
 * animations because it was smoother than what vanilla js could
 * provide. At the end of 3 seconds, how long our css3 animation
 * takes to animate, we will remove the element from the dom.
 * 
 * @param   {HtmlElement} element The html element we want to fade out.
 * @returns {void}
 */
export function fadeOut(element) {
    element.classList.add('animate-fade-out');
    setInterval(() => {
        element.remove();
    }, 3000);
}
/**
 * Variable Is Empty?
 *
 * Will tell us if the passed in javascript variable is empty
 * or not.
 *
 * @param  {string|number|object} variable
 * @return {boolean}
 */

export function variableIsEmpty(variable) {
    if (variable === undefined || variable === null || variable === '') {
        return true;
    }

    return false;
}
