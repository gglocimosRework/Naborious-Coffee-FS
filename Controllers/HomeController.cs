using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Naborious_Coffe_FS.Models;
using NaboriousCoffee.Data;
// Garante o acesso à pasta do seu AppDbContext

namespace Naborious_Coffe_FS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context; // Adicionado para acessar o banco

        // Construtor atualizado para receber o AppDbContext
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Sua página principal agora busca os Cafés do Banco de Dados
        public async Task<IActionResult> Index()
        {
            var coffees = await _context.Coffees.ToListAsync();
            return View(coffees); // Passa a lista de Coffee para a View
        }

        // 2. Mantendo a sua rota de API que você já tinha, mas agora buscando do banco!
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // Busca os cafés do banco para retornar como JSON
            var coffees = await _context.Coffees.ToListAsync();
            return Ok(coffees);
        }
    }
}