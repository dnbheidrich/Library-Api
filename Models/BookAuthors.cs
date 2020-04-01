using System.ComponentModel.DataAnnotations;

namespace libraryApi.Models
{
      public class BookAuthors
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
         public class DBBookAuthor : BookAuthors
    {
        public int baId { get; set; }
    }
    }
}