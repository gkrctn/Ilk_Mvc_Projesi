using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage ="Kategori alanı gereklidir")]
        [StringLength(15,ErrorMessage ="Kategori Adı alanı en fazla 15 karekter olabilir")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }

        [Display(Name="Açıklama")]
        public string Description { get; set; }
    }
}
