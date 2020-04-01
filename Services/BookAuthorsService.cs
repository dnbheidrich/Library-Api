using System;
using System.Collections.Generic;
using libraryApi.Models;
using libraryApi.Repositories;

namespace libraryApi.Services
{
    public class BookAuthorsService
    {
        private readonly BookAuthorsRepository _repo;
        public BookAuthorsService(BookAuthorsRepository repo)
        {
            _repo = repo;
        }

        internal BookAuthors Get(int id)
        {
            BookAuthors found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal BookAuthors Create(BookAuthors newBookAuthors)
        {
            BookAuthors created = _repo.Create(newBookAuthors);
            if (created == null)
            {
                throw new Exception("Create Request Failed");
            }
            return created;
        }
        internal String Delete(BookAuthors cs)
        {
            if (_repo.Delete(cs))
            {
                return "Successfully Deleted";
            }
            throw new Exception("Invalid Id");
        }
    }
}