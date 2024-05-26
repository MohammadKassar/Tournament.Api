using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Data;
using Tournament.Data.Data;
using Tournament.Core.Repositories;
using AutoMapper;
using Tournament.Core.Dto;


namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TournamentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournaments()
        {
            var tournaments = await _unitOfWork.TournamentRepository.GetAllAsync();
            var tournamentDtos = _mapper.Map<IEnumerable<TournamentDto>>(tournaments);
            return Ok(tournamentDtos);
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetTournament(int id)
        {
            var tournament = await _unitOfWork.TournamentRepository.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            var tournamentDto = _mapper.Map<TournamentDto>(tournament);
            return Ok(tournamentDto);
        }

        // PUT: api/Tournaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, TournamentDto tournamentDto)
        {
            if (id != tournamentDto.Id)
            {
                return BadRequest();
            }

            var tournament = await _unitOfWork.TournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _mapper.Map(tournamentDto, tournament);
            _unitOfWork.TournamentRepository.Update(tournament);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // POST: api/Tournaments
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> PostTournament(TournamentDto tournamentDto)
        {
            var tournament = _mapper.Map<TournamentEntity>(tournamentDto);
            _unitOfWork.TournamentRepository.Add(tournament);
            await _unitOfWork.CompleteAsync();

            tournamentDto.Id = tournament.Id;
            return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournamentDto);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _unitOfWork.TournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _unitOfWork.TournamentRepository.Remove(tournament);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
