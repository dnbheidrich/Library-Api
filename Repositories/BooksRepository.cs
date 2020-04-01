using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using librayApi.Models;

namespace libraryApi.Repositories
{
    public class BooksRepository
    {
        private readonly IDbConnection _db;
        public BooksRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Book> Get()
        {
            string sql = "SELECT * FROM books";
            return _db.Query<Book>(sql);
        }

        public Book Get(int Id)
        {
            string sql = "SELECT * FROM books WHERE id = @Id";
            return _db.QueryFirstOrDefault<Book>(sql, new { Id });
        }
        internal object GetBooksByLibraryId(int Id)
    {
            string sql = "SELECT * FROM books WHERE libraryId = @Id";
            return _db.Query<Book>(sql, new { Id });
    }

        public Book Create(Book newBook)
        {
            string sql = @"
            INSERT INTO books
            (title, author, isAvailable, libraryId)
            VALUES
            (@Title, @Author, @IsAvailable, @LibraryId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newBook);
            newBook.Id = id;
            return newBook;
        }

   

    public Book Edit(Book updatedBook)
        {
            string sql = @"
            UPDATE books
            SET
                title = @Title,
                author = @Author,
                libraryId = @LibraryId 
            WHERE id = @Id;
            ";
            _db.Execute(sql, updatedBook);
            return updatedBook;
        }

    internal object GetBooksByAuthorId(int Id)
    {
      string sql = @"
            SELECT s.* FROM bookauthors ba
            INNER JOIN books b ON b.id = ba.bookId
            WHERE authorId = @Id;";
            return _db.Query<Book>(sql, new { Id });
    }

    public bool Delete(int Id)
        {
            string sql = "DELETE FROM books WHERE id = @Id LIMIT 1";
            int changed = _db.Execute(sql, new { Id });
            return changed == 1;
        }
    }
}


