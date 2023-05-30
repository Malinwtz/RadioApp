using Microsoft.AspNetCore.Mvc;
using RadioApp.Models;
using RadioServiceLibrary.Services.Interfaces;
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
            var p3ChannelId = "164";

            //var response = await _radioService.GetJsonRadioPrograms();

            //var listOfP3Programs = await _radioService.GetProgramsFromChannelIdAsync(p3ChannelId);

            List<ChannelViewModel> channelList = new List<ChannelViewModel>
            {
                new ChannelViewModel
                {
                    Title ="P3",
                    Programs = new List<ProgramViewModel>
                    {
                        new ProgramViewModel
                        {
                            Title ="Tankesmedjan",
                            Episodes = new List<EpisodeViewModel>
                            {
                                new EpisodeViewModel{ Title = "avsnitt1"},
                                new EpisodeViewModel{ Title = "avsnitt2"},
                                new EpisodeViewModel{ Title = "avsnitt3"},
                            }   
                        },
                        new ProgramViewModel
                        {
                            Title = "Dokumentär",
                            Episodes = new List<EpisodeViewModel>
                            {
                                new EpisodeViewModel{ Title = "avsnitt1"},
                                new EpisodeViewModel{ Title = "avsnitt2"},
                                new EpisodeViewModel{ Title = "avsnitt3"},
                            }
                        }
                    },                   
                },
                new ChannelViewModel
                {
                    Title = "P1",
                    Programs = new List<ProgramViewModel>
                    {
                        new ProgramViewModel
                        {
                            Title ="Tankesmedjan",
                            Episodes = new List<EpisodeViewModel>
                            {
                                new EpisodeViewModel{ Title = "avsnitt1"},
                                new EpisodeViewModel{ Title = "avsnitt2"},
                                new EpisodeViewModel{ Title = "avsnitt3"},
                            }
                        },
                        new ProgramViewModel
                        {
                            Title = "Dokumentär",
                            Episodes = new List<EpisodeViewModel>
                            {
                                new EpisodeViewModel{ Title = "avsnitt1"},
                                new EpisodeViewModel{ Title = "avsnitt2"},
                                new EpisodeViewModel{ Title = "avsnitt3"},
                            }
                        }
                    },
                }
            };

            return View(channelList);
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