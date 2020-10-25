using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleEventScheduling.Models;

namespace EasyAppleNotes.ModuleEventScheduling.BusinessLayer.Services
{
    public interface IEventQueryService
    {
        Task<IEnumerable<EasyAppleEvent>> GetEvents(DateTime from, DateTime to, int take, int skip);
    }
}
