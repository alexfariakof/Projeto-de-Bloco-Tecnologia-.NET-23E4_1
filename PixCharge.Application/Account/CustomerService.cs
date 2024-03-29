﻿using AutoMapper;
using PixCharge.Application.Account.Dto;
using PixCharge.Application.Account.Interfaces;
using PixCharge.Domain.Account.Aggregates;
using PixCharge.Domain.Account.Agreggates;
using PixCharge.Domain.Account.ValueObject;
using PixCharge.Domain.Core.Aggregates;
using PixCharge.Domain.Core.Interfaces;
using PixCharge.Repository;

namespace PixCharge.Application.Account;
public class CustomerService : ServiceBase<CustomerDto, Customer>, IService<CustomerDto>, ICustomerService
{
    private readonly ICrypto _crypto = Crypto.GetInstance;

    public CustomerService(IMapper mapper, IRepository<Customer> customerRepository) : base(mapper, customerRepository)
    {

    }
    public override CustomerDto Create(CustomerDto dto)
    {
        if (this.Repository.Exists(x => x.User.Login != null && x.User.Login.Email == dto.Email))
            throw new ArgumentException("Usuário já existente na base.");


        Customer customer = new()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name ?? throw new ArgumentException("Nome não pode ser nulo!"),
            CPF = dto.CPF ?? throw new ArgumentException("CPF não pode ser nulo!"),
            Birth = dto.Birth,
            Phone = dto.Phone ?? throw new ArgumentException("Telefone não pode ser nulo!"),
            User = new User
            {
                Login = new()
                {
                    Email = dto.Email ?? throw new ArgumentException("Email não pode ser nulo!"),
                    Password = dto.Password ?? throw new ArgumentException("Password não pode ser nulo!")
                }
            }
        };

        Address address = this.Mapper.Map<Address>(dto.Address);
        customer.Address = address;

        customer.CreateAccount(customer);

        this.Repository.Save(customer);
        var result = this.Mapper.Map<CustomerDto>(customer);

        return result;
    }
    public override CustomerDto FindById(Guid id)
    {
        var customer = this.Repository.GetById(id);
        var result = this.Mapper.Map<CustomerDto>(customer);
        return result;
    }

    public override List<CustomerDto> FindAll(Guid userId)
    {
        var customers = this.Repository.GetAll().Where(c => c.Id == userId).ToList();
        var result = this.Mapper.Map<List<CustomerDto>>(customers);
        return result;
    }
    public override CustomerDto Update(CustomerDto dto)
    {
        var customer = this.Mapper.Map<Customer>(dto);
        this.Repository.Update(customer);
        return this.Mapper.Map<CustomerDto>(customer);
    }
    public override bool Delete(CustomerDto dto)
    {
        var customer = this.Mapper.Map<Customer>(dto);
        this.Repository.Delete(customer);
        return true;
    }
}