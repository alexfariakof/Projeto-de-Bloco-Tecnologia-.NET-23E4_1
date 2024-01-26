﻿using Bogus;
using PixCharge.Domain.Transactions.Aggregates;

namespace __mock__;
public static class MockTransaction
{
    public static Transaction GetFaker()
    {
        var fakeTransaction = new Faker<Transaction>()
            .RuleFor(t => t.Id, f => f.Random.Guid())
            .RuleFor(t => t.DtTransaction, f => f.Date.Recent())
            .RuleFor(t => t.Value, f => new Monetary(f.Finance.Amount()))
            .RuleFor(t => t.Description, f => f.Lorem.Sentence())
            //.RuleFor(t => t.Merchant, f => MockMerchant.GetFaker())
            .Generate();
        return fakeTransaction;
    }
}