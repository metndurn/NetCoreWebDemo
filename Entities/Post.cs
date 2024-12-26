using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Post : IEntity
	{
		public int Id { get; set; }

		[Display(Name = "Başlık"), StringLength(150)]
		public string Name { get; set; }

		[Display(Name = "İçerik")]
		public string Content { get; set; }

		[Display(Name = "Resim"), StringLength(150)]
		public string Image { get; set; }

		[Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
		public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }//iki tablo arasında baglantı kurulmasını saglar category ıd si uzerınden olacak
    }
}
