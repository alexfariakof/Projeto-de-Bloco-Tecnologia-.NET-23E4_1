﻿using Bogus;
using Bogus.Extensions.Brazil;

namespace __mock__;
public static class MockCustomer
{
    public static Customer GetFaker()
    {
        var fakeCustomer = new Faker<Customer>()
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.CorrelationID, new Guid())
            .RuleFor(c => c.TaxID, new Guid().ToString())
            .RuleFor(c => c.User, MockUser.Instance.GetFaker())
            .RuleFor(c => c.CPF, f => f.Person.Cpf())
            .RuleFor(c => c.Birth, f => f.Person.DateOfBirth)
            .RuleFor(c => c.Phone, MockPhone.GetFaker())
            .RuleFor(c => c.Address, MockAddress.GetFaker())
            .Generate();

        return fakeCustomer ?? null;
    }
}