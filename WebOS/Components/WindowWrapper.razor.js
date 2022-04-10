
var DotNetHelper;

// Window drag code
export function dragStart(dotNetHelper) {
    document.addEventListener('mousemove', dragMove);
    document.addEventListener('mouseup', dragEnd);
    DotNetHelper = dotNetHelper;
};

export function dragMove(e) {
    DotNetHelper.invokeMethodAsync('DragMove', e.clientX, e.clientY);
};

export function dragEnd(e) {
    document.removeEventListener('mousemove', dragMove);
    document.removeEventListener('mouseup', dragEnd);
};

export function getElementWidth(element) {
    return element.clientWidth;
};

export function getElementHeight(element) {
    return element.clientHeight;
};


// Window resize code
export function windowResizeStart(dotNetHelper) {
    document.addEventListener('mousemove', resizeMove);
    document.addEventListener('mouseup', resizeEnd);
    DotNetHelper = dotNetHelper;
}

export function resizeMove(e) {
    DotNetHelper.invokeMethodAsync('ResizeMove', e.clientX, e.clientY);
}

export function resizeEnd(e) {
    document.removeEventListener('mousemove', resizeMove);
    document.removeEventListener('mousemove', resizeEnd);
    //DotNetHelper.invokeMethodAsync('MouseUp', e);
}
