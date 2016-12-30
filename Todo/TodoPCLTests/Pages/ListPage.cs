using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace TodoPCLTests
{
	public class ListPage : BasePage
	{
		//Initialize variables for elements on page
		protected readonly Query AddButton;
		protected readonly Query Ruby;
		protected readonly Query Python;
		protected readonly Query CSharp;

		//Constructor
		public ListPage(IApp app, Platform platform) : base(app, platform)
		{
			AddButton = x => x.Marked("Add");
			Ruby = x => x.Marked("Ruby");
			Python = x => x.Marked("Python");
			CSharp = x => x.Marked("C#");
		}

		public void TapAddButton()
		{
			app.WaitForElement(x => x.Class("UITableView"), 
			                   "Timed out waiting for todo list to load");
			app.Tap(AddButton);
			app.Screenshot("Navigated to ItemPage");
			app.WaitForElement(x => x.Class("UITextField"), 
			                   "Timed out waiting to navigate to todo item page");
		}

		public void TapOnPython()
		{
			app.Tap(Python);
			app.Screenshot("Navigated to Python item");
		}

		public void TaponFirstItem()
		{
			app.Tap(x => x.Class("UILabel").Index(0));
			app.Screenshot("Navigated to item page");
		}

		public void TaponSecondItem()
		{
			app.Tap(x => x.Class("UILabel").Index(1));
			app.Screenshot("Navigated to item page");
		}
	}
}