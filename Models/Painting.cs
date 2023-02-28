using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ArtGallery.Models
{
    public partial class Painting
    {
        [Display(Name="Painting Id")]
        [Required(ErrorMessage="Painting Id is mandatory")]
        public int Pid { get; set; }


        [Required]
        public int? ArtistId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Year { get; set; }

        [Required(ErrorMessage="Title is mandatory"), MaxLength(30)]
        public string Title { get; set; }

        [Range(1000,10000000,ErrorMessage="Price should be atleast 1000")]
        public int? Price { get; set; }
        public string StyleOfArt { get; set; }

        public virtual Artistishan Artist { get; set; }
    }
}
