using Microsoft.AspNetCore.Mvc;
using ReryFood.Areas.Admin.Servicos;

namespace ReryFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoVendasController : Controller
    {
        private readonly GraficosVendaService _grafico;

        public AdminGraficoVendasController(GraficosVendaService grafico)
        {
            _grafico = grafico ?? throw new ArgumentNullException(nameof(GraficosVendaService));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _grafico.GetGrafico(dias);
            return Json(lanchesVendasTotais);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VendasMensal()
        {
            return View();
        }

        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
