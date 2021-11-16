using ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Repositories
{
    public class ZadaniaRepository : IZadaniaRepsitory
    {
        private readonly ZadaniaManagerContex _context;
        public ZadaniaRepository(ZadaniaManagerContex context)
        {
            _context = context;
        }

        public void Add(ZadaniaModelcs zadania)
        {
           
            _context.Zadanias.Add(zadania);
            _context.SaveChanges();
        }

        public void Delete(int ZadaniaId)
        {
            var result = _context.Zadanias.SingleOrDefault(x => x.ZadaniaId == ZadaniaId);
            if(result != null)
            {
                _context.Zadanias.Remove(result);
                _context.SaveChanges();
            }
        }

        public ZadaniaModelcs Get(int ZadaniaId)
        {
            return _context.Zadanias.SingleOrDefault(x => x.ZadaniaId == ZadaniaId);
        }

        public IQueryable<ZadaniaModelcs> GetAllActive()
        {
            return _context.Zadanias.Where(x => !x.Gotowe && x.Data > DateTime.Now);
        }

        public IQueryable<ZadaniaModelcs> GetZadaniaWykonane()
        {
            return _context.Zadanias.Where(x => x.Gotowe );
        }

        public IQueryable<ZadaniaModelcs> GetZadaniaPoCzasie()
        {
            return _context.Zadanias.Where(x => x.Data <= DateTime.Now && !x.Gotowe);
        }

        public void Update(int ZadaniaId, ZadaniaModelcs zadania)
        {
            var result = _context.Zadanias.SingleOrDefault(x => x.ZadaniaId == ZadaniaId);
            if (result != null)
            {
                result.Nazwa = zadania.Nazwa;
                result.Szczegóły = zadania.Szczegóły;
                result.Data = zadania.Data;

                _context.SaveChanges();
            }
        }

        public void Wykonane(int ZadaniaId, ZadaniaModelcs zadania)
        {
            var result = _context.Zadanias.SingleOrDefault(x => x.ZadaniaId == ZadaniaId);
            if(result != null)
            {
                result.Gotowe = true;
                _context.SaveChanges();
            }
        }
    }
}
