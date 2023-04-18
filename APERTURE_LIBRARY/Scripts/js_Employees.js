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

function guardarPer() {
    var id = getParameterByName("IdPE");

    $.ajax({
        type: "POST",
        url: UrlGuardarPer,
        async: true,
        data: {
            IdPE: id,
            NombrePer: document.getElementById("NombrePer").value,
            ApePat: document.getElementById("ApePat").value,
            ApeMat: document.getElementById("ApeMat").value,
            FechaNacimiento: document.getElementById("FechaNacimiento").value,
            correo: document.getElementById("correo").value,
            NumTelefono: document.getElementById("NumTelefono").value,
            Domicilio: document.getElementById("Domicilio").value,
            Puesto: document.getElementById("Puesto").value,
            Turno: document.getElementById("Turno").value
        },
        success: function (data) {

            location.href = "../home/Employees";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

