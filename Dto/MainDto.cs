using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinnMote.Api.Models
{

    public class MainDto
    {
        public Arrangoer ValgtArrangoer {get; set;}
        public BrukerGruppeTyper Brukergruppe {get; set;}

    }

    public enum BrukerGruppeTyper
    {
        Ingen = 0,
        Standard = 1,
        ArrangoerAdmin = 2,
        Super = 99
    }

}