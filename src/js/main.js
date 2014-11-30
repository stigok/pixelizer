var canvas, ctx, zoom, pxz;

$(function() {

    canvas = document.getElementById("mainCanvas");
    ctx = canvas.getContext("2d");

    $.ajax({
        url: 'js/testimage.pxlz',
        success: handleImage,
        async: false
    });

});

function handleImage(data) {
    pxz = data;

    var pixels = data.split('='),
        options = pixels[0].split('/'),
        pixels = pixels[1].split('^');

    console.time("drawData");
    drawData(+options[0], +options[1], pixels);
    console.timeEnd("drawData");
}

function drawData(w, s, d) {
    var r = (w / s),
        h = d.length / r * s,
        x = 0,
        y = 0;

    canvas.width = w;
    canvas.height = h;

    for (var i = 0; i < d.length; i++) {
        if (i > 0 && x === r) {
            x = 0;
            y++;
        }

        ctx.fillStyle = '#' + d[i];
        ctx.fillRect(x * s, y * s, s, s);
        x++;
    }

    console.log("w: %i\th: %i", w, h);
    console.log("%i items painted", i);
    console.log("%i kbytes", i / 1024);
}
