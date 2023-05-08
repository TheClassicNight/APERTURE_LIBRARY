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
            IdVE: id,
            Empleado: document.getElementById("empleado").value,
            Cliente: document.getElementById("cliente").value,
            Libro: document.getElementById("libro").value,
            CantidadLibroVenta: document.getElementById("cantidad").value,
            CostoVentaSubTotal: document.getElementById("subtotal").value,
            CostoVentaTotal: document.getElementById("total").value,
        },
        success: function (data) {

            location.href = "../home/Sales";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}