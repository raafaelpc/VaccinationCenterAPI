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
    public class VaccinationCentersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VaccinationCentersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationCenter>>> GetVaccinationCenters()
        {
            try
            {
                var centers = await _context.VaccinationCenters.Include(x => x.Vaccines).ToListAsync();
                var centersDTO = _mapper.Map<List<VaccinationCenter>>(centers);
                return Ok(centersDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os postos de vacinação");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationCenterDto>> AddVaccinationCenter(VaccinationCenterDto vaccinationCenterDTO)
        {
            try
            {
                if (await _context.VaccinationCenters.AnyAsync(x => x.Name == vaccinationCenterDTO.Name))
                    return BadRequest("O posto de vacinação com esse nome já existe.");

                var center = _mapper.Map<VaccinationCenter>(vaccinationCenterDTO);

                _context.VaccinationCenters.Add(center);
                await _context.SaveChangesAsync();

                var createdDTO = _mapper.Map<VaccinationCenterDto>(center);
                return CreatedAtAction(nameof(GetVaccinationCenters), new { id = createdDTO.Id }, createdDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar um posto de vacinação");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccinationCenter(int id)
        {
            try
            {
                var center = await _context.VaccinationCenters.Include(vc => vc.Vaccines).FirstOrDefaultAsync(x => x.Id == id);
                if (center == null)
                    return NotFound();

                if (center.Vaccines.Any())
                    return BadRequest("Não é possível eliminar um posto de vacinação com vacinas associadas.");

                _context.VaccinationCenters.Remove(center);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar um posto de vacinação.");
            }
        }
    }

}
