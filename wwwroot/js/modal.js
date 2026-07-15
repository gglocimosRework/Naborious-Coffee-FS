const overlay = document.getElementById("overlay");
const productModal = document.getElementById("productModal");

const modalImage = document.getElementById("modalImage");
const modalTitle = document.getElementById("modalTitle");
const modalDescription = document.getElementById("modalDescription");
const modalPrice = document.getElementById("modalPrice");
const closeModal = document.getElementById("closeModal");

/* const allCards = document.querySelectorAll(".product-card"); not needed to use for now */

 export function openProductModal(card, product) {
card.addEventListener('click', () => {

       modalImage.src = product.image;
       modalTitle.textContent = product.title;
       modalDescription.textContent = product.description;
       modalPrice.textContent = product.price;


    productModal.classList.add('active');
    overlay.classList.add('active');
    document.body.style.overflow = 'hidden';
  });
}

function closeProductModal() {

    productModal.classList.remove('active');
    overlay.classList.remove('active');
    document.body.style.overflow = '';

}

overlay.addEventListener('click', closeProductModal);
closeModal.addEventListener('click', closeProductModal);

document.addEventListener('click', (e) => {
  if (e.target.classList.contains('buy-btn')) {
    alert('Ordering system coming soon!') || console.log('Buying product...');
  }
});