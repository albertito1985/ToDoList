using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Domain;

namespace ToDoList.Application.Services
{
    public class ToDoListService(IUnitOfWork uow) : IToDoListService
    {
        public async Task<ToDoListList> GetAsync(int id)
        {
            var response = await uow.ToDoListListRepository.GetListAsync(id);
            if (response== null)
            {
                Console.WriteLine("Response null");
            }
            return response;
        }

        public void Create(ToDoListList toDoList)
        {

        }

        public void Edit(int id, ToDoListList newToDoList)
        {

        }
        public void Delete(int id)
        {

        }
    }
}
