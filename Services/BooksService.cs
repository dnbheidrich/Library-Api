
using System;
using System.Collections.Generic;
using libraryApi.Repositories;
using librayApi.Models;

namespace libraryApi.Services
{
    public class BooksService
    {
        private readonly BooksRepository _repo;
        public BooksService(BooksRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Book> Get()
        {
            return _repo.Get();
        }

        public Book Get(int id)
        {
            Book found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
        internal object GetBooksByLibraryId(int id)
    {
            return _repo.GetBooksByLibraryId(id);
      
    }

        public Book Create(Book newBook)
        {
            return _repo.Create(newBook);
        }

        public Book Edit(Book updatedBook)
        {
            Book exists = _repo.Get(updatedBook.Id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Edit(updatedBook);
        }

        public string Delete(int id)
        {
            Book exists = _repo.Get(id);
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

    internal object GetBooksByAuthorId(int id)
    {
            return _repo.GetBooksByAuthorId(id);

    }
  }
}