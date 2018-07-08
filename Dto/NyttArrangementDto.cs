using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinnMote.Api.Models
{

    public class NyttArrangementDto
    {
        public int ArrangoerId {get; set; }

        [Required]
        public string Beskrivelse { get; set; }
        
        [Required]
        public DateTime Tidspunkt { get; set; }

    }

}