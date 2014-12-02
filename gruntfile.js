module.exports = function (grunt) {

    grunt.initConfig({
        dirs : {
            src : 'src'
        },

        exec : {
            'http-server' : {
                cmd : "cmd /c start \"http-server\" /min http-server <%= dirs.src %> -c-1",
                stdout : true,
                stderr : true
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-exec');

    grunt.registerTask('default', ['http-server']);
    grunt.registerTask('http-server', ['exec:http-server']);
}
