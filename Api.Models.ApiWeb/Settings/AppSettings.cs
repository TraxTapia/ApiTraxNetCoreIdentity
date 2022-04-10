using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Settings
{
    public class AppSettings
    {
        //public Dictionary<string, string> LogService { get; set; }
        //public Dictionary<string, string> Logs { get; set; }
        public Dictionary<string, string>? ConnectionStrings { get; set; }
        public Dictionary<string, string>? Jwt { get; set; }
        public Dictionary<string, string>? LogPath { get; set; }
        //public Dictionary<string, string> MailSettings { get; set; }
        //public Dictionary<string, string> Servicios { get; set; }
        //public Dictionary<string, string> FolderServer { get; set; }
        //public Dictionary<string, string> GenerateToken { get; set; }
        //public Dictionary<string, string> FiltroAfiliados { get; set; }
        //public Dictionary<string, string> Generic { get; set; }
        //public Dictionary<string, string> UrlServicios { get; set; }
        //public List<LayoutExcelSettings> LayoutSiniestralidadEspecial { get; set; }
        //public List<CodTipoCuenta> CodigoTipoCuenta { get; set; }
        //public Dictionary<string, string> ServicioSAT { get; set; }
        //public Dictionary<string, string> EnvApp { get; set; }
        //public Dictionary<string, string> AzureFolders { get; set; }
    }
}
