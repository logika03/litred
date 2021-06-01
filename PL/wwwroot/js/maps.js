var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: {lat: 55.47, lng: 49.06},
        zoom: 8
    });
}
