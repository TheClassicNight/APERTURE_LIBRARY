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

function guardarSa() {
    var id = getParameterByName("IdVE");
    $.ajax({
        type: "POST",
        url: UrlGuardarSa,
        async: true,
        data: {
            IdTP: id,
            empleado: document.getElementById("empleado").value,
            cliente: document.getElementById("cliente").value,
            libro: document.getElementById("libro").value,
            cantidad: document.getElementById("cantidad").value
        },
        success: function (data) {

            location.href = "../home/sales";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}