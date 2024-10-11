function previewImage(input) {
    var file = input.files[0];
    if (file) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById('<%= imgMiPerfil.ClientID %>').src = e.target.result;
        }
        reader.readAsDataURL(file);
    }
}


function toggleFavorite(button, id) {
    const icon = button.querySelector('i');
    icon.classList.toggle('text-danger');
    const esFavorito = icon.classList.contains('text-danger');

    // Llamada AJAX para agregar/eliminar de favoritos
    fetch('Favoritos.aspx', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: id, add: esFavorito })
    })
        .then(response => response.json())
        .then(data => {
            console.log(data.message); // Respuesta del servidor
        })
        .catch(error => console.error('Error:', error));
}
