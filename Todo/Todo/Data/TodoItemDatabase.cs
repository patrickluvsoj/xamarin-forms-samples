using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Todo
{
	public class TodoItemDatabase
	{
		readonly SQLiteAsyncConnection database;

		public TodoItemDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<TodoItem>().Wait();
		}

		public async Task<List<TodoItem>> GetItemsAsync()
		{
			return await database.Table<TodoItem>().ToListAsync();
		}

		public async Task<List<TodoItem>> GetItemsNotDoneAsync()
		{
			return await database.Table<TodoItem>()?.Where(x => x.Done == true)?.ToListAsync();
		}

		public async Task<TodoItem> GetItemAsync(int id)
		{
			return await database.Table<TodoItem>()?.Where(i => i.ID == id)?.FirstOrDefaultAsync();
		}

		public async Task<int> SaveItemAsync(TodoItem item)
		{
			if (item.ID != 0)
				return await database.UpdateAsync(item);

			return await database.InsertAsync(item);
		}

		public async Task<int> DeleteItemAsync(TodoItem item)
		{
			return await database.DeleteAsync(item);
		}
	}
}

