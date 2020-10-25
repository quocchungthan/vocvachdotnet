using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleEventScheduling.Models;

namespace EasyAppleNotes.ModuleEventScheduling.BusinessLayer.Services
{
    // CQRS
    public interface IEventSchedulingService
    {
        Task<IEnumerable<Guid>> ScheduleEvents(EasyAppleEventDefinition eventDefinition);
    }
}
