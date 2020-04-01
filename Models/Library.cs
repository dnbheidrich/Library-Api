using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace librayApi.Models
{

     public class Library
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Location { get; set; }


    }

  }




 