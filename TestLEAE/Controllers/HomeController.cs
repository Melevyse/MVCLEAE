using Microsoft.AspNetCore.Http.HttpResults;
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
        return View();
    }

    // Get Client info
    public async Task<IActionResult> GetClient(
        string clientName)
    {
       return View();
    }

    // Get all Founders of the selected Client
    public async Task<IActionResult> GetFounder(
        string clientName,
        string clientType)
    {
        return View();
    }

    // Add Client
    public async Task<IActionResult> AddClient(
        string name,
        string inn,
        string type)
    {
        return Ok();
    }

    // Add Founder for Client
    public async Task<IActionResult> AddFounder(
        string Name,
        string Inn) 
    {
        return Ok();
    }
}
