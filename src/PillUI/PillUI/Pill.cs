using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace PillUI
{
	public class Pill : ContentView
	{
		// fields
		private StackLayout _cellsStackLayout;
		private StackLayout _childrenStackLayout;


		// constructors
		public Pill()
		{
			StackLayout mainStackLayout = new StackLayout();
			Content = mainStackLayout;
			mainStackLayout.Orientation = StackOrientation.Vertical;

			_cellsStackLayout = new StackLayout();
			mainStackLayout.Children.Add(_cellsStackLayout);
			_cellsStackLayout.Orientation = StackOrientation.Horizontal;

			_childrenStackLayout = new StackLayout();
			mainStackLayout.Children.Add(_childrenStackLayout);
			_childrenStackLayout.Orientation = StackOrientation.Vertical;
			_childrenStackLayout.IsVisible = true;

			Cells = new ObservableCollection<PillCell>();
			Children = new ObservableCollection<Pill>();

			Cells.CollectionChanged += Cells_CollectionChanged;
			Children.CollectionChanged += Children_CollectionChanged;
		}


		// properties
		public ObservableCollection<PillCell> Cells
		{
			get;
			private set;
		}

		public ObservableCollection<Pill> Children
		{
			get;
			private set;
		}


		// private methods
		private void ResetCellsStackLayout()
		{
			_cellsStackLayout.Children.Clear();
			foreach(PillCell cell in Cells)
				_cellsStackLayout.Children.Add(cell);
		}

		private void ResetChildrenStackLayout()
		{
			_childrenStackLayout.Children.Clear();
			foreach(Pill pill in Children)
				_childrenStackLayout.Children.Add(pill);
		}


		// event handlers
		private void Cells_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.Action == NotifyCollectionChangedAction.Reset)
			{
				ResetCellsStackLayout();
			}
			else if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach(PillCell cell in e.NewItems)
					_cellsStackLayout.Children.Add(cell);
			}
			else if(e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach(PillCell cell in e.OldItems)
					_childrenStackLayout.Children.Remove(cell);
			}
			else if(e.Action == NotifyCollectionChangedAction.Move)
			{
				// TODO: optimize
				ResetCellsStackLayout();
			}
			else if(e.Action == NotifyCollectionChangedAction.Replace)
			{
				// TODO: optimize
				ResetCellsStackLayout();
			}
		}

		private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.Action == NotifyCollectionChangedAction.Reset)
			{
				ResetChildrenStackLayout();
			}
			else if(e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach(Pill pill in e.NewItems)
					_childrenStackLayout.Children.Add(pill);
			}
			else if(e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach(Pill pill in e.OldItems)
					_childrenStackLayout.Children.Remove(pill);
			}
			else if(e.Action == NotifyCollectionChangedAction.Move)
			{
				// TODO: optimize
				ResetChildrenStackLayout();
			}
			else if(e.Action == NotifyCollectionChangedAction.Replace)
			{
				// TODO: optimize
				ResetChildrenStackLayout();
			}
		}
	}
}

