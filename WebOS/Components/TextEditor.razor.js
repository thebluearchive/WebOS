
export function createCodeMirror(container) {
    var myCodeMirror = CodeMirror(container, {
        value: "this is a test document\nDoes it display properly?",
        indentUnit: 4,
        lineNumbers: true//,
        //theme: "the-matrix"
    });
}