using Newtonsoft.Json;

namespace Race_management.Utility.ReCaptcha
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("challenge_ts")]
        public DateTimeOffset Challenge_ts { get; set; }
        [JsonProperty("hostname")]
        public string HostName { get; set; }
    }
}
