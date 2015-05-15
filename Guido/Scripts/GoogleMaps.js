//Function that loads the map markers.
function loadMapMarkers() {

    //GLASTONBURY -----------------

    //Setting the position of the Glastonbury map marker.
    var markerPositionGlastonbury = new google.maps.LatLng(45.813209, 15.977283);


    //Creating the Glastonbury map marker.
    markerGlastonbury = new google.maps.Marker({
        //uses the position set above.
        position: markerPositionGlastonbury,
        //adds the marker to the map.
        map: festivalMap,
        title: 'Glastonbury Festival',
    });


}

function route () {
    var markers = [
            ['Trg bana Josipa Jelačića', 45.813203, 15.977287],
            ['Hrvatsko Narodno Kazalište', 45.809397, 15.970039],
            ['Zoološki vrt Zagreb', 45.821884, 16.019451],
            ['SIDRO', 45.785354, 15.953975],
            ['FER', 45.800788, 15.971327],
            ['Arkade Hermanna Bollea', 45.835602, 15.983987]
    ];
    $('.js-route').on('click', function () {
        //hvala gabi pederčinjo, tu satvljaš event za mape route 1
        var $this = $(this);
        console.log($this.data('route'));
        if ($this.data('route') === '1') {
            var markerPositionGlastonbury = new google.maps.LatLng(45.800788, 15.971327);


            //Creating the Glastonbury map marker.
            markerGlastonbury = new google.maps.Marker({
                //uses the position set above.
                position: markerPositionGlastonbury,
                //adds the marker to the map.
                map: festivalMap,
                title: 'FER',
            });
        }
    });
});

