module.exports = function (grunt) {

    grunt.initConfig({

        //
        // Settings
        //

        // pkg : grunt.file.readJSON('package.json'),

        dirs : {
            src : 'src'
        },

        //
        // Tasks
        //

        // watch : {
            // js : {
                // files : ['<%= dirs.src %>/js/**/*.js'],
                // tasks : ['jsmin-sourcemap', 'concat', 'replace:build']
            // },
            // css : {
                // files : ['<%= dirs.src %>/css/**/*.less'],
                // tasks : ['less']
            // },
            // other : {
                // files : ['<%= dirs.src %>/**/*', '!**/*.js', '!**/*.less'],
                // tasks : ['build-no-clean'],
                // options : {
                    // atBegin: true
                // }
            // }
        // },

        exec : {
            'http-server' : {
                cmd : "cmd /c start \"http-server\" /min http-server <%= dirs.src %> -c-1",
                stdout : true,
                stderr : true
            },
            browser : {
                cmd : "explorer \"http://localhost:8080/\"",
                exitCode : 1
            }
        }

    });

    //
    // Load modules
    //

    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-exec');

    //
    // Define tasks
    //

    grunt.registerTask(
        'default', ['http-server']
    );

    grunt.registerTask(
        'http-server',
        'Start a HTTP server for debugging build/ directory',
        ['exec:http-server']
    );

    grunt.registerTask(
        'debug',
        'Equivalent of watch + http-server',
        ['build', 'http-server', 'watch']
    );
}
