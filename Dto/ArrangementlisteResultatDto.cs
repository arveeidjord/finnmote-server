using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinnMote.Api.Models
{

    public class ArrangementlisteResultatDto
    {
        // public int TotaltAntall { get; set; }
        // public int Side { get; set; }

        public IEnumerable<Arrangement> Arrangementer {get; set;}
        public IEnumerable<Arrangoer> Arrangoerer {get; set;}
    }

}