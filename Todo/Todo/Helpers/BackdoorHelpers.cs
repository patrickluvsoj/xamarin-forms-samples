using System;
using System.Threading.Tasks;
namespace Todo
{
	public static class BackdoorHelpers
	{
		public static async Task AddDummyDataToDatabase()
		{
			var dummyItem1 = new TodoItem
			{
				Name = "Cucumber",
				Notes = "Calabash"
			};

			var dummyItem2 = new TodoItem
			{
				Name = "Ruby",
				Notes = "Rails",
				Done = true
			};

			var dummyItem3 = new TodoItem
			{
				Name = "Python",
				Notes = "Django",
				Done = true
					
			};

			await App.Database.SaveItemAsync(dummyItem1);
			await App.Database.SaveItemAsync(dummyItem2);
			await App.Database.SaveItemAsync(dummyItem3);
		}
	}
}
