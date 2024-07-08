using FinBeat_TestTask.Domain.Entities.Item;
using FinBeat_TestTask.Domain.Repositories.ItemRepository;
using FinBeat_TestTask.Infrastructure.DataBase.EF;
using Microsoft.EntityFrameworkCore;

namespace FinBeat_TestTask.Infrastructure.Repositories.EF
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Item>> GetListAsync(ItemFilter filter, CancellationToken ct)
        {
            var query = _dbContext
                .Items
                .AsNoTracking()
                .AsQueryable();

            if (filter.Code.HasValue)
                query = query.Where(x => x.Code == filter.Code);

            if (!string.IsNullOrEmpty(filter.Value))
                query = query.Where(x => x.Value.Contains(filter.Value));

            return await query.ToListAsync(ct);
        }

        public async Task SaveAsync(IEnumerable<Item> items, CancellationToken ct)
        {
            await _dbContext
                .Items
                .AddRangeAsync(items, ct);

            await _dbContext.SaveChangesAsync();
        }

        public async Task MarkAllAsDeletedAsync(CancellationToken ct)
        {
            var notDeleted = await _dbContext
                .Items
                .Where(w => !w.IsDeleted).
                ToListAsync(ct);

            notDeleted.ForEach(i => i.IsDeleted = true);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(CancellationToken ct)
        {
            await _dbContext
                .Items
                .ExecuteDeleteAsync(ct);
        }
    }
}
