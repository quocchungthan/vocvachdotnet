using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleEventScheduling.BusinessLayer.Services;
using EasyAppleNotes.ModuleEventScheduling.Models;

namespace EasyAppleNotes.ModuleEventScheduling.BusinessLayer.ServiceImpl
{
    public class EventSchedulingService: IEventSchedulingService
    {
        public EventSchedulingService()
        {
        }

        public Task<IEnumerable<Guid>> ScheduleEvents(EasyAppleEventDefinition eventDefinition)
        {
            throw new NotImplementedException();
        }
    }
}
