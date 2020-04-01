using System;
using System.Collections.Generic;
using libraryApi.Services;
using librayApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace librayApi.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    public class LibrariesController : ControllerBase
    {
        private readonly LibrariesService _ls;
        private readonly BooksService _bs;

        public LibrariesController(LibrariesService vs, BooksService bs)
        {
            _ls = vs;
            _bs = bs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Library>> Get()
        {
            try
            {
                return Ok(_ls.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Library> Get(int id)
        {
            try
            {
                return Ok(_ls.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
         [HttpGet("{id}/books")]  // api/libraries/:id/books
        public ActionResult<IEnumerable<Book>> GetBooksByLibraryId(int id)
        {
            try
            {
                return Ok(_bs.GetBooksByLibraryId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<Library> Create([FromBody] Library newLibrary)
        {
            try
            {
                return Ok(_ls.Create(newLibrary));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Library> Edit(int id, [FromBody] Library updatedLibrary)
        {
            try
            {
                updatedLibrary.Id = id;
                return Ok(_ls.Edit(updatedLibrary));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_ls.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}