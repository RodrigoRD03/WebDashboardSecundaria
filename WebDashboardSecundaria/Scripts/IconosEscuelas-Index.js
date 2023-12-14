var add = document.querySelector(".icon-add-es");
var edits = document.querySelectorAll(".icon-edit-es");
var datails = document.querySelectorAll(".icon-details-es");
var delates = document.querySelectorAll(".icon-delate-es");
var dotsElements = document.querySelectorAll(".icon-menu_item");



add.innerHTML = `<div class="app__secundaria-add">
            <span class="icon-add-content">
                <i class="fa-solid fa-plus"></i>
            </span >
        </div>`;


add.style.textDecoration = "none"

edits.forEach((edit) => {
    edit.innerHTML = `<p>Editar</p> <span><i class="fa-solid fa-pen"></i></span>`;
})

datails.forEach((detail) => {
    detail.innerHTML = `<p>Detalles</p> <span><i class="fa-solid fa-magnifying-glass"></i></span>`
})
delates.forEach((delate) => {
    delate.innerHTML = `<p>Suspender</p> <span><i class="fa-solid fa-trash"></i></span>`
})

dotsElements.forEach((dotsElement) => {
    dotsElement.addEventListener('click', () => {
        var menu = dotsElement.closest(".app__secundaria-item").querySelector(".app__secundaria-item_menu");

        menu.classList.toggle("view");
    });
});