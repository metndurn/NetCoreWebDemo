using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Contact:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız Soyadınız"),StringLength(50)]
        public string Name { get; set; }
        [EmailAddress,StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Telefon"),StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Mesajınız"),StringLength(500)]
        public string Message { get; set; }

        [Display(Name = "Mesaj Tarihi"),ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
    }
}
