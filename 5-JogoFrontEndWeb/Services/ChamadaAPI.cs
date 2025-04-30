namespace _5_JogoFrontEndWeb.Services
{
    public class ChamadaAPI
    {
        private readonly HttpClient _http;

        public ChamadaAPI(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> salvaTentativa(string url, object dt)
        {
            return await _http.PostAsJsonAsync("https://localhost:44387/" + url, dt);
        }
    }
}
