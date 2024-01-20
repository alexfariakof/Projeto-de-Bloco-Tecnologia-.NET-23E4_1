using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Core.Aggreggates;
using PixCharge.Domain.Transactions.ValueObject;
using System.Net.Http.Headers;
using PixCharge.Domain.Core.ValueObject;

namespace PixCharge.Domain.Transactions.Aggreggates;

[Serializable]
public sealed class Charge : BaseModel
{
    private const string baseUrl = "https://api.openpix.com.br/api/v1/";
    private string? Authorization = null;
    public Customer? Customer { get; set; }
    public long  Value { get; set; }
    public string?  Identifier { get; set; }
    public string?  CorrelationID { get; set; }
    public string?  PaymentLinkID { get; set; }
    public string?  TransactionID { get; set; }
    public string?  Status { get; set; }
    public AdditionalInfo[]? AdditionalInfo { get; set; }
    public int Discount { get; set; }
    public int  ValueWithDiscount { get; set; }
    public DateTime  ExpiresDate { get; set; }
    public string?  Type { get; set; }
    public DateTime  CreatedAt { get; set; }    
    public DateTime UpdatedAt { get; set; }
    public string? BrCode { get; set; }    
    public int  ExpiresIn { get; set; }
    public string?  PixKey { get; set; }    
    public string?  PaymentLinkUrl { get; set; }
    public string?  QrCodeImage { get; set; }
    public string?  GlobalID { get; set; }
    public Charge(Customer customer, string correlationID , Monetary value) 
    { 
        this.GetAuthorization();
        this.Customer = customer;
        this.CorrelationID = correlationID;
        this.Value = value.Cents;
    }
    public void CreateChargePix(Charge charge)
    {
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}charge?return_existing=true");
        request.Headers.Add("Authorization", Authorization);
        request.Content = new StringContent(JsonConvert.SerializeObject(charge));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = client.SendAsync(request).Result;
        response.EnsureSuccessStatusCode();
        string responseBody = response.Content.ReadAsStringAsync().Result;
        charge = JsonConvert.DeserializeObject<Charge>(responseBody);
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
