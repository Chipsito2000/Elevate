document.addEventListener("DOMContentLoaded", function () {
    // Configurar el temporizador para eliminar el mensaje después de 5 segundos
    setTimeout(function () {
        var alertElement = document.getElementById("AlertaError");
        if (alertElement) {
            alertElement.style.transition = "opacity 0.5s ease";
            alertElement.style.opacity = "0"; // Hacer que el mensaje se desvanezca

            // Eliminar el elemento del DOM después de la transición
            setTimeout(function () {
                alertElement.parentNode.removeChild(alertElement);
            }, 100); //  duración de la transición
        }
    }, 1000); 
});
