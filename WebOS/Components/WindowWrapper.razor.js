﻿
var DotNetHelper;

// Window drag code
export function dragStart(dotNetHelper) {
    document.addEventListener('mousemove', dragMove);
    document.addEventListener('mouseup', dragEnd);
    DotNetHelper = dotNetHelper;
};

export function dragMove(e) {
    DotNetHelper.invokeMethodAsync('MouseMove', e.clientX, e.clientY);
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
