using Microsoft.AspNetCore.Mvc;
using TestLEAE.BusinessLayer;

namespace TestLEAE.Controllers;

[Route("api/[controller]")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClientOperationsService _clientOperationsService;
    private readonly IFounderOperationsService _founderOperationsService;
    public HomeController(
        ILogger<HomeController> logger,
        IClientOperationsService clientOperationsService,
        IFounderOperationsService founderOperationsService) 
    {
        _logger = logger;
        _clientOperationsService = clientOperationsService;
        _founderOperationsService = founderOperationsService;
    }

    // Default page
    public async Task<IActionResult> Index() 
    {
        
        return View();
    }

    // Get all Clients info
    public async Task<IActionResult> GetClients() 
    {
        return Ok();
    }

    // Get all Founders of the selected Client
    public async Task<IActionResult> GetFounder()
    {
        return View();
    }
}
