
export function getActiveElement() {
    var elem = document.activeElement;
    console.log("start-menu has focus: " + document.hasFocus(document.getElementById("start-menu")))
    console.log("active element: " + elem.id)
    if (elem != null) {
        return elem.id;
    }
    else {
        return null;
    }
}
