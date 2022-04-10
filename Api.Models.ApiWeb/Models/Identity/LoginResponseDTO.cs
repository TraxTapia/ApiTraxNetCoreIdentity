using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Models.Identity
{
    public class LoginResponseDTO
    {
        public LoginResponseDTO()
        {
            //this.Result = new OperationResult.OperationResult();
        }


        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public DateTime ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty(".issued")]
        public string IssuedAt { get; set; }

        [JsonProperty(".expires")]
        public string ExpiresAt { get; set; }

        //public string Message { get; set; }
        //public bool IsOk { get; set; }
        //public OperationResult.OperationResult Result  { get; set; }  

    }
}
