using Microsoft.AspNetCore.Mvc;
using RadioApp.Models;
using System.Diagnostics;

namespace RadioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
                            Category = "Humor",
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
                            Category = "Humor",
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