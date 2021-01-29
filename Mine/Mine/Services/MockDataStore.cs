using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Tangerine LaCroix", Description="Nectar of the gods", Value=10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Passion Fruit LaCroix", Description="A tasty and delicious drink", Value=9 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Lime LaCroix", Description="Zero calorie lime-flavored sparkling water", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Lemon LaCroix", Description="A potable liquid in an aluminum can", Value=2 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pamplemousse LaCroix", Description="Complete garbage, just pour it down the drain", Value=0 },
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}