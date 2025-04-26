namespace Investo.DataAccess.Interfaces;

using Investo.DataAccess.Entities;

public interface IInvestmentRepository : ICrudRepository<Investments, int>
{
}