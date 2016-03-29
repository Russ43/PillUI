using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace PillUI
{
	public class EntityPill : Pill
	{
		// constructors
		public EntityPill(string name, object entity)
		{
			if(name == null)
				throw new ArgumentNullException("name");

			if(entity == null)
				throw new ArgumentNullException("entity");

			Name = name;
			Entity = entity;

			Populate();
		}


		// properties
		public string Name
		{
			get;
			private set;
		}

		public object Entity
		{
			get;
			private set;
		}


		// private methods
		private void Populate()
		{
			TypeInfo typeInfo = Entity.GetType().GetTypeInfo();
			IList<FieldInfo> fields = typeInfo.DeclaredFields
				.Where(f => f.IsPublic 
					&& !(f.Name == "Empty")	// HACKHACK: not sure what these "Empty" fields are...
				)
				.ToList();
			IList<PropertyInfo> properties = typeInfo.DeclaredProperties
				.Where(p => p.CanRead && p.CanWrite)
				.ToList();

			// populate cells
			bool hasChildren = (fields.Count + properties.Count > 0);
			if(hasChildren)
			{
				ButtonPillCell expandCollapseCell = new ButtonPillCell()
				{
					Text = ">"
				};
				expandCollapseCell.Command = new DelegateCommand(
					(p) =>
					{
						AreChildrenVisible = !AreChildrenVisible;
						expandCollapseCell.Text = AreChildrenVisible ? "v" : ">";
					}
				);
				Cells.Add(expandCollapseCell);
			}
			else
			{
				Cells.Add(new TextPillCell() { Text = "-" });
			}
			Cells.Add(new TextPillCell() { Text = string.Format("{0}: ", Name) });
			if(hasChildren)
				Cells.Add(new TextPillCell() { Text = Entity.ToString() });
			else
				Cells.Add(new EntryPillCell() { Text = Entity.ToString() });

			// populate children
			foreach(FieldInfo field in fields)
			{
				object childEntity = field.GetValue(Entity);
				EntityPill childPill = new EntityPill(field.Name, childEntity);
				Children.Add(childPill);
			}
			foreach(PropertyInfo property in properties)
			{
				object childEntity = property.GetValue(Entity);
				EntityPill childPill = new EntityPill(property.Name, childEntity);
				Children.Add(childPill);
			}
		}
	}
}

