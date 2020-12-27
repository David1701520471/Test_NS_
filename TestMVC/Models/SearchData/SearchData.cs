
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models.Search
{
    public class SearchData
    {
        public SearchData()
        {

        }
        [Required]
        [StringLength(3)]
        public string Origin { set; get; }
        [Required]
        [StringLength(3)]
        public string Destination { set; get; }
        [Required]
        [StringLength(10)]
        [RegularExpression(@"This field must be in formas yyyy-mm-dd")]
        public string Datepicker { set; get; }
    }
}