using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FamilyApp.Models;

namespace FamilyApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Dictionary<string, string> pix = new ();
        pix.Add("/images/IMG_3989.jpeg", "DC with Cecy, Ilya and the crew");
        pix.Add("/images/IMG_4792.jpeg", "Elea & Zoe on a terril");
        pix.Add("/images/IMG_4797.jpeg", "the dream team on the very same terril");
        pix.Add("/images/IMG_8054.jpeg", "Emily");
        pix.Add("/images/IMG_5636.jpeg", "Elea on the boardwalk");
        pix.Add("/images/IMG_5995.jpeg", "the dreamteam at msm museum");
        pix.Add("/images/IMG_.6260jpeg", "Zoe kung-fu");
        pix.Add("/images/IMG_6343.jpeg", "Elea & Zoe shopping at Carrefour Bomeree");
        pix.Add("/images/IMG_6345.jpeg", "dreamteam at Carrefour");
        pix.Add("/images/IMG_6396.jpeg", "me, let's suit up");
        pix.Add("/images/IMG_6488.jpeg", "Zoe fashionista");
        pix.Add("/images/IMG_6770.jpeg", "family in Liege");
        pix.Add("/images/IMG_6894.jpeg", "family in LLN");
        pix.Add("/images/IMG_7027.jpeg", "family at Nirvana Bar - Karelkoning");
        pix.Add("/images/IMG_7382.jpeg", "Em & I");
        pix.Add("/images/IMG_7757.jpeg", "Family Brunch in Central Park");
        ViewBag.Pix = pix;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

