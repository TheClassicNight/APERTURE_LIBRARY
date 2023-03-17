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

function guardarLi() {
    var id = getParameterByName("IdLibro");
    $.ajax({
        type: "POST",
        url: UrlGuardarLi,
        async: true,
        data: {

            IdLibro: id,
            NombreLibro: document.getElementById("nombre").value,
            Autor: document.getElementById("autor").value,
            Editorial: document.getElementById("edit").value,
            FPublicacion: document.getElementById("fecha").value,
            CostoLibros: document.getElementById("costo").value,
            CantidadLibros: document.getElementById("cantidad").value,
            NoPaginas: document.getElementById("paginas").value,

        },
        success: function (data) {

            location.href = "../home/Books";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}