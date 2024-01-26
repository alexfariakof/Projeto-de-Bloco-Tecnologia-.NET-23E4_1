﻿namespace PixCharge.Integration.Adapter.Plataform.OpenPix.Models;

[Serializable]
public sealed class AddressOpenPix
{
    public string Zipcode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Complement { get; set; }
    public string Country { get; set; }
}
