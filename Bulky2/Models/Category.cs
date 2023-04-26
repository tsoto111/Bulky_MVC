using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required!")]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

        /**
         * <summary>
         * Checks the Category model's values for Name and 
         * Display Order to make sure their values don't match.
         * </summary>
         * 
         * <param name="obj">
         * The Category model object we are validating
         * </param>
         * <returns>
         * Boolean - If true, the values match. If False, the values don't match.
         * </returns>
         * */
        public bool ValidateFieldsMatch(Category obj)
        {
            return obj.Name == obj.DisplayOrder.ToString();
        }
    }
}
