using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FinnMote.Api.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace FinnMote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrangementController : ControllerBase
    {
        private readonly FinnMoteContext _context;

        public ArrangementController(FinnMoteContext context)
        {
            _context = context;

            if (_context.Arrangementer.Count() == 0)
            {
                _context.Arrangoerer.Add(new Arrangoer{ Navn = "Høvåg kirke"});
                _context.Arrangoerer.Add(new Arrangoer{ Navn = "Frikstad bedehust"});

                _context.Arrangementer.Add(new Arrangement {ArrangoerId = 1, Beskrivelse = "Item1", Tidspunkt = DateTime.Now });
                _context.Arrangementer.Add(new Arrangement {ArrangoerId = 2, Beskrivelse = "Item2", Tidspunkt = new DateTime(2018,7,21, 11, 0, 0) });
                _context.Arrangementer.Add(new Arrangement {ArrangoerId = 2, Beskrivelse = "Item3", Tidspunkt = new DateTime(2018,7,21, 11, 0, 0) });


                _context.Arrangementer.Add(new Arrangement {ArrangoerId = 1, Beskrivelse = "Item4", Tidspunkt = new DateTime(2018,7, 5, 11, 0, 0) });

                _context.SaveChanges();
            }

        }  

        [HttpGet("arrangementliste")]
        public ActionResult<List<Arrangement>> Get(int arrangoerId)
        {
            return _context.Arrangementer
            .Include(x => x.Arrangoer)
            .Where(x => x.ArrangoerId == arrangoerId).OrderBy(x => x.Tidspunkt).ToList();
        }

        
        [HttpGet]
        public ActionResult<List<Arrangement>> GetAll()
        {
            return _context.Arrangementer.ToList();
        }

        [HttpPost("sok")]
        public ActionResult<ArrangementlisteResultatDto> Sok([FromBody] ArrangementlisteFilterDto filter)
        {
            var a = _context.Arrangementer
                .Include(x => x.Arrangoer).Where(x => x == x);


            if (filter != null && filter.Arrangoerer != null && filter.Arrangoerer.Count > 0)
            {
                a = a.Where(x => filter.Arrangoerer.Contains(x.ArrangoerId));
            }

            var arr = new ArrangementlisteResultatDto{
                Arrangoerer = _context.Arrangoerer.ToList(),
                Arrangementer = a.ToList()
            };

            return arr;
        }

        [HttpGet("{id}", Name="GetArrangement")]
        public ActionResult<Arrangement> GetById(int id)
        {
            var item = _context.Arrangementer.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }   

        [HttpPost]
        public IActionResult Create(NyttArrangementDto inn)
        {
            //TODO: Sjekk på at id er 0 ?

            if (inn.Tidspunkt == DateTime.MinValue)
                return BadRequest("Mangler tidspunkt");

            if (inn.ArrangoerId == 0)
                return BadRequest("Mangler arrangoerId");

            var item = new Arrangement{
                OpprettetAv = "Test", //TODO
                OpprettetTidspunkt = DateTime.Now,
                ArrangoerId = inn.ArrangoerId, //TODO: Sjekk at bruker har rettighet til å opprette på denne arrangoerId
                Beskrivelse = inn.Beskrivelse,
                Tidspunkt = inn.Tidspunkt
            };

            _context.Arrangementer.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetArrangement", new { id = item.Id }, item);
        }  

        [HttpPut("{id}")]
        public IActionResult Update(int id, Arrangement item)
        {
            var arrangement = _context.Arrangementer.Find(id);
            if (arrangement == null)
            {
                return NotFound();
            }

            item.Id = id;

            // arrangement.IsComplete = item.IsComplete;
            // arrangement.Name = item.Name;

            _context.Arrangementer.Update(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}