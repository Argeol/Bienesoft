using bienesoft.Models;
using Bienesoft.Models;

namespace bienesoft.Services
{
    public class DepartmentServices
    {
        private readonly AppDbContext _context;

        public DepartmentServices(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<DepartmentModel> GetDepartmentModels()
        {
            return _context.department.ToList();
        }
        public void AddDepartmentModel(DepartmentModel departmentModel) {
            _context.department.Add(departmentModel);
            _context.SaveChanges();
        }
        public void RemoveDepartmentModel(int Id_Department)
        {
            var department = _context.department.Find(Id_Department);
            if (department != null)
            {
                _context.department.Remove(department);
                _context.SaveChanges();
            }
        }
        public DepartmentModel GetDepartmentModelOne(int Id_Department)
        {
            return _context.department.Find(Id_Department);
        }
        public void UpdateDepartmentModel(DepartmentModel departmentModel)
        {
            if (departmentModel == null)
            {
                throw new ArgumentNullException(nameof(departmentModel), "El modelo de departamento es nulo");
            }

            var existingDepartment = _context.department.Find(departmentModel.Id_Department);
            if (existingDepartment == null)
            {
                throw new ArgumentException("Departamento no encontrado");
            }

            existingDepartment.DepartmentName = departmentModel.DepartmentName;
            // Actualiza otros campos según sea necesario

            _context.SaveChanges();
        }

    }
}