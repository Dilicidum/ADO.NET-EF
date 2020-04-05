using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EFDAL.Models
{
    public class Supplier
    {
        [Required(ErrorMessage ="SupplierId is required")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name of Company is required")]
        [StringLength(20,MinimumLength =1,ErrorMessage ="TooMuchLettersException")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Country of Company is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "TooMuchLettersException")]
        public string Country { get; set; }


        public virtual List<Good> Goods { get; set; } = new List<Good>();


    }
}