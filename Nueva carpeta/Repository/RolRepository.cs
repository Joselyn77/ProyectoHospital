using appHospital.Data.Repository.IRepository;
using appHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHospital.Data.Repository
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        private readonly ApplicationDbContext _db;
        public RolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Rol rol)
        {
            var objDesdeDb = _db.Rol.FirstOrDefault(s => s.Id_Rol == rol.Id_Rol);
            objDesdeDb.NombreRol = rol.NombreRol;
        }

    }
}
