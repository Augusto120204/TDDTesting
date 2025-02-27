// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const menuItems = document.querySelectorAll("#sidebar ul li");

    menuItems.forEach(item => {
        item.addEventListener("click", function () {
            // Remover la clase 'active' de todos los elementos
            menuItems.forEach(li => li.classList.remove("active"));
            // Agregar la clase 'active' solo al elemento clickeado
            this.classList.add("active");
        });
    });
});
