using appHospital.Data.Repository.IRepository;
using appHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHospital.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;
        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Usuario usuario)
        {
            var objDesdeDb = _db.Usuario.FirstOrDefault(s => s.Id_Usuario == usuario.Id_Usuario);
            objDesdeDb.Usuarios = usuario.Usuarios;
            objDesdeDb.Contraseña = usuario.Contraseña;
            objDesdeDb.Estado = usuario.Estado;

        }

    }
}
