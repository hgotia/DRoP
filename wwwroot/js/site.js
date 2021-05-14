function yesFunction() {
    var button, text;
    text = "NOT ELIGIBLE";
    document.getElementById("demo").innerHTML = text;
}

function noFunction() {
    var text;
    text = "ELIGIBLE";
    var result = text.fontcolor("#07f602");
    document.getElementById("demo").innerHTML = result;
}