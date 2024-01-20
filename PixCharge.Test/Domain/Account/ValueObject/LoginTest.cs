﻿namespace Domain.Account;
public class LoginTest
{
    [Fact]
    public void Should_Success_With_Valid_Email()
    {
        // Arrange
        var customer = MockCustomer.GetFaker();

        // Act
        customer.Login.Email = "usuario@teste.com";

        // Assert
        Assert.Equal("usuario@teste.com", customer.Login.Email);
    }

    [Fact]
    public void Should_Throws_Erro_With_Invalid_Email()
    {
        // Arrange
        var merchant = MockCustomer.GetFaker();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => merchant.Login.Email = "Email inválido!");
    }
            
    [Fact]
    public void Should_Throws_Erro_With_Long_Email()
    {
        // Arrange
        var merchant = MockCustomer.GetFaker();

        // Act e Assert
        Assert.Throws<ArgumentException>(() => merchant.Login.Email = new string('a', 257));
    }
}