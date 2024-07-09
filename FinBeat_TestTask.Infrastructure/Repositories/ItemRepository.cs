using FinBeat_TestTask.Domain.Entities;
using FinBeat_TestTask.Domain.Repositories;
using FinBeat_TestTask.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FinBeat_TestTask.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> GetListAsync(ItemFilter filter, CancellationToken ct)
        {
            var query = _dbContext
                .Items
                .AsNoTracking()
                .AsQueryable();

            if (filter.Code.HasValue)
                query = query.Where(x => x.Code == filter.Code);

            if (!string.IsNullOrEmpty(filter.Value))
                query = query.Where(x => x.Value != null && x.Value.Contains(filter.Value));

            return await query.ToListAsync(ct);
        }

        public async Task SaveAsync(IEnumerable<Item> items, CancellationToken ct)
        {
            await _dbContext
                .Items
                .AddRangeAsync(items, ct);

            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task DeleteAllAsync(CancellationToken ct)
        {
            await _dbContext
                .Items
                .ExecuteDeleteAsync(ct);
        }
    }
}
