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

//Slider for Events handler
const eventsImages = '@Url.Content("~/Images/Events)';


let currentSlide = 0;
let slideInterval;

const images = [
    "11.6.2026-SIP-CONNECT-1300-x-615-px.jpg",
    "2026-First-Generation-College-Student-Celebration-1300-x-615-px.jpg",
    "CC-LANG-friendsgiving-2026-1920-x-950-px-1300-x-615-px.png",
    "Communications_262956658076069_6690188744358247592_11.5.26-GAMING-TOURNAMENT-1300-x-615-px.png",
    "DataAnalyticBootcamp.png",
    "Portal-FA26-Finals-Workshop.png",
    "Portal-FA26-The-HUB-Peer-Academic-Coaching-Semester-Pro-Mos.png",
    "Purple-Orange-and-Blue-Modern-Fashion-Sale-Poster-1920-x-950-px-1300-x-615-px-1.png",
    "RAGAD-RUPortalBanner.jpg",
    "RU-Portal-PSYCHed-General-Meeting-11_5_26.png",
    "Thanksgiving-Dinner-26-1300-x-615-px.png"
];

function loadSlider() {

    const container = document.getElementById("sliderImages");
    const indicators = document.getElementById("indicators");

    if (!container || !indicators) return;

    images.forEach(function (image, index) {

        const slide = document.createElement("div");
        slide.className = "slide";

        const img = document.createElement("img");

        img.src = "/Images/Events/" + image;
        img.alt = "Campus event";

        img.onload = function () {
            console.log("Image loaded:", img.src);
        };

        img.onerror = function () {
            console.error("Image NOT found:", img.src);
        };

        slide.appendChild(img);
        container.appendChild(slide);

        const button = document.createElement("button");

        button.addEventListener("click", function () {
            showSlide(index);
            startSlider();
        });

        indicators.appendChild(button);
    });

    showSlide(0);
    startSlider();
}

function showSlide(index) {

    const slides = document.querySelectorAll("#sliderImages .slide");
    const dots = document.querySelectorAll("#indicators button");

    if (!slides.length) return;

    currentSlide = (index + slides.length) % slides.length;

    slides.forEach(slide => slide.classList.remove("active"));
    dots.forEach(dot => dot.classList.remove("active"));

    slides[currentSlide].classList.add("active");
    dots[currentSlide].classList.add("active");
}

function changeSlide(direction) {
    showSlide(currentSlide + direction);
    startSlider();
}

function startSlider() {

    clearInterval(slideInterval);

    slideInterval = setInterval(function () {
        showSlide(currentSlide + 1);
    }, 5000);
}

document.addEventListener("DOMContentLoaded", loadSlider);
