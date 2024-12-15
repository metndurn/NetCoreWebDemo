using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class User:IEntity
	{
		public int Id { get; set; }
		[Display(Name = "Adınız"), StringLength(50)]
		public string Name { get; set; }
		[Display(Name = "Soyadınız"), StringLength(50)]
		public string SurName { get; set; }
		[EmailAddress, StringLength(50)]
		public string Email { get; set; }
		[Display(Name = "Kullanıcı Adı"), StringLength(50)]
		public string UserName { get; set; }
		[Display(Name = "Şifre"), StringLength(150)]
		public string Password { get; set; }
		[Display(Name = "Telefon"), StringLength(15)]
		public string Phone { get; set; }
		[Display(Name = "Durum")]
		public bool	IsActive { get; set; }
		[Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
		public DateTime CreateDate { get; set; }
	}
}
