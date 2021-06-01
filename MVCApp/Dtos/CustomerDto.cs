using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MemberShipTypeId { get; set; }
    }
}