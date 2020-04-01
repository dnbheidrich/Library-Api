
using System;
using System.Collections.Generic;
using libraryApi.Repositories;
using librayApi.Models;

namespace libraryApi.Services
{
    public class LibrariesService
    {
        private readonly LibrariesRepository _repo;
        public LibrariesService(LibrariesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Library> Get()
        {
            return _repo.Get();
        }

        public Library Get(int id)
        {
            Library found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        public Library Create(Library newLibrary)
        {
            return _repo.Create(newLibrary);
        }

        public Library Edit(Library updatedLibrary)
        {
            Library exists = _repo.Get(updatedLibrary.Id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Edit(updatedLibrary);
        }

        public string Delete(int id)
        {
            Library exists = _repo.Get(id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            if (_repo.Delete(id))
            {
                return "Success";
            }
            throw new Exception("Something went wrong with deleting that item");
        }

    }
}