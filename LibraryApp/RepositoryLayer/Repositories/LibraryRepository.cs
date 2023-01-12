using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class LibraryRepository : IRepository<Library>
    {
        public void Create(Library entity)
        {
            if (entity == null) throw new ArgumentNullException();

            AppDbContext<Library>.datas.Add(entity);

        }

        public void Delete(Library entity)
        {
            if (entity == null) throw new ArgumentNullException();

            AppDbContext<Library>.datas.Remove(entity); 
        }

        public Library Get(Predicate<Library> predicate)
        {
            return AppDbContext<Library>.datas.Find(predicate);
        }

        public List<Library> GetAll(Predicate<Library> predicate = null)
        {
            return predicate == null ? AppDbContext<Library>.datas : AppDbContext<Library>.datas.FindAll(predicate);
        }

        public void Update(Library entity)
        {
            throw new NotImplementedException();
        }
    }
}
