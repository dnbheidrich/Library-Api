using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using libraryApi.Models;

namespace libraryApi.Repositories
{
    public class BookAuthorsRepository
    {
        private readonly IDbConnection _db;
        public BookAuthorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal BookAuthors Get(int Id)
        {
            string sql = "SELECT * FROM bookauthors WHERE id = @Id";
            return _db.QueryFirstOrDefault<BookAuthors>(sql, new { Id });
        }

        internal BookAuthors Create(BookAuthors newBookAuthors)
        {
            string sql = @"
            INSERT INTO bookauthors
            (authorId, bookId)
            VALUES
            (@AuthorId, @BookId);
            SELECT LAST_INSERT_ID();
            ";
            newBookAuthors.Id = _db.ExecuteScalar<int>(sql, newBookAuthors);
            return newBookAuthors;
        }

        internal bool Delete(BookAuthors cs)
        {
            string sql = "DELETE FROM bookauthors WHERE authorId = @AuthorId AND bookId = @bookId";
            int deleted = _db.Execute(sql, cs);
            return deleted == 1;
        }


    }
}