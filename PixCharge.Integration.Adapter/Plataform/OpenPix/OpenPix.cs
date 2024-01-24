using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PixCharge.Integration.Adapter.Converters;
using PixCharge.Domain.Transactions.Aggregates;
using System.Net.Http.Headers;

namespace PixCharge.Integration.Adapter.Plataform.OpenPix;
public class OpenPix : IPix
{
    private const string baseUrl = "https://api.openpix.com.br/api/v1/";
    private string Authorization = null;
    public Charge CreateCharge(long value, string correlationID)
    {
        GetAuthorization();
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}charge?return_existing=true");
        request.Headers.Add("Authorization", Authorization);
        request.Content = new StringContent(JsonConvert.SerializeObject(new { value, correlationID }));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = client.SendAsync(request).Result;
        response.EnsureSuccessStatusCode();
        string responseBody = response.Content.ReadAsStringAsync().Result;
        var data = JsonConvert.DeserializeObject<Models.ChargeObjectOpenPix>(responseBody);
        return new ChargeParser().Parse(data.Charge);
    }
    public bool IsChargeApporve(Guid correlationID)
    {
        throw new NotImplementedException();
    }

    private void GetAuthorization()
    {
        var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        if (File.Exists(jsonFilePath))
        {
            var jsonContent = File.ReadAllText(jsonFilePath);
            var config = JObject.Parse(jsonContent);
            Authorization = config["OpenPIX"]?["Authorization"]?.ToString();
        }
        else
        {
            throw new ArgumentException("Arquivo com chave de autenticação não encontrado");
        }
    }

}
