document.addEventListener("DOMContentLoaded", function () {
    const exampleButton = document.querySelector(".example-button");

    exampleButton.addEventListener("click", function () {
        showBundlingMessage();
    });
});

function showBundlingMessage() {
    alert("In production, these scripts and styles would be minified and bundled into one file to reduce load times and improve performance.");
}
