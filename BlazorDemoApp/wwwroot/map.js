

window.loadMap = function () {
    console.log("🗺️ Initializing map...");

    var mapDiv = document.getElementById("map");
    if (!mapDiv) {
        console.error("❌ Map div not found!");
        return;
    }

    //var map = L.map("map").setView([34.6994, -86.7483], 13); // Default view to Madison
    console.log("Map object:", map); // Check if map object is created

    //L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    //    attribution: "© OpenStreetMap contributors"
    //}).addTo(map);

    //L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}', {
    //    attribution: 'Tiles &copy; Esri &mdash; Source: Esri, i-cubed, USDA, USGS, AEX, GeoIQ, and the GIS User Community',
    //    maxZoom: 19
    //}).addTo(map);



    // Add a marker for Madison, AL
    //L.marker([34.6994, -86.7483])
    //    .addTo(map)
    //    .bindPopup("Madison, Alabama")
    //    .openPopup()

    var Madison = L.marker([34.6994, -86.7483]).bindPopup('This is Madison, Al.'),
        Huntsville = L.marker([34.727318945597794, -86.57883099553773]).bindPopup('This is Huntsville, Al.'),
        Decatur = L.marker([34.60475045174025, -86.97813064627917]).bindPopup('This is Decatur, Al.'),
        Gadsden = L.marker([34.01389946365522, -86.00454914237677]).bindPopup('This is Gadsden, Al.'),
        Selma = L.marker([32.40711030777459, -87.02033539094504]).bindPopup('This is Selma, Al.'),
        Mobile = L.marker([30.69516608979471, -88.03818482749905]).bindPopup('This is Mobile, Al.');


    var cities = L.layerGroup([Madison, Huntsville, Decatur, Gadsden, Selma, Mobile]);

    var osm = L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap'
    });
    var map = L.map('map', {
        center: [34.6994, -86.7483],
        zoom: 10,
        layers: [osm, cities]
    });
    var baseMaps = {
        "OpenStreetMap": osm
        
    };

    var overlayMaps = {
        "Cities": cities
    };

    var layerControl = L.control.layers(baseMaps, overlayMaps).addTo(map);

    function onMapClick(e) {
        alert("You clicked the map at " + e.latlng);
    }

    map.on('click', onMapClick);

    //console.log("🗺️ Map has been loaded successfully!");
};
