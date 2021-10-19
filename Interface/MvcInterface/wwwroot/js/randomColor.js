function getRandomColor() {
        var x = Math.floor(Math.random() * 36);
        var y = 5 + Math.floor(Math.random() * 36);
        var z = 10 + Math.floor(Math.random() * 36);
        var bgColor = "rgb(" + x + "," + y + "," + z + ")";
        return bgColor;
}

function setRandomColor() {
    $("#banner").css("background-color", getRandomColor());
    $("body").css("background-color", "#F3F2EF");
}

setRandomColor();