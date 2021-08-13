using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProCodeIT.Template.DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MyDbContext _dbContext;

        public BaseRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected void UpdateChildCollection<Tparent, Tchild, Tid>(Tparent dbItem, Tparent newItem, Func<Tparent, IEnumerable<Tchild>> selector, Func<Tchild, Tid> idSelector) where Tchild : class
        {
            var dbItems = selector(dbItem).ToList();
            var newItems = selector(newItem).ToList();

            if (dbItems == null && newItems == null)
                return;

            var original = dbItems?.ToDictionary(idSelector) ?? new Dictionary<Tid, Tchild>();
            var updated = newItems?.ToDictionary(idSelector) ?? new Dictionary<Tid, Tchild>();

            var toRemove = original.Where(i => !updated.ContainsKey(i.Key)).ToArray();
            var removed = toRemove.Select(i => _dbContext.Entry(i.Value).State = EntityState.Deleted).ToArray();

            var toUpdate = original.Where(i => updated.ContainsKey(i.Key)).ToList();
            toUpdate.ForEach(i => _dbContext.Entry(i.Value).CurrentValues.SetValues(updated[i.Key]));

            var toAdd = updated.Where(i => !original.ContainsKey(i.Key)).ToList();
            toAdd.ForEach(i => _dbContext.Set<Tchild>().Add(i.Value));
        }
    }
}
