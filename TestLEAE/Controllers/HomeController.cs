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
    public async Task<IActionResult> GetClients(
        ClientType type) 
    {
        var model = await _clientOperationsService
            .GetClientsListByType(type);
        return View(model);
    }

    // Get Client info
    public async Task<IActionResult> GetClient(
        long inn)
    {
        var model = await _clientOperationsService
            .GetClientByInn(inn);
       return View(model);
    }

    // Get all Founders of the selected Client
    public async Task<IActionResult> GetFounder(
        long clientInn)
    {
        var model = await _founderOperationsService
            .GetFounderListByClientInn(clientInn);
        return View(model);
    }

    // Add Client
    public async Task<IActionResult> AddClient(
        string name,
        long inn,
        ClientType type)
    {
        await _clientOperationsService
            .AddClientAsync(name, inn, type);
        return Ok();
    }

    // Add Founder for Client
    public async Task<IActionResult> AddFounder(
        long clientInn,
        string fio,
        long inn) 
    {
        await _founderOperationsService
            .AddFounderAsync(clientInn, fio, inn);
        return Ok();
    }
}
