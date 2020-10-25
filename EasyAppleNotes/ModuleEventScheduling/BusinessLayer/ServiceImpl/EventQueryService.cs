using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleEventScheduling.BusinessLayer.Services;
using EasyAppleNotes.ModuleEventScheduling.Models;

namespace EasyAppleNotes.ModuleEventScheduling.BusinessLayer.ServiceImpl
{
    public class EventQueryService: IEventQueryService
    {
        public EventQueryService()
        {
        }

        public Task<IEnumerable<EasyAppleEvent>> GetEvents(DateTime from, DateTime to, int take, int skip)
        {
            throw new NotImplementedException();
        }
    }
}
