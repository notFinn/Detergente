function initialize() {
    var mapCanvas = document.getElementById('map-canvas');
    var posi = new google.maps.LatLng(-33.572429, -70.566485);
    var mapOpcions = {
        center: posi,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(mapCanvas, mapOpcions)
    var marker = new google.maps.Marker({
        position: posi,
        //label: labels('hola'),
        map: map
    });

}
google.maps.event.addDomListener(window, 'load', initialize);