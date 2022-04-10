using Api.Models.ApiWeb.DAO;
using Api.Models.ApiWeb.Models;
using Api.Models.ApiWeb.Models.CajaAhorro;
using Api.Models.ApiWeb.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.ApiWeb.Repository
{
    public class RepositoryApi
    {

        private CajaAhorroDAO _CajaAhorroDAO = null;
        private readonly IOptions<AppSettings>? appSettings;
        private String constring = String.Empty;
        private string _cadenaConexion = string.Empty;
        public String ConParams { get => constring; set => constring = value; }
        public RepositoryApi()
        {

        }
        public RepositoryApi(IOptions<AppSettings> _appSettings)
        {
            appSettings = _appSettings;
            //usuario = appSettings.Value.LogService["usr"];

            //UsuarioAdmin = appSettings.Value.GenerateToken["User"];
            //PasswordAdmin = appSettings.Value.GenerateToken["Password"];
            //minutosLogeo = Int32.Parse(appSettings.Value.LogService["delay"]);
        }
        public RepositoryApi(string connectionString)
        {
            _cadenaConexion = connectionString;
        }

        private DataBaseContext GetContext()
        {
            return new DataBaseContext(constring);
        }
        public List<Usuario> GetUsers()
        {
            _CajaAhorroDAO = new CajaAhorroDAO(appSettings.Value.ConnectionStrings["CajaAhorro"]);
            List<Usuario> _Users = _CajaAhorroDAO.GetUsers();
            if (_Users == null) throw new Exception("No se pudo obtener la información.");
            return _Users;
        }
        public async Task<UserInfo> GetUser(string email, string password)
        {
            DataBaseContext _context = new DataBaseContext(appSettings.Value.ConnectionStrings["WEBTRAX"]);

            if (true)
            {

            }
            return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }


    }
}
