using System;
using System.Collections.Generic;
using libraryApi.Models;
using libraryApi.Services;
using librayApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace libraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _as;
        private readonly BooksService _bs;
        public AuthorsController(AuthorsService auths, BooksService bs)
        {
            _as = auths;
            _bs = bs;
        }

        // get all
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            try
            {
                return Ok(_as.Get());
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // get by id
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            try
            {
                return Ok(_as.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/shoes")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthorId(int id)
        {
            try
            {
                return Ok(_bs.GetBooksByAuthorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // create 
        [HttpPost]
        public ActionResult<Author> Create([FromBody] Author newAuthor)
        {
            try
            {
                return Ok(_as.Create(newAuthor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // update
        [HttpPut("{id}")]
        public ActionResult<Author> Update(int id, [FromBody] Author updatedAuthor)
        {
            try
            {
                updatedAuthor.Id = id;
                return Ok(_as.Edit(updatedAuthor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // delete
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            try
            {
                return Ok(_as.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
