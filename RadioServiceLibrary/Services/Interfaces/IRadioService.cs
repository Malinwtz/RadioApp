using RadioServiceLibrary.RadioApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioServiceLibrary.Services.Interfaces
{
    public interface IRadioService
    {

        Task<List<RadioProgram>> GetProgramsFromChannelIdAsync(string channelId);
        Task<List<RadioProgram>> GetJsonRadioPrograms();
    }
}
