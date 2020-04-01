using System.Collections.Generic;
using System.Data;
using Dapper;
using libraryApi.Models;

namespace libraryApi.Repositories
{
   
    public class AuthorsRepository
    {
        private readonly IDbConnection _db;
        public AuthorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Author> Get()
        {
            string sql = "SELECT * FROM authors";
            return _db.Query<Author>(sql);
        }

        internal Author Get(int Id)
        {
            string sql = "SELECT * FROM authors WHERE id = @Id";
            return _db.QueryFirstOrDefault<Author>(sql, new { Id });
        }

        internal Author Create(Author newAuthor)
        {
            string sql = @"
            INSERT INTO authors
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            newAuthor.Id = _db.ExecuteScalar<int>(sql, newAuthor);
            return newAuthor;
        }
        internal void Edit(Author updated)
        {
            string sql = @"
            UPDATE authors
            SET
                name = @Name
            WHERE id = @Id;
            ";
            _db.Execute(sql, updated);
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM authors WHERE id = @Id LIMIT 1";
            int deleted = _db.Execute(sql, new { Id });
            return deleted == 1;
        }


    } 
}