using System.Collections.Generic;
using System.Data;
using Dapper;
using librayApi.Models;

namespace libraryApi.Repositories
{
    public class LibrariesRepository
    {
        private readonly IDbConnection _db;
        public LibrariesRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Library> Get()
        {
            string sql = "SELECT * FROM libraries";
            return _db.Query<Library>(sql);
        }

        public Library Get(int Id)
        {
            string sql = "SELECT * FROM libraries WHERE id = @Id";
            return _db.QueryFirstOrDefault<Library>(sql, new { Id });
        }
        
        public Library Create(Library newLibrary)
        {
            string sql =  @"
            INSERT INTO libraries
            (title, location)
            VALUES
            (@Title, @Location);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newLibrary);
            newLibrary.Id = id;
            return newLibrary;
        }

        public Library Edit(Library updatedLibrary)
        {
            string sql = @"
            UPDATE libraries
            SET
                title = @Title,
            WHERE id = @Id;
            ";
            _db.Execute(sql, updatedLibrary);
            return updatedLibrary;
        }

        public bool Delete(int Id)
        {
            string sql = "DELETE FROM libraries WHERE id = @Id LIMIT 1";
            int changed = _db.Execute(sql, new { Id });
            return changed == 1;
        }
    }
}