using Microsoft.AspNetCore.Mvc;
using RadioApp.Models;
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

            var programViewModels = allPrograms.Select(program => new ProgramViewModel
            {
                Id = program.Id,
                Name = program.Name,
                Description = program.Description,
                ProgramImage = program.ProgramImage,
                Channel = new ChannelViewModel
                {
                    Id = program.Channel.Id,
                    Name = program.Channel.Name,
                },
                LatestEpisodes = program.LatestEpisodes.Select(episode => new EpisodeViewModel
                {
                    Id = episode.Id,
                    Title = episode.Title,
                    Description = episode.Description,
                    AudioUrl = episode.AudioUrl
                }).ToList()
            }).ToList();

            return View(programViewModels);
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