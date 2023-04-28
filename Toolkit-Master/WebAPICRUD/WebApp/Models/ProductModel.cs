using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }
    }
}
