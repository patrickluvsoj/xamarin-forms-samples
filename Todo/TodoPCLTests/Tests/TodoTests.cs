using System;
using Xamarin.UITest;
using NUnit.Framework;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace TodoPCLTests
{
	public class TodoTests : BaseTest
	{
		/// <summary>
		/// This file is where all tests are executed leveraging 
		/// the pages classes (i.e. ItemPage and ListPage)
		/// </summary>


		/*Constructor of TodoTests. Note that constructor 
		 * is inheriting from base test */
		public TodoTests(Platform platform) : base(platform)
		{
		}


		/*The method does necessary setups such as initializing 
		 * the app & pre-filling the app with necessary data.
		The method is derived from base test. */
		public override void BeforeEachTest()
		{
			base.BeforeEachTest();
		}


		/*Everything bellow are tests related to the app.
		Note that each test is using an arrange, act & assert format 
		It also has app.screenshot & waitformelements commands 
		to optimize for Test Cloud test runs*/
		[Test]
		public void AddCSharp()
		{
			//arrange
			Query expectedname = x => x.Marked("C#");
			ListPage.TapAddButton();

			//act
			ItemPage.FillName("C#");
			ItemPage.FillNote(".Net");
			ItemPage.ToggleSwitch();

			ItemPage.SaveTodo();

			//assert
			app.WaitForElement(expectedname, "Timed out waiting for field name C#");
		}

		[Test]
		public void CancelAdd()
		{
			//arrange
			Query expectedname = x => x.Marked("Javascript");
			ListPage.TapAddButton();

			//act
			ItemPage.FillName("Javascript");
			ItemPage.FillNote("AngularJS");
			ItemPage.ToggleSwitch();

			ItemPage.CancelTodo();

			//assert
			app.WaitForNoElement(expectedname, "Element Javascript was found");
		}

		[Test]
		public void ViewSecondItem()
		{
			//arrange
			Query expectedname = x => x.Marked("Ruby");

			//act
			ListPage.TapOnListItem(2);

			//assert ====> need to know how to get text from txt entry field
			app.WaitForElement(expectedname, "Timed out waiting for name Ruby");
		}

		[Test]
		public void MarkFirstItemDone()
		{
			//arrange
			//var initialNumberOfDoneItems = ListPage.NumberOfDoneItems;

			//verify switch is not enabled
			ListPage.TapOnListItem(1);

			//act
			ItemPage.ToggleSwitch();
			ItemPage.SaveTodo();

			//Assert
			//var finalNumberOfDoneItems = ListPage.NumberOfDoneItems;
			//Assert.Greater(finalNumberOfDoneItems, initialNumberOfDoneItems);
		}

		[Test]
		public void DeleteTodo()
		{
			//arrange
			Query expectedname = x => x.Marked("Python");

			//act
			ListPage.TapOnPython();
			ItemPage.DeleteTodo();

			//assert
			app.WaitForNoElement(expectedname, "Python item was not deleted");
		}


		[Test]
		public void RenameTodo()
		{
			//arrange
			Query expectedname = x => x.Marked("Monty Python");
			ListPage.TapOnPython(); //add verification if Python item is available

			//act
			ItemPage.ClearNameText();
			ItemPage.FillName("Monty Python");
			app.Screenshot("Entered text Monty Python");
			ItemPage.SaveTodo();

			//assert
			app.WaitForElement(expectedname, "Python was not changed to Monty Python");

		}

	}
}
