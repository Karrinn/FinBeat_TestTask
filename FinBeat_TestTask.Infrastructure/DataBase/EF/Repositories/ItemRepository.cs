using FinBeat_TestTask.Domain.Entities.Item;
using FinBeat_TestTask.Domain.Repositories.ItemRepository;
using Microsoft.EntityFrameworkCore;

namespace FinBeat_TestTask.Infrastructure.DataBase.EF.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<IList<Item>> GetListAsync(ItemFilter filter, CancellationToken ct)
        {
            var data = await _dbContext
                .Items
                .Where(w => w.Code.Equals(filter.Code) && w.Value.Equals(filter.Value))
                .AsNoTracking()
                .ToListAsync(ct);

            return data;
        }

        public async Task SaveAsync(IEnumerable<Item> items, CancellationToken ct)
        {
            await _dbContext.Items.AddRangeAsync(items, ct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task MarkAllAsDeletedAsync(CancellationToken ct)
        {
            var notDeleted = await _dbContext.Items.Where(w => !w.IsDeleted).ToListAsync(ct);

            notDeleted.ForEach(i => i.IsDeleted = true);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(CancellationToken ct)
        {
            await _dbContext.Items.ExecuteDeleteAsync(ct);
        }
    }
}
