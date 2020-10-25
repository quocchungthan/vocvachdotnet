using System;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleEventScheduling.Models;

namespace EasyAppleNotes.ModuleEventScheduling.DataLayer.Repositories
{
    public interface IEventDefinitionRepository
    {
        Task<Guid> StoreAsync(EasyAppleEventDefinition eventDefinition);
    }
}
