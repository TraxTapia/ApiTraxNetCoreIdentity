using Api.Models.ApiWeb.Interfaz;
using Api.Models.ApiWeb.Models;
using Api.Models.ApiWeb.Models.CajaAhorro;
using Api.Models.ApiWeb.Models.ModelsDTO;
using Api.Models.ApiWeb.Response;
using Api.Models.ApiWeb.Settings;
using Api.Repository.ApiWeb.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.ApiWeb.Core
{
    public class CoreApi: IServices
    {
        private readonly IOptions<AppSettings> appSettings;

        private String UserId = String.Empty;
        private const int ok = 1;
        private string _cadenaConexion = string.Empty;
        public CoreApi()
        {
        }
        public CoreApi(IOptions<AppSettings> _appSettings)
        {
            appSettings = _appSettings;

        }
        public CoreApi(string connectionString)
        {
            _cadenaConexion = connectionString;
        }


        public ObtenerUsuariosResponseDTO ObtenerUsuarios()
        {
            List<Usuario> _Query = new List<Usuario>();
            ObtenerUsuariosResponseDTO _Response = new ObtenerUsuariosResponseDTO();
            RepositoryApi _Repository = new RepositoryApi(appSettings);
            _Query = _Repository.GetUsers();
            if (!_Query.Any()) throw new Exception("No se encontraron resultados");
            _Response = MapListUsuarios(_Query);
            return _Response;

        }
        public ObtenerUsuariosResponseDTO MapListUsuarios(List<Usuario> _lts)
        {
            ObtenerUsuariosResponseDTO _Response = new ObtenerUsuariosResponseDTO();
            _Response.List = _lts.Select(x => new UsuariosDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                ApellidoPaterno = x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                Activo = x.Activo,

            }).ToList();
            return _Response;


        }
        public async Task<UserInfo> GetUser(string email, string password)
        {
            RepositoryApi _Repository = new RepositoryApi(appSettings);

            UserInfo _user = await _Repository.GetUser(email, password);
            if (_user == null) throw new Exception("No se encontraron datos  o el usario es incorrecto " + email);
            return _user;
        }
        //public QRGenerateResponseDTO GenerateCodeQR(QRGenerateRequestDTO _TextoQR)
        //{
        //    QRGenerateResponseDTO _Result = new QRGenerateResponseDTO();
        //    var _qrGenerator = new QRCodeGenerator();
        //    var _qrCodeData = _qrGenerator.CreateQrCode(_TextoQR.TextoQR, QRCodeGenerator.ECCLevel.Q);
        //    BitmapByteQRCode _bitmapByteCode = new BitmapByteQRCode(_qrCodeData);
        //    var bitMap = _bitmapByteCode.GetGraphic(20);

        //    using var ms = new MemoryStream();
        //    ms.Write(bitMap);
        //    byte[] byteImage = ms.ToArray();
        //    _Result.QR = Convert.ToBase64String(byteImage);
        //    return _Result;
        //}
    }
}
