using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinnMote.Api.Models
{

    public class ArrangementlisteFilterDto
    {
        public IList<int> Arrangoerer {get; set;}
    }

}