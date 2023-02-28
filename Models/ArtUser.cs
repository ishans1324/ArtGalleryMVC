using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ArtGallery.Models
{
    public partial class ArtUser
    {
        public int Uid { get; set; }
        [Required]
        public string Uname { get; set; }
        [Required,MinLength(5,ErrorMessage="Minimum length of password is 5")]
        public string Password { get; set; }
    }
}
