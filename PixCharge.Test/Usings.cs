global using Xunit;
global using PixCharge.Domain.Account.Aggregates;
global using PixCharge.Domain.Account.ValueObject;
global using PixCharge.Domain.Core.Aggregates;
global using PixCharge.Domain.Core.Interfaces;
global using PixCharge.Domain.Core.ValueObject;
global using PixCharge.Domain.Transactions.Aggregates;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Conventions;
global using __mock__;
using Moq;
using PixCharge.Repository;
using System.Linq.Expressions;
public static class Usings
{
    public static Mock<IRepository<T>> MockRepositorio<T>(List<T> _dataSet) where T : BaseModel, new()
    {
        var _mock = new Mock<IRepository<T>>();

        _mock.Setup(repo => repo.Save(It.IsAny<T>()));
        _mock.Setup(repo => repo.Update(It.IsAny<T>()));
        _mock.Setup(repo => repo.Delete(It.IsAny<T>()));

        _mock.Setup(repo => repo.GetAll())
            .Returns(() => { return _dataSet.AsEnumerable(); });

        _mock.Setup(repo => repo.GetById(It.IsAny<Guid>()))
            .Returns(
            (Guid id) =>
            {
                return _dataSet.SingleOrDefault(item => item.Id == id);
            });


        _mock.Setup(repo => repo.Find(It.IsAny<Expression<Func<T, bool>>>()))
            .Returns(
            (Expression<Func<T, bool>> expression) =>
            {
                return _dataSet.Where(expression.Compile());
            });

        _mock.Setup(repo => repo.Exists(It.IsAny<Expression<Func<T, bool>>>()));
        return _mock;
    }
}