using appHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHospital.Data.Repository.IRepository
{
    public interface IRolRepository : IRepository<Rol>
    {
        void Update(Rol rol);
    }
}
