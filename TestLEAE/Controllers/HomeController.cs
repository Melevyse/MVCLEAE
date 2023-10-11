using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestLEAE.BusinessLayer;
using TestLEAE.DataLayer;
using TestLEAE.ModelsView;

namespace TestLEAE.Controllers;

public class HomeController : Controller
{
    private readonly IClientOperationsService _clientOperationsService;
    private readonly IFounderOperationsService _founderOperationsService;
    private readonly IMapper _mapper;
    public HomeController(
        IClientOperationsService clientOperationsService,
        IFounderOperationsService founderOperationsService,
        IMapper mapper)
    {
        _clientOperationsService = clientOperationsService;
        _founderOperationsService = founderOperationsService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ClientSearch()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetClientByType(
        ClientType type)
    {
        var model = _mapper
            .Map<List<ClientView>>(await _clientOperationsService
            .GetClientsListByType(type));
        return View(model);
    }

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

    [HttpPost]
    public async Task<IActionResult> CreateFounder(
        FounderView founderView) 
    {
        var mappingResource = _mapper.Map<Founder>(founderView);
        await _founderOperationsService
            .AddFounderAsync(mappingResource, founderView.InnClient);
        return View();
    }

    [HttpGet]
    public IActionResult Error(
        int code)
    {
        return View(code);
    }
}
