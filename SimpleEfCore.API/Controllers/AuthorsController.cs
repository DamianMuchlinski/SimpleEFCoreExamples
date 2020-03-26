using Microsoft.AspNetCore.Mvc;
using SimpleEfCore.API.Services;
using System;

namespace SimpleEfCore.API.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorsController(AuthorRepository authorRepository )
        {
            _authorRepository = authorRepository;
        }

        [Route("{workbookId}")]
        [HttpGet]
        public ActionResult GetWorkbookByIdAsync(string workbookId)
        {
            _authorRepository.GetAuthors();
            return Ok();
        }

        [Route("{authorId}")]
        [HttpGet]
        public ActionResult GetAuthorsById(string authorId)
        {
            var authors = _authorRepository.GetAuthor(Guid.Parse(authorId));
            return Ok(authors);
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors();
            return Ok(authors);
        }
    }
}
