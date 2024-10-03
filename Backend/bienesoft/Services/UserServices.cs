using bienesoft.Models;
using Bienesoft.Models;
using System.Collections.Generic;
using System.Linq;

namespace bienesoft.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LearnerModel> GetLearnerModels()
        {
            return _context.Learner.ToList();
        }
        public IEnumerable<DepartmentModel> GetDepartmentModels()
        {
            return _context.department.ToList();
        }

        // Otros métodos relacionados con usuarios...
    }
}
