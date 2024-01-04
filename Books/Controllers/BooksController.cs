using Books.Common;
using Books.Interface;
using ClassLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }
        [HttpGet]
        [Route("BookDetails")]
        public async Task<IActionResult> GetBookDetailsAsync()
        {
            try
            {
                var res = await _bookService.GetBookDetailsAsync();
                //var json = JsonConvert.SerializeObject(res, new LookupSerializer());
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("PublisherDetails")]
        public async Task<IActionResult> GetPublisherDetailsAsync(string sortColumn, string sortOrder)
        {
            try
            {
                var res = await _bookService.GetPublisherDetailsAsync(sortColumn, sortOrder);
                //var json = JsonConvert.SerializeObject(res, new LookupSerializer());
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("PublisherLQDetails")]
        public async Task<IActionResult> GetPublisherDetailsLQAsync(string sortColumn, string sortOrder)
        {
            try
            {
                var res = await _bookService.GetPublisherDetailsLQAsync(sortColumn, sortOrder); 
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
        

        [HttpGet]
        [Route("AuthorDetails")]
        public async Task<IActionResult> GetAuthorDetailsAsync(string sortColumn, string sortOrder)
        {
            try
            {
                var res = await _bookService.GetAuthorDetailsAsync(sortColumn, sortOrder);
                //var json = JsonConvert.SerializeObject(res, new LookupSerializer());
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("AuthorLQDetails")]
        public async Task<IActionResult> GetAuthorDetailsLQAsync(string sortColumn, string sortOrder)
        {
            try
            {
                var res = await _bookService.GetAuthorDetailsLQAsync(sortColumn, sortOrder);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("TotalPrice")]
        public async Task<IActionResult> GetTotalPriceAsync()
        {
            try
            {
                var res = await _bookService.GetBookTotalPriceAsync();
                var json = JsonConvert.SerializeObject(res, new LookupSerializer());
                return Ok(new { totalPrice = json });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpPost]
        [Route("SaveBookDetails")]
        public async Task<IActionResult> SaveBookDetails(IEnumerable<BookInputDTO> UpdateBookDetailsRequest)
        {
            try
            {
                var res = await _bookService.SaveBookDetailsAsync(UpdateBookDetailsRequest);
                var json = JsonConvert.SerializeObject(res, new LookupSerializer());
                return Ok(new { RecordStatus = json });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

    }
}
