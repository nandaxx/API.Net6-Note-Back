using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.PersonDTOs;
using Service.Interfaces;

namespace NoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var response = await _personService.FindAll();
            if (response.Code == 200) return Ok(response);
            return BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var response = await _personService.FindById(id);
            if (response.Code == 200) return Ok(response);
            if (response.Code == 406) return Problem(statusCode: 406, title: "Caracter Not Acceptable");
            if (response.Code == 404) return NotFound();
            return BadRequest(response);

        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PersonCreateDTO dto)
        {
            var response = await _personService.Create(dto);
            if (response.Code == 201) return StatusCode(201);
            return BadRequest(response);

        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PersonUpdateDTO dto)
        {
            var response = await _personService.Update(dto);
            if (response.Code == 200) return Ok(response);
            if (response.Code == 404) return NotFound();
            return BadRequest(response);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _personService.Delete(id);
            if (response.Code == 200) return Ok(response);
            if (response.Code == 406) return Problem(statusCode: 406, title: "Caracter Not Acceptable");
            if (response.Code == 404) return NotFound();
            return BadRequest(response);

        }

    }
}
