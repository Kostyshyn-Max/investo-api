using System;
namespace Investo.DataAccess.Interfaces;

using Investo.DataAccess.Entities;

public interface IUserRepository : ICrudRepository<User, Guid>
{
}
