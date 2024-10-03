using System.ComponentModel.DataAnnotations;

namespace Bienesoft.Models
{
    public class DepartmentModel
    {
        [Key]public int Id_Department { get; set; }
        public string DepartmentName { get; set; }

    }
}

