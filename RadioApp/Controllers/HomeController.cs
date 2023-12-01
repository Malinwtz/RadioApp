using Mapster;
using Microsoft.AspNetCore.Mvc;
using RadioApp.Models;
using RadioServiceLibrary.ProgramApiModels;
using RadioServiceLibrary.Services.Interfaces;
using System;
using System.Diagnostics;

namespace RadioApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger, IRadioService radioService)
        {
            _logger = logger;
            _radioService = radioService;
        }
        private readonly ILogger<HomeController> _logger;
        private readonly IRadioService _radioService;

        public async Task<IActionResult> Index()
        {
            var allPrograms = await _radioService.GetAllProgramsAsync();

            // MAPSTER  https://www.youtube.com/watch?v=vBs6naPD6RE

            //// Om mappning ska ske från tvåolika properties till en:
            //var config = new TypeAdapterConfig();
            //config.NewConfig<RadioProgram, ProgramViewModel>() // från vilket objekt till vilket objekt som det ska mappas
            //    .Map(dest => dest.Name, src => $"{src.Name} {src.Channel}");  // I den här raden säger vi vilken property som ska tilldelas vad för värde

            //var programViewModels = allPrograms.Adapt<List<ProgramViewModel>>(config);  // måste stoppa in config här för att det ska fungera. Utan config
            //kommer propertien bara att ignoreras och förbli tom om det inte finns något motsvarande värde i objektet som vi ska hämta propertien ifrån. 

            // För att ignorera properties som vi inte vill ska mappas:
            //var config = new TypeAdapterConfig();
            //config.NewConfig<RadioProgram, ProgramViewModel>() // från vilket objekt till vilket objekt som det ska mappas
            //    .Map(dest => dest.Name, src => $"{src.Name} {src.Channel}");  // I den här raden säger vi vilken property som ska tilldelas vad för värde
            //    .IgnoreNonMapped(true);  //Detta gör att alla properties som inte skrivits in här kommer att ignoreras och mappas inte om. 

            // För att slippa skriva in config varje gång någonting ska pa++mappas om kan man lägga till .GlobalSettings
            //var config = new TypeAdapterConfig.GlobalSettings; 
            // Nu slipper vi skriva in config i denna rad: var programViewModels = allPrograms.Adapt<List<ProgramViewModel>>(); 

            // Annat sätt att skriva samma sak
            //  Denna kod:
            //config.NewConfig<RadioProgram, ProgramViewModel>() 
            //    .Map(dest => dest.Name, src => $"{src.Name} {src.Channel}");
            //  Kan ersättas med: 
            //TypeAdapterConfig<RadioProgram, ProgramViewModel>.NewConfig()
            //    .Map(dest => dest.Name, src => $"{src.Name} {src.Channel}");

            // För att inte skriva över konfigurationen:
            //config.ForType<RadioProgram, ProgramViewModel>() 
            //    .Map(dest => dest.Name, src => $"{src.Name} {src.Channel}");

            var programViewModels = allPrograms.Adapt<List<ProgramViewModel>>();

            //var programViewModels = allPrograms.Select(program => new ProgramViewModel
            //{
            //    Id = program.Id,
            //    Name = program.Name,
            //    Description = program.Description,
            //    ProgramImage = program.ProgramImage,
            //    Channel = new ChannelViewModel
            //    {
            //        Id = program.Channel.Id,
            //        Name = program.Channel.Name,
            //    },
            //    LatestEpisodes = program.LatestEpisodes.Select(episode => new EpisodeViewModel
            //    {
            //        Id = episode.Id,
            //        Title = episode.Title,
            //        Description = episode.Description,
            //        AudioUrl = episode.AudioUrl
            //    }).ToList()
            //}).ToList();

            var sortedPrograms = programViewModels.OrderByDescending(p => p.Channel.Name).ToList();

            return View(sortedPrograms);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}