using System;
using Xamarin.UITest;

//Add query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace TodoPCLTests
{
	public class ItemPage : BasePage
	{
		//List variables associated w/ ui elements
		protected readonly Query SaveButton;
		protected readonly Query DeleteButton;
		protected readonly Query CancelButton;
		protected readonly Query NameField;
		protected readonly Query NotesField;
		protected readonly Query DoneSwitch;


		//ItemPage constructor
		public ItemPage(IApp app, Platform platform) : base(app, platform)
		{
			//initialize variables and assigning query
			SaveButton = x => x.Marked("Save");
			DeleteButton = x => x.Marked("Delete");
			CancelButton = x => x.Marked("Cancel");
			NameField = x => x.Marked("NameField");
			NotesField = x => x.Marked("NotesField");
			DoneSwitch = x => x.Marked("Switch");
		}


		/*All interactions available on this page listed bellow*/

		//ItemPage.FillName(name);
		public void FillName(string name)
		{
			//add step to verify that field is empty. If not empty, clear text.
			//if
			//{ 
			//	app.ClearText(NameField);
			//}
			app.EnterText(NameField, name);
		}

		public void ClearNameText()
		{
			app.ClearText(NameField);
		}


		//ItemPage.FillNote(note);
		public void FillNote(string note)
		{
			//add step to verify that field is empty. If not empty, clear text.
			app.EnterText(NotesField, note);
		}


		//ItemPage.ToggleSwitch(isdone);
		public void ToggleSwitch()
		{
			//add step to verify that switch is toggle to note done
			app.Tap(DoneSwitch);
		}

		//ItemPage.SaveTodo;
		public void SaveTodo()
		{
			app.Tap(SaveButton);
			app.Screenshot("Todo item saved");
		}

		public void DeleteTodo()
		{
			app.Tap(DeleteButton);
			app.Screenshot("Tapped delete");
		}

		public void CancelTodo()
		{
			app.Tap(CancelButton);
			app.Screenshot("Tapped cancel");
		}
	}
}
