using Application.Core.Data;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository(IDbContext dbContext) : IUserRepository
{
    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await dbContext.Set<User>().AddAsync(user, cancellationToken);
    }

    public async Task UpdateAsync(User user)
    {
        dbContext.Set<User>().Update(user);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(User user)
    {
        dbContext.Set<User>().Remove(user);
        await Task.CompletedTask;
    }

    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .SingleOrDefaultAsync(user => user.Id.Equals(userId), cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .SingleOrDefaultAsync(user => user.Email.Equals(email), cancellationToken);
    }

    public async Task<IEnumerable<User>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .Where(user => user.FirstName.Value.Contains(name, StringComparison.OrdinalIgnoreCase))
                              .ToListAsync(cancellationToken);
    }
}
