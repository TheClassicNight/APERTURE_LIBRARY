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

function guardarCLI() {
    var id = getParameterByName("IdCLI");
    $.ajax({
        type: "POST",
        url: UrlGuardarCLI,
        async: true,
        data: {
            IdCLI: id,
            NombreCli: document.getElementById("NombreCli").value,
            ApePat: document.getElementById("ApePat").value,
            ApeMat: document.getElementById("ApeMat").value,
            FechaNacimiento: document.getElementById("FechaNacimiento").value,
            correo: document.getElementById("correo").value,
            NumTelefono: document.getElementById("NumTelefono").value,
            Domicilio: document.getElementById("Domicilio").value,
        },
        success: function (data) {

            location.href = "../home/Clients";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

