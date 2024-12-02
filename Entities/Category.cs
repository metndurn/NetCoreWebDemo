using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name="Üst Kategorisi")]
        public int ParentId { get; set; }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string Description { get; set; }
        [Display(Name = "Kategori Resmi")]
        public string Image { get; set; }
    }
}
