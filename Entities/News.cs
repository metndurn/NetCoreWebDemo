using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class News : IEntity
	{
		public int Id { get; set; }
		[Display(Name = "Başlık"), StringLength(150)]
		public string Name { get; set; }
		[Display(Name = "İçerik")]
		public string Content { get; set; }
		[Display(Name = "Resim"), StringLength(150)]
		public string? Image { get; set; }
		[Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
		public DateTime CreateDate { get; set; }

	}
}
