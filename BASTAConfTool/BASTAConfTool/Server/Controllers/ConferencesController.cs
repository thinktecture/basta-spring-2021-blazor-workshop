using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BASTAConfTool.Server.Models;
using BASTAConfTool.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BASTAConfTool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly ConferencesDbContext _context;
        private readonly IMapper _mapper;

        public ConferencesController(ConferencesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Conferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConferenceOverview>>> GetConferences()
        {
            var confs = await _context.Conferences.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ConferenceOverview>>(confs));
        }

        // GET: api/Conferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceDetails>> GetConference(Guid id)
        {
            var conference = await _context.Conferences.FindAsync(id);

            if (conference == null)
            {
                return NotFound();
            }

            return _mapper.Map<Shared.DTO.ConferenceDetails>(conference);
        }

        // POST: api/Conferences
        [HttpPost]
        public async Task<ActionResult<ConferenceDetails>> PostConference(ConferenceDetails conference)
        {
            var conf = _mapper.Map<Conference>(conference);

            _context.Conferences.Add(conf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConference", new { id = conference.ID }, conf);
        }
    }
}
