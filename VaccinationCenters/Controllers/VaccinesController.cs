using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaccinationCenters.Data;
using VaccinationCenters.DTOs;
using VaccinationCenters.Models;

namespace VaccinationCenters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VaccinesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineDto>>> GetVaccines()
        {
            try
            {
                var vaccines = await _context.Vaccines.ToListAsync();
                var vaccinesDTO = _mapper.Map<List<VaccineDto>>(vaccines);
                return Ok(vaccinesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar as vacinas.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VaccineDto>> AddVaccine(VaccineDto vaccineDTO)
        {
            try
            {
                if (await _context.Vaccines.AnyAsync(x => x.Batch == vaccineDTO.Batch))
                    return BadRequest("Uma vacina com esse lote já existe.");

                if (vaccineDTO.ExpiryDate <= DateTime.Now)
                    return BadRequest("A data de validade precisa ser uma data futura.");

                var vaccine = _mapper.Map<Vaccine>(vaccineDTO);

                _context.Vaccines.Add(vaccine);
                await _context.SaveChangesAsync();

                var createdDTO = _mapper.Map<VaccineDto>(vaccine);
                return CreatedAtAction(nameof(GetVaccines), new { id = createdDTO.Id }, createdDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar a vacina.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            try
            {
                var vaccine = await _context.Vaccines.FindAsync(id);
                
                if (vaccine == null)
                    return NotFound();

                _context.Vaccines.Remove(vaccine);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar a vacina.");
            }
        }
    }


}
