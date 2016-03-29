using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using PillUI;


namespace PillUI.App
{
	internal class AppEntityEditorPage : ContentPage
	{
		// constructors
		public AppEntityEditorPage(object entity)
		{
			EntityEditor editor = new EntityEditor("Entity Editor", entity);
			Content = editor;
		}
	}
}

