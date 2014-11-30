var canvas, ctx, zoom, pixlz;

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
    pixlz = data;

    console.time("drawData");
    drawData();
    console.timeEnd("drawData");
}

function drawData() {
    canvas.width = pixlz.w;
    canvas.height = pixlz.h;

    var p;
    var y = 0;
    for (var i = 0; i < pixlz.items.length; i++) {
        p = pixlz.items[i];
        ctx.fillStyle = "rgba"+p.c;
        ctx.fillRect(p.x, p.y, p.x + pixlz.s, p.y + pixlz.s);

        if (i > 0 && i % pixlz.s === 0) y++;
    }

    console.log("%i items painted", i);
}
