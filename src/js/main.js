var canvas, ctx, zoom, pixlz;

$(function() {

    canvas = document.getElementById("mainCanvas");
    ctx = canvas.getContext("2d");
    ctx.imageSmoothingEnabled = false;

    //var $slider = $("#slider" ).slider({
    //    value:.25,
    //    min: .25,
    //    max: 2,
    //    step: .25,
    //    slide: function(event, ui) {
    //        zoom = ui.value;
    //        drawData();
    //    }
    //});

    $.ajax({
        dataType: "json",
        url: 'js/testimage.json',
        success: handleImage,
        async: false
    });

});



function handleImage(data) {
    pixlz = data;

    console.time("DrawCanvas10");
    for (var i = 1; i <= 10; i++); {
        zoom = .25 * i;
        drawData();
    }
    console.timeEnd("DrawCanvas10");

}

function drawData() {
    canvas.width = pixlz.w * zoom;
    canvas.height = pixlz.h * zoom;

    var p;
    for (var i = 0; i < pixlz.items.length; i++) {
        p = pixlz.items[i];
        fillArea(p.Color, p.X * zoom, p.Y * zoom, (p.X + pixlz.s) * zoom, (p.Y + pixlz.s) * zoom);
    }

    console.log("%i items painted", i);
}

function fillArea(c, x1, y1, x2, y2) {
    ctx.fillStyle = "rgb(" + c.R + "," + c.G + "," + c.B + ")";
    ctx.fillRect(x1, y1, x2, y2);
}

function colorToRGBA(c) {
    var a = (c.A / 255);
    // return "rgba(" + c.R + "," + c.G + "," + c.B + "," + a + ")";
    return "rgba(" + c.R + "," + c.G + "," + c.B + "," + "1.0)";
}
