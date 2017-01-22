using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Resume
{
	public partial class DeckView : ContentView
	{
		public IList<Project> ItemsSource
		{
			get
			{
				return (IList<Project>)GetValue(ItemsSourceProperty);
			}
			set
			{
				SetValue(ItemsSourceProperty, value);
			}
		}

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create(nameof(ItemsSource), typeof(IList<Project>), typeof(DeckView), null, BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
		{
			//PropertyChanged - Add the cards to the deck and set the relative positions
			var projects = (IList<Project>)newValue;
			var deckView = bindable as DeckView;
			if (projects == null || deckView == null)
				return;
			bool? swipedTowardsLeft = null;
			PanGestureRecognizer panGesture = new PanGestureRecognizer();
			panGesture.TouchPoints = 1;
			panGesture.PanUpdated += async (sender, e) =>
			{
				if (e.StatusType == GestureStatus.Completed)
				{
					System.Diagnostics.Debug.WriteLine(e.TotalX + " " + e.TotalY);
					if (swipedTowardsLeft.HasValue)
					{
						var stack = sender as StackLayout;
						var stackIndex = deckView.deckLayout.Children.IndexOf(stack);
						if (swipedTowardsLeft.Value)
						{
							if (stackIndex + 1 == deckView.deckLayout.Children.Count)
								return;
							//swiped towards left - Load Next
							await stack.LayoutTo(new Rectangle((deckView.deckLayout.Width - 20) * -1, 50, deckView.deckLayout.Width * 0.75, deckView.deckLayout.Height * 0.75));
							stack.Opacity = 0.8;
							var nextPanel = deckView.deckLayout.Children[stackIndex + 1];
							await nextPanel.LayoutTo(new Rectangle(20, 50, deckView.deckLayout.Width * 0.9, deckView.deckLayout.Height * 0.9));
							nextPanel.Opacity = 1.0;
						}
						else
						{
							if (stackIndex == 0)
								return;
							//swiped towardsright => bring back Previous
							await stack.LayoutTo(new Rectangle((deckView.deckLayout.Width - 20), 50, deckView.deckLayout.Width * 0.75, deckView.deckLayout.Height * 0.75));
							stack.Opacity = 0.8;
							var prevPanel = deckView.deckLayout.Children[stackIndex - 1];
							await prevPanel.LayoutTo(new Rectangle(20, 50, deckView.deckLayout.Width * 0.9, deckView.deckLayout.Height * 0.9));
							prevPanel.Opacity = 1.0;
						}
						swipedTowardsLeft = null;
					}


				}
				if (e.StatusType == GestureStatus.Running)
				{
					var stack = sender as StackLayout;
					var stackIndex = deckView.deckLayout.Children.IndexOf(stack);

					if (e.TotalX < 0)
					{
						if (stackIndex + 1 == deckView.deckLayout.Children.Count)
						{

						}
						else {
							//swiped left - Load Next
							swipedTowardsLeft = true;
							await stack.TranslateTo(e.TotalX, stack.Y);
							//await stack.LayoutTo(new Rectangle(20, 50, deckView.deckLayout.Width * 0.75, deckView.deckLayout.Height * 0.75));
							// bring the previous panel and scale it up
							var prevPanel = deckView.deckLayout.Children[stackIndex + 1];
							//await prevPanel.LayoutTo(new Rectangle(deckView.deckLayout.X + 10, deckView.deckLayout.Y + 50, deckView.deckLayout.Width * 0.9, deckView.deckLayout.Height * 0.9));
						}
					}
					else
					{
						//swiped right - load prev
						if (stackIndex == 0)
						{
							// this is the first panel -> cant go any further Left
						}
						else
						{
							swipedTowardsLeft = false;
							await stack.TranslateTo(e.TotalX, stack.Y);
							//first move the current panel and scale it down
							//await stack.LayoutTo(new Rectangle(e.TotalX, stack.Y, deckView.deckLayout.Width * 0.75, deckView.deckLayout.Height * 0.75));
							// bring the previous panel and scale it up
							var prevPanel = deckView.deckLayout.Children[stackIndex - 1];
							//await prevPanel.LayoutTo(new Rectangle(deckView.deckLayout.X + 10, deckView.deckLayout.Y + 50, deckView.deckLayout.Width * 0.9, deckView.deckLayout.Height * 0.9));
						}
					}
				}
				if (e.StatusType == GestureStatus.Canceled)
					swipedTowardsLeft = null;
			};
			int panelCount = 0;
			//Set the recent as the first card
			foreach (var proj in projects)
			{
				StackLayout newStack = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor= Color.FromHex("#161F3D") };
				Label title = new Label { Text = proj.Name, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = Color.White};
				newStack.Children.Add(title);
				newStack.GestureRecognizers.Add(panGesture);
				if (panelCount == 0)
				{
					deckView.deckLayout.Children.Add(newStack, Constraint.RelativeToParent((parent) =>
					{
						return parent.X + 10;
					}), Constraint.RelativeToParent((parent) =>
					{
						return parent.Y;
					}), Constraint.RelativeToParent((parent) =>
					{
						return parent.Width * .9;
					}), Constraint.RelativeToParent((parent) =>
					{
						return parent.Height * .9;
					}));
				}
				else
				{
					newStack.Opacity = 0.6; 
					deckView.deckLayout.Children.Add(newStack, Constraint.RelativeToParent((parent) =>
					{
						return parent.X + (35 * panelCount);
					}), Constraint.RelativeToParent((parent) =>
					{
						return parent.Y + 50;
					}), Constraint.RelativeToParent((parent) =>
					{
						return parent.Width * .75;
					}), Constraint.RelativeToParent((parent) =>
					{
						return parent.Height * .75;
					}));
				}
				panelCount++;
			}
		});

		public DeckView()
		{
			InitializeComponent();
		}
	}
}
