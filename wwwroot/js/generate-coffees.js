import {coffees} from './products.js';
import {openProductModal} from './modal.js';

const main = document.getElementById("mainContent");

function createSection(id, title, containerClass, sectionClass) {
    const section = document.createElement("section");
    section.id = id;
    if (sectionClass) section.classList.add(sectionClass);

    const h3 = document.createElement("h3");
    h3.textContent = title;

    const container = document.createElement("div");
    container.classList.add(containerClass);
    container.id = id + "Container";

    section.appendChild(h3);
    section.appendChild(container);

    return { section, container };
}

// HTML Sections(coffees, canadian sweets & other sweets)
const sections = {
    coffee: createSection("featured-coffees", "Featured Coffees", "coffee-grid", "featured"),
    canadian: createSection("featured-canadian-sweets", "Featured Canadian Sweets 🍁", "sweet-grid", "featured-canada-sweets"),
    sweet: createSection("other-sweets", "Other Featured Sweets", "others-sweets-grid", "featured-others-sweets")
};

Object.values(sections).forEach(section => main.appendChild(section.section));

const productsCoffeeContainer = sections.coffee.container;
const productsCanadianContainer = sections.canadian.container;
const productsSweetContainer = sections.sweet.container;

// Load products from the server and create product cards
async function loadProducts() {
    try {
        const response = await fetch('/Home/GetProducts');
        const products = await response.json();
        createProductCards(products);
    } catch (error) {
        console.error("Erro ao carregar produtos do servidor:", error);
    }
}

function createProductCards(productsList) {
    productsList.forEach(product => {
        const card = document.createElement("div");
        card.classList.add("product-card");

        if (product.type === "coffee") {
            card.classList.add("coffee-item");
        } else if (product.type === "canadian") {
            card.classList.add("sweet-item");
        } else if (product.type === "sweet") {
            card.classList.add("other-sweet-item");
        }

        // Set the inner HTML of the card with product details
        card.innerHTML = `
        <img src="${product.image}" alt="${product.title}" loading="lazy" decoding="async">
        <h3>${product.title}</h3>
        <p class="product-short-description">${product.shortDescription}</p>
        <span class="product-price">${product.price}</span>`;

        openProductModal(card, product);

        if (product.type === "coffee") {
            productsCoffeeContainer.appendChild(card);
        } else if (product.type === "canadian") {
            productsCanadianContainer.appendChild(card);
        } else {
            productsSweetContainer.appendChild(card);
        }
    });
}


loadProducts();
 