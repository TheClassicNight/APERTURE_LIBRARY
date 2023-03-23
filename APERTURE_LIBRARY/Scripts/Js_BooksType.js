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

function guardarTLi() {
    var id = getParameterByName("IdTL");
    $.ajax({
        type: "POST",
        url: UrlGuardarTLi,
        async: true,
        data: {

            IdTL: id,
            Genero: document.getElementById("Genero").value,
            Categoria: document.getElementById("Categoria").value,
        },
        success: function (data) {

            location.href = "../home/BooksType";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

