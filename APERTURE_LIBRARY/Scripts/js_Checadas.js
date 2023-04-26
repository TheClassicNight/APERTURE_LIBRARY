function getParameterByName(name) {
    if (name !== "" && name !== null && name != undefined) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    } else {
        var arr = location.href.split("/");
        return arr[arr.length - 1];
    }

}

function guardarCh() {
    var id = getParameterByName("IdCH");
    $.ajax({
        type: "POST",
        url: UrlGuardarCh,
        async: true,
        data: {

            IdCH: id,
            FechaDia: document.getElementById("fecha").value,
            empleado: document.getElementById("empleado").value,
            HoraEntrada: document.getElementById("entrada").value,
            HoraSalida: document.getElementById("salida").value,
        },
        success: function (data) {

            location.href = "../home/EntracesAndExits";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

