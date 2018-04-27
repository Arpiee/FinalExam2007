namespace comp2007w2018finalB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Brewery
    {
        public int BreweryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        [StringLength(50)]
        public string Logo { get; set; }
        public int BreweriesId { get; internal set; }
    }
}
