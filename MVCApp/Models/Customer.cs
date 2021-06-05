using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.DateTime)]
        
        [Required]
        public DateTime BirthDate { get; set; }
       
        
        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        
        [Display(Name ="Member Ship Type")]
        public byte MemberShipTypeId { get; set; }
    }
}