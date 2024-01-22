using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PixCharge.Adapter.Converters;
using PixCharge.Domain.Transactions.Aggreggates;
using System.Net.Http.Headers;

namespace PixCharge.Adapter.OpenPix;
public class OpenPix : IChargePix
{
    private const string baseUrl = "https://api.openpix.com.br/api/v1/";
    private string Authorization = null;
    public Charge CreateCharge(long value, string correlationID)
    {
        this.GetAuthorization();
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}charge?return_existing=true");
        request.Headers.Add("Authorization", Authorization);
        request.Content = new StringContent(JsonConvert.SerializeObject(new { value, correlationID = correlationID }));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = client.SendAsync(request).Result;
        response.EnsureSuccessStatusCode();
        string responseBody = response.Content.ReadAsStringAsync().Result;
        var data = JsonConvert.DeserializeObject<Models.PixCharge>(responseBody);
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
            this.Authorization = config["OpenPIX"]?["Authorization"]?.ToString();            
        }
        else
        {
            throw new ArgumentException("Arquivo com chave de autenticação não encontrado");
        }
    }

}
