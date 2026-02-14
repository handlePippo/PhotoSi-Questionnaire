using Microsoft.AspNetCore.Mvc;
using PhotoSi.Infrastructure.Application.DTOs;
using PhotoSi.Infrastructure.Application.Service;
using System.Net;

namespace PhotoSi.Questionnaire.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/questionnaire")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public QuestionnaireController(IQuestionnaireService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyList<QuestionItemDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<QuestionItemDto>>> GetAll(CancellationToken token)
        {
            var resultDto = await _service.GetAllAsync(token);

            if (resultDto is null)
            {
                return NotFound();
            }

            return Ok(resultDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(QuestionItemDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<QuestionItemDto>> GetById([FromRoute] int id, CancellationToken token)
        {
            var item = await _service.GetByIdAsync(id, token);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet("search")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyList<QuestionItemDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<QuestionItemDto>>> Search([FromQuery] string term, CancellationToken token)
        {
            var resultDto = await _service.SearchAsync(term, token);
            if (resultDto is null)
            {
                return NotFound();
            }

            return Ok(resultDto);
        }
    }
}

