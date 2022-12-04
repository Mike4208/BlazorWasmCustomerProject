var map;

export function initialize() {
    var latlng = new google.maps.latlng(40.60385562498126, 22.964978380097826);
    var options = {
        zoom: 14, center: latlng, maptypeId: google.maps.maptypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map"), options);
}

export function displayPrompt(message) {
    return prompt(message, "Your name...");
}

export function displayAlert(message) {
    return alert(message);
}

