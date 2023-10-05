using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestLEAE.BusinessLayer;
using TestLEAE.DataLayer;

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
        var model = await _clientOperationsService.GetClientsList();
        return View(model);
    }

    // Get Client info
    public async Task<IActionResult> GetClient(
        string clientName)
    {
       var model = await _clientOperationsService.GetClientByName(clientName);
       return View(model);
    }

    // Get all Founders of the selected Client
    public async Task<IActionResult> GetFounder(
        string clientName,
        string clientType)
    {
        var model = await _founderOperationsService.GetFounderListByClientName(clientName);
        return View(model);
    }

    // Add Client
    public async Task<IActionResult> AddClient(
        string name,
        int inn,
        string type)
    {
        await _clientOperationsService.AddClientAsync(name, inn, type);
        return Ok();
    }

    // Add Founder for Client
    public async Task<IActionResult> AddFounder(
        string name,
        string fio,
        int inn) 
    {
        await _founderOperationsService.AddFounderAsync(name, fio, inn);
        return Ok();
    }
}
