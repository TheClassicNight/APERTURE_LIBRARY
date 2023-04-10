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

function guardarTPr() {
    var id = getParameterByName("IdTP");
    $.ajax({
        type: "POST",
        url: UrlGuardarTPr,
        async: true,
        data: {
            IdTP: id,
            TipoPrestamo: document.getElementById("Tipo").value,
            Descripcion: document.getElementById("Descripcion").value
        },
        success: function (data) {

            location.href = "../home/LoanType";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}