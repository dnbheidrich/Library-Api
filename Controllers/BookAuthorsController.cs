using System;
using System.Collections.Generic;
using libraryApi.Models;
using libraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace libraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookAuthorsController : ControllerBase
    {
        private readonly BookAuthorsService _bs;
        public BookAuthorsController(BookAuthorsService bs)
        {
            _bs = bs;
        }
        
        [HttpGet("{id}")]
public ActionResult<BookAuthors> Get(int id)
{
    try
    {
        return Ok(_bs.Get(id));
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}

        // create 
        [HttpPost]
        public ActionResult<BookAuthors> Create([FromBody] BookAuthors newBookAuthors)
        {
            try
            {
                return Ok(_bs.Create(newBookAuthors));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // delete
        [HttpPut]  // api/bookauthors/:bookAuthorId
        public ActionResult<BookAuthors> Delete([FromBody] BookAuthors toRemove)
        {
            try
            {
                return Ok(_bs.Delete(toRemove));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}



