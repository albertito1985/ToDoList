using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;

namespace ToDoList.Application.Services
{
    public class ServiceManager(IToDoListService _ToDoListService, IToDoListSingleEntryService _toDoListSingleEntryService) : IServiceManager
    {
        public IToDoListService ToDoListService { get; } = _ToDoListService;
        public IToDoListSingleEntryService ToDoListSingleEntryService { get; } = _toDoListSingleEntryService;
    }

}
