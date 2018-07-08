using System;
using System.ComponentModel.DataAnnotations;

namespace FinnMote.Api.Models
{

    public class Arrangement
    {
        public int Id { get; set; }

        public int ArrangoerId {get; set; }
        public Arrangoer Arrangoer { get; set; }

        [Required]
        public string Beskrivelse { get; set; }
        
        [Required]
        public DateTime Tidspunkt { get; set; }

        [Required]
        public DateTime OpprettetTidspunkt { get; set; }

        [Required]
        public string OpprettetAv{ get; set; }

    }

}