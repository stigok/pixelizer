$.widget("stigok.pixelizer", {

    _context : {},
    _image : {},

    _create : function() {
        var _self = this;
        _self._loadContext();

        $.ajax({
            url: this.element.attr('xz-src') + this.element.attr('xz-skip'),
            success: function(data) {
                _self._handleImage(data);
            },
            async: false
        });
    },

    _handleImage : function(data) {
        var args = data.split(/[x/=]+/);
        console.log(args);

        console.time("drawData");
        this._drawData(+args[0], +args[1], +args[2], args[3].split('^'));
        console.timeEnd("drawData");
    },

    _loadContext : function() {
        this._context = this.element.get(0).getContext("2d");
    },

    _drawData : function(width, height, dotSize, dots) {
        var columnCount = (width - (width % dotSize)) / dotSize,
            rowCount = (height - (height % dotSize)) / dotSize,
            i = 0;

        this.element.width(width);
        this.element.height(height);
        this._loadContext();

        for (y = 0; y < rowCount; y++) {
            for (x = 0; x < columnCount; x++) {
                this._context.fillStyle = '#' + dots[i];
                this._context.fillRect(x * dotSize, y * dotSize, dotSize, dotSize);
                i++;
            }
        }

        console.log("w: %i\th: %i", width, height);
        console.log("%i items painted", i);
        console.log("%i kbytes", i / 1024);
    }
});
