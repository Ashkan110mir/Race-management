using Newtonsoft.Json;

namespace Race_management.Utility.ReCaptcha
{
    public class GoogleRecatcha : IGoogleRecatcha
    {
        private IConfiguration _configuration;
        private IHttpContextAccessor _contextAccessor;
        public GoogleRecatcha(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        async Task<bool> IGoogleRecatcha.ISRecapthaTrue()
        {
            var secretkey = _configuration.GetSection("GooglereCAPTCHA")["SecretKey"];
            var response = _contextAccessor.HttpContext.Request.Form["g-recaptcha-response"];
            var http = new HttpClient();
            var result = await http.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretkey}&response={response}", null);
            if (result.IsSuccessStatusCode)
            {
                var googleRespons = JsonConvert.DeserializeObject<RecaptchaResponse>(await result.Content.ReadAsStringAsync());
                if (googleRespons != null)
                {
                    return googleRespons.Success;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
