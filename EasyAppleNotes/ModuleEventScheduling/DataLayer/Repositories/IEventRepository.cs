using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleEventScheduling.Models;

namespace EasyAppleNotes.ModuleEventScheduling.DataLayer.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Guid>> StoreAsync(IEnumerable<EasyAppleEvent> events);
    }
}
