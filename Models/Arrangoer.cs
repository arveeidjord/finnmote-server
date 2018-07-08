using System;
using System.ComponentModel.DataAnnotations;

namespace FinnMote.Api.Models
{

    public class Arrangoer
    {
        public int Id { get; set; }

        [Required]
        public string Navn { get; set; }
        
    }

}