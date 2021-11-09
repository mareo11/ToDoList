using ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Repositories
{
    public interface IZadaniaRepsitory
    {
        ZadaniaModelcs Get(int ZadaniaId);
        IQueryable<ZadaniaModelcs> GetAllActive();
        IQueryable<ZadaniaModelcs> GetZadaniaWykonane();
        void Add(ZadaniaModelcs zadania);
        void Update(int ZadaniaId, ZadaniaModelcs zadania);
        void Delete(int ZadaniaId);
        void Wykonane(int ZadaniId, ZadaniaModelcs zadania);
                
    }
}
