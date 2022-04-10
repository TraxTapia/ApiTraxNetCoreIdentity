using Api.Models.ApiWeb.ContextBD;
using Api.Models.ApiWeb.ENUM;
using Api.Models.ApiWeb.Models.CajaAhorro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.DAO
{
    public class CajaAhorroDAO
    {
        private String constring = String.Empty;
        private String rutaLogs = String.Empty;
        String UserId = String.Empty;
        public String ConParams { get => constring; set => constring = value; }
        public CajaAhorroDAO()
        {

        }
        public CajaAhorroDAO(String _pConstring)
        {
            //UserId = _UserId;
            constring = _pConstring;
            //rutaLogs = _prutaLogs;
        }

        private CajaAhorroDBContext GetContext()
        {
            return new CajaAhorroDBContext(constring);
        }
        public void AddRangeBD<T>(List<T> List) where T : class
        {
            using (CajaAhorroDBContext _context = new CajaAhorroDBContext())
            {
                _context.Set<T>().AddRange(List);
                _context.SaveChanges();
            }
        }
        public void AddCajaAhorro<T>(T Register) where T : class
        {
            using (CajaAhorroDBContext _DbContext = new CajaAhorroDBContext())
            {
                _DbContext.Set<T>().Add(Register);
                _DbContext.SaveChanges();
            }
        }
        public void Update<T>(T Register) where T : class
        {
            using (CajaAhorroDBContext _DbContext = new CajaAhorroDBContext())
            {
                _DbContext.Entry(Register).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _DbContext.SaveChanges();
            }
        }
        public void Remove<T>(T Register) where T : class
        {
            using (CajaAhorroDBContext _DbContext = new CajaAhorroDBContext())
            {
                _DbContext.Set<T>().Remove(Register);
                _DbContext.SaveChanges();
            }
        }
        public List<Usuario> GetUsers()
        {
            using CajaAhorroDBContext _Context = new CajaAhorroDBContext(constring);
            return _Context.Usuario.Where(x => x.Activo.Equals(EnumGenerales.Activo)).ToList();
        }
    }
}
