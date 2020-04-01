using System;
using System.ComponentModel.DataAnnotations;

namespace librayApi.Models
{

     public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public int LibraryId { get; set; }
        public bool IsAvailable { get; set; }
    }
  }




 