var canvas, ctx, zoom, pxz;

$(function() {

    canvas = document.getElementById("mainCanvas");
    ctx = canvas.getContext("2d");

    $.ajax({
        dataType: "json",
        url: 'js/testimage.json',
        success: handleImage,
        async: false
    });

});

function handleImage(data) {
    pxz = data;

    console.time("drawData");
    drawData();
    console.timeEnd("drawData");
}

function drawData() {
    var x = 0, y = 0;
    canvas.width = pxz.w;
    canvas.height = pxz.h;

    for (var i = 0; i < pxz.p.length; i++) {
        if (i > 0 && x === pxz.w / pxz.s) {
            x = 0;
            y++;
        }

        ctx.fillStyle = '#' + pxz.p[i];
        ctx.fillRect(x * pxz.s, y * pxz.s, pxz.s, pxz.s);
        x++;
    }

    console.log("%i items painted", i);
    console.log("%i kbytes", i / 1024);
}
