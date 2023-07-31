function initialize() {
    var marcadores = [
        ['<h2>Empresa x</h2> <br><h4>Las moras.oriente 12 <br> Tel:9929-2991</h4> ', 13.7257316, -89.3665101],
        ['<h2>Empresa 2</h2> <br><h4>San Salvador calle 123 <br>Tel:9929-2992</h4> ', 13.68935, -89.18718],

    ];
    var map = new google.maps.Map(document.getElementById('mapa'), {
        zoom: 7,
        center: new google.maps.LatLng(13.67694, -89.27972),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    var infowindow = new google.maps.InfoWindow();
    var marker, i;
    for (i = 0; i < marcadores.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(marcadores[i][1], marcadores[i][2]),
            map: map
        });
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(marcadores[i][0]);
                infowindow.open(map, marker);
            }
        })(marker, i));
    }
}
google.maps.event.addDomListener(window, 'load', initialize);