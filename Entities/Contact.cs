using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Contact:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız Soyadınız")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
