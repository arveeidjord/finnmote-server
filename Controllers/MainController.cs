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
    public class MainController : ControllerBase
    {
        private readonly FinnMoteContext _context;

        public MainController(FinnMoteContext context)
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
        
        
        [HttpGet]
        public ActionResult<MainDto> Index(int arrangoerId)
        {
            return new MainDto{
                ValgtArrangoer = _context.Arrangoerer.Find(arrangoerId)
            };
        }

    }
}