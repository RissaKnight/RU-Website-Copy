// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// DropDown Handler
document.addEventListener("DOMContentLoaded", function () {

    const dropdownItems = document.querySelectorAll(
        ".mainNav > li.has-dropdown"
    );

    const hamburger = document.getElementById("menu-toggle");

    function closeAllDropdowns() {

        dropdownItems.forEach(function (item) {

            item.classList.remove("is-open");

            const button = item.querySelector(".nav-dropdown-toggle");

            if (button) {
                button.setAttribute("aria-expanded", "false");
            }

        });

    }

    dropdownItems.forEach(function (item) {

        const button = item.querySelector(".nav-dropdown-toggle");

        button.addEventListener("click", function () {

            const alreadyOpen = item.classList.contains("is-open");

            closeAllDropdowns();

            if (!alreadyOpen) {
                item.classList.add("is-open");
                button.setAttribute("aria-expanded", "true");
            }

        });

    });

    if (hamburger) {

        hamburger.addEventListener("change", function () {

            if (!hamburger.checked) {
                closeAllDropdowns();
            }

        });
    }
});
