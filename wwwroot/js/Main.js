import './generate-coffees.js';


toggleMenu();

const links = document.querySelectorAll('.scroll-link');
const menu = document.getElementById("mobileMenu");

links.forEach(link => {
  link.addEventListener('click', e => {
    e.preventDefault();

    const targetId = link.dataset.target; 
    const targetSection = document.getElementById(targetId);

    targetSection.scrollIntoView({ behavior: 'smooth' });

     document.getElementById("mobileMenu").classList.remove("active");
  });
});

function toggleMenu() {
    
    const menuToggle = document.querySelector('.js-menu-toggle')
    
    menuToggle.addEventListener('click', () => {
     menuToggle.classList.toggle("active");
     menu.classList.toggle("active");
    });   
}

    document.addEventListener('mousemove', (e) => {
        const triggerDistance = 105.5; 
    if (window.innerWidth - e.clientX <= triggerDistance) {
            menu.classList.add('active'); 
    } else if (e.clientX < window.innerWidth - menu.offsetWidth) {
            menu.classList.remove('active');
        }
    });


    /* Theme switcher for light website and 
    a darker website(for UX purposes and self-learning) */

   const themeSwitch = document.getElementById('theme-switch');
   const lightModeIcon = document.getElementById('lightMode');
   const darkModeIcon = document.getElementById('darkMode');
   const LogoIcon = document.getElementById('logoIcon');

   themeSwitch.addEventListener('click', () => {
    document.body.classList.toggle('darkmode');

    if (document.body.classList.contains('darkmode')) {
        lightModeIcon.style.display = 'block';
        darkModeIcon.style.display = 'none';
        LogoIcon.src = './images/logo-darkmode.jpeg'; // logo img changed for darkmode
        localStorage.setItem('darkmode', 'enabled');
    } else {
        lightModeIcon.style.display = 'none';
        darkModeIcon.style.display = 'block';
        LogoIcon.src = './images/logo.jpeg'; // logo img for lightmode
        localStorage.setItem('darkmode', 'disabled');
    }
   })

   
  
  
   




