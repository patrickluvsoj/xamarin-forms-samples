using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;


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
			if (app is iOSApp)
				AddButton = x => x.Marked("Add");
			else
				AddButton = x => x.Marked("NoResourceEntry-0");

			Python = x => x.Marked("Python");
		}

		//Assigning to property Number of done items
		public int NumberOfDoneItems => (int)app.Query("check.png")?.Length;


		public void TapAddButton()
		{
			app.WaitForElement(AddButton, "Timed out waiting for todo list to load");
			app.Tap(AddButton);

			app.WaitForElement(x => x.Marked("NameField"), "Timed out waiting to navigate to todo item page");
			app.Screenshot("Navigated to ItemPage");
		}


		public void TapOnListItem(int itemNumber)
		{
			//find class that is in listview
			if (app is AndroidApp)
				app.Tap(x => x.Class("ViewCellRenderer_ViewCellContainer").Index(itemNumber - 1));
			else
				app.Tap(x => x.Marked("ListViewItem").Index(itemNumber - 1));

			app.WaitForElement(x => x.Marked("NameField"));
			app.Screenshot($"Tapped On Item Number: {itemNumber}");
		}

		public void TapOnPython()
		{
			app.Tap(Python);
			app.Screenshot("Navigated to Python item");
		}
	}
}