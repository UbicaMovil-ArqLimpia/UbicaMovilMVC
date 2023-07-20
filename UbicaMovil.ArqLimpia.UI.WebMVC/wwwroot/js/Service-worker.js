self.addEventListener('install', function (event) {

    event.waitUntil(

        Promise.resolve()
    );
});

self.addEventListener('activate', function (event) {

    //realizar tarea de activacíón aqui
});

self.addEventListener('fetch', function (event) {

    event.respondWith(
        fetch(event.request)
            .catch(function (error) {

                console.log('error en la solicitud: ', error);
            })
    )
}) 