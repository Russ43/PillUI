using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace PillUI
{
	public class EntityEditor : ContentView
	{
		// fields
		private EntityPill _entityPill;


		// constructors
		public EntityEditor(string title, object entity)
		{
			if(entity == null)
				throw new ArgumentNullException("entity");

			Entity = entity;

			_entityPill = new EntityPill(title, Entity);

			ScrollView scrollView = new ScrollView();
			Content = scrollView;

			scrollView.Content = _entityPill;
		}


		// properties
		public object Entity
		{
			get;
			private set;
		}
	}
}

