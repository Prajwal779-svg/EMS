using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Infrastructure;

namespace EMPMANAGE.Application.EmployeeMng
{
    [Service]
    public class DeleteEmployee
    {
        private IEmployeeManager _em;
        public DeleteEmployee(IEmployeeManager em)
        {
            _em=em;
        }

        public Task<int> Do(int id)
        {
            return _em.DeleteEmployee(id);
        }
    }
}
