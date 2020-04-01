using System;
using System.Collections.Generic;
using libraryApi.Models;
using libraryApi.Repositories;

namespace libraryApi.Services
{
    public class AuthorsService
    {
        private readonly AuthorsRepository _repo;
        public AuthorsService(AuthorsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Author> Get()
        {
            return _repo.Get();
        }

        internal Author Get(int id)
        {
            Author found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Author Create(Author newAuthor)
        {
            Author created = _repo.Create(newAuthor);
            if (created == null)
            {
                throw new Exception("Create Request Failed");
            }
            return created;
        }

        internal Author Edit(Author updatedAuthor)
        {
            Author original = Get(updatedAuthor.Id);
            original.Name = updatedAuthor.Name;
            _repo.Edit(original);
            return original;
        }

        internal String Delete(int id)
        {
            if (_repo.Delete(id))
            {
                return "Successfully Deleted";
            }
            throw new Exception("Invalid Id");
        }
    }
}