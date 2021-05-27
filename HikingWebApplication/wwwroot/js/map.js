
let map;
var geocoder;
function initMap() {
    geocoder = new google.maps.Geocoder();

    const mapOptions = {
        zoom: 8,
        center: { lat: -34.397, lng: 150.644 },
    };

    map = new google.maps.Map(document.getElementById("maps"), mapOptions);

    var start = document.getElementById("start");

    var autocomplete = new google.maps.places.Autocomplete(start);
    autocomplete.setTypes(['geocode']);

    google.maps.event.addListener(autocomplete, 'place_changed', function () {
        var place = autocomplete.getPlace();
        if (!place.geometry) {
            return;
        }

        var address = '';
        if (place.address_components) {
            address = [
                (place.address_components[0] && place.address_components[0].short_name || ''),
                (place.address_components[1] && place.address_components[1].short_name || ''),
                (place.address_components[2] && place.address_components[2].short_name || '')
            ].join(' ');
        }
    });

    document.getElementById("start").addEventListener("focusout", () => {
        var address = document.getElementById("start").value;
        codeAddress(address)
    });
}

function codeAddress(address) {
    geocoder.geocode({ 'address': address }, function (results, status) {
        var latLng = { lat: results[0].geometry.location.lat(), lng: results[0].geometry.location.lng() };
        const mapOptions = {
            zoom: 8,
            center: latLng,
        };
        map = new google.maps.Map(document.getElementById("maps"), mapOptions);
        if (status == 'OK') {
            var marker = new google.maps.Marker({
                position: latLng,
                map: map
            });

            document.getElementById("Latitude").value = results[0].geometry.location.lat();
            document.getElementById("Longitude").value = results[0].geometry.location.lng();
           

        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}

//function calculateAndDisplayRoute(directionsService, directionsRenderer) {
//    console.log(document.getElementById("start").value);
//    console.log(document.getElementById("end").value);
//    directionsService.route(
//        {
//            origin: document.getElementById("start").value,
//            destination: document.getElementById("end").value,
//            travelMode: google.maps.TravelMode.DRIVING,
//        },
//        (response, status) => {
//            if (status === "OK" && response) {
//                directionsRenderer.setDirections(response);
//                const route = response.routes[0];
//                const summaryPanel = document.getElementById("directions-panel");
//                summaryPanel.innerHTML = "";

//                // For each route, display summary information.
//                for (let i = 0; i < route.legs.length; i++) {
//                    const routeSegment = i + 1;
//                    summaryPanel.innerHTML +=
//                        "<b>Route Segment: " + routeSegment + "</b><br>";
//                    summaryPanel.innerHTML += route.legs[i].start_address + " to ";
//                    summaryPanel.innerHTML += route.legs[i].end_address + "<br>";
//                    summaryPanel.innerHTML += route.legs[i].distance.text + "<br><br>";
//                }
//            } else {
//                window.alert("Directions request failed due to " + status);
//            }
//        }
//    );
//}
