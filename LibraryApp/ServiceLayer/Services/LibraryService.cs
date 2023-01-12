using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryRepository _repo;
        private int _count = 1;

        public LibraryService()
        {
            _repo = new LibraryRepository();
        }


        public Library Create(Library library)
        {
            library.Id = _count;

            Library existLibrary = _repo.Get(m => m.Name.ToLower() == library.Name.ToLower());

            if (existLibrary != null) throw new Exception("Data already exist");

            _repo.Create(library);
            _count++;
            return library;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Library dbLibrary = _repo.Get(m => m.Id == id);

            if (dbLibrary == null) throw new NullReferenceException("Data notfound");

            _repo.Delete(dbLibrary);
            
        }

        public List<Library> GetAll()
        {
            return _repo.GetAll();
        }

        public Library GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Library> Search(string searchText)
        {
            List<Library> libraries = _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()));

            if (libraries.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);

            return libraries;
        }

        public Library Update(int id, Library library)
        {
            throw new NotImplementedException();
        }
    }
}
