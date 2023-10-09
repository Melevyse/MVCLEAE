using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestLEAE.BusinessLayer;
using TestLEAE.DataLayer;
using TestLEAE.ModelsView;

namespace TestLEAE.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClientOperationsService _clientOperationsService;
    private readonly IFounderOperationsService _founderOperationsService;
    private readonly IMapper _mapper;
    public HomeController(
        ILogger<HomeController> logger,
        IClientOperationsService clientOperationsService,
        IFounderOperationsService founderOperationsService,
        IMapper mapper)
    {
        _logger = logger;
        _clientOperationsService = clientOperationsService;
        _founderOperationsService = founderOperationsService;
        _mapper = mapper;
    }

    [HttpGet]
    // Default page
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ClientSearch()
    {
        return View();
    }

    // Get all Clients info by type
    [HttpGet]
    public async Task<IActionResult> GetClientByType(
        ClientType type)
    {
        var model = _mapper
            .Map<List<ClientView>>(await _clientOperationsService
            .GetClientsListByType(type));
        return View(model);
    }

    // Get Client info
    [HttpGet]
    public async Task<IActionResult> GetClientByInn(
        long inn)
    {
        Console.WriteLine(inn);
        var model = _mapper
            .Map<ClientView>(await _clientOperationsService
            .GetClientByInn(inn));
        return View(model);
    }

    // Get all Founders of the selected Client
    [HttpGet]
    public async Task<IActionResult> GetFounder(
        long clientInn)
    {
        var model = _mapper
            .Map<List<FounderView>>(await _founderOperationsService
            .GetFounderListByClientInn(clientInn));
        return View(model);
    }

    [HttpGet]
    public IActionResult CreateClient()
        => View();

    // Add Client
    [HttpPost]
    public async Task<IActionResult> CreateClient(
        ClientView clientView)
    {
        var mappingResource = _mapper.Map<Client>(clientView);
        await _clientOperationsService
            .AddClientAsync(mappingResource);
        return View();
    }

    [HttpGet]
    public IActionResult CreateFounder()
        => View();

    // Add Founder for Client
    [HttpPost]
    public async Task<IActionResult> CreateFounder(
        FounderView founderView) 
    {
        var mappingResource = _mapper.Map<Founder>(founderView);
        await _founderOperationsService
            .AddFounderAsync(mappingResource, founderView.InnClient);
        return View();
    }
}
