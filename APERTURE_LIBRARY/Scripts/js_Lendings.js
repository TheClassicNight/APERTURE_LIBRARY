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

function guardarPR() {
    var id = getParameterByName("IdPR");
    $.ajax({
        type: "POST",
        url: UrlGuardarPR,
        async: true,
        data: {
            IdPR: id,
            cliente: document.getElementById("cliente").value,
            libro: document.getElementById("libro").value,
            empleado: document.getElementById("empleado").value,
            tipoPR: document.getElementById("tipoPR").value,
            FechaPrestamoInicial: document.getElementById("fechai").value,
            FechaPrestamoFinal: document.getElementById("fechaf").value,
            CostoPrestamo: document.getElementById("costop").value,
        },
        success: function (data) {

            location.href = "../home/lendings";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}