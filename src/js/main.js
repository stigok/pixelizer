var canvas, ctx;

$(function() {

    canvas = document.getElementById("mainCanvas");
    ctx = canvas.getContext("2d");

    $.getJSON('js/testimage.json', handleImage);

});

function handleImage(pixlz) {
    canvas.width = pixlz.w;
    canvas.height = pixlz.h;

    var p;
    for (var i = 0; i < pixlz.items.length; i++) {
        p = pixlz.items[i];
        fillArea(p.Color, p.X, p.Y, p.X + pixlz.s, p.Y + pixlz.s);
        console.log("paint: %ix%i : %s", p.X, p.Y, colorToRGBA(p.Color));
    }
}

function fillArea(color, x1, y1, x2, y2) {
    ctx.fillStyle = colorToRGBA(color);
    ctx.fillRect(x1, y1, x2, y2);
}

function colorToRGBA(c) {
    var a = (c.A / 255).toFixed(1);
    return "rgba(" + c.R + "," + c.G + "," + c.B + "," + a + ")";
}
