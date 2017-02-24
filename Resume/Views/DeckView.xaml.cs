using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		static PanGestureRecognizer _panGesture = new PanGestureRecognizer();

		bool? swipedTowardsLeft = null;

		void OnPanUpdated(object sender, PanUpdatedEventArgs e)
		{
			Task.Run(async () =>
			{
				;
				if (e.StatusType == GestureStatus.Completed)
				{
					System.Diagnostics.Debug.WriteLine(e.TotalX + " " + e.TotalY);
					if (swipedTowardsLeft.HasValue)
					{
						var stack = sender as StackLayout;
						var stackIndex = deckLayout.Children.IndexOf(stack);

						if (stackIndex > 0 && stackIndex < deckLayout.Children.Count && swipedTowardsLeft.Value)
						{
							if (stackIndex + 1 == deckLayout.Children.Count)
								return;
							//swiped towards left - Load Next
							await stack.LayoutTo(new Rectangle((stackContainer.Width - 20) * -1, 20, stackContainer.Width * 0.9, stackContainer.Height * 0.85));
							stack.Opacity = 0.8;
							var nextPanel = deckLayout.Children[stackIndex + 1];
							await nextPanel.LayoutTo(new Rectangle(20, 20, stackContainer.Width * 0.9, stackContainer.Height * 0.85));
							nextPanel.Opacity = 1.0;
						}
						else
						{
							if (stackIndex <= 1)
								return;
							//swiped towardsright => bring back Previous
							await stack.LayoutTo(new Rectangle((stackContainer.Width), 20, stackContainer.Width * 0.9, stackContainer.Height * 0.85));
							stack.Opacity = 0.8;
							var prevPanel = deckLayout.Children[stackIndex - 1];
							await prevPanel.LayoutTo(new Rectangle(20, 20, stackContainer.Width * 0.9, stackContainer.Height * 0.85));
							prevPanel.Opacity = 1.0;
						}
						swipedTowardsLeft = null;
					}


				}
				if (e.StatusType == GestureStatus.Running)
				{
					var stack = sender as StackLayout;
					var stackIndex = deckLayout.Children.IndexOf(stack);

					if (e.TotalX < 0)
					{
						if (stackIndex + 1 == deckLayout.Children.Count)
						{
							swipedTowardsLeft = null;
						}
						else {
							//swiped left - Load Next
							swipedTowardsLeft = true;
						}
					}
					else
					{
						//swiped right - load prev
						if (stackIndex <= 1)
						{
							// this is the first panel -> cant go any further Left
							swipedTowardsLeft = null;
						}
						else
						{
							swipedTowardsLeft = false;
						}
					}
				}
				if (e.StatusType == GestureStatus.Canceled)
					swipedTowardsLeft = null;
			});
		}


		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create(nameof(ItemsSource), typeof(IList<Project>), typeof(DeckView), null, BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
		{
			//PropertyChanged - Add the cards to the deck and set the relative positions
			var projects = (IList<Project>)newValue;
			var deckView = bindable as DeckView;
			if (projects == null || deckView == null)
				return;


			if (oldValue == null && newValue != null)
			{
				int panelCount = 0;

				//Set the recent as the first card
				foreach (var proj in projects)
				{
					StackLayout newStack = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Padding=0, Spacing=0 };
					ProjectView projectView = new ProjectView { BindingContext = new ProjectViewViewModel { Project = proj } };
					//Label title = new Label { Text = proj.Name, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = Color.White };
					newStack.Children.Add(projectView);
					newStack.GestureRecognizers.Add(_panGesture);
					if (panelCount == 0)
					{
						deckView.deckLayout.Children.Add(newStack
														  //, Constraint.RelativeToParent((parent) =>
														  //{
														  // System.Diagnostics.Debug.WriteLine(String.Format("Parent Width {0} X {1}", parent.Width, parent.Width - (parent.Width* 0.9)));
														  // return parent.Width - (parent.Width* 0.9);
														  //})
														  , Constraint.Constant(20)
						  , Constraint.Constant(20)
														 , Constraint.RelativeToView(deckView.stackContainer, (parent, container) => { return container.Width * 0.9; })
														 , Constraint.RelativeToView(deckView.stackContainer, (parent, container) => { return container.Height * 0.85; }));

					}
					else
					{
						newStack.Opacity = 0.8;
						deckView.deckLayout.Children.Add(newStack
														 //						 , Constraint.RelativeToView(deckView.stackContainer, new Func<RelativeLayout, View, double>((RelativeLayout, container) =>
														 //{
														 // return container.X + 20 + (container.Width * panelCount);
														 //}))
														 , Constraint.Constant(20 + deckView.stackContainer.Width * panelCount)
						, Constraint.Constant(50)
														 , Constraint.RelativeToView(deckView.stackContainer, (parent, container) => { return (container.Width * 0.9); })
														 , Constraint.RelativeToView(deckView.stackContainer, (parent, container) => { return (container.Height * 0.85) - 50; }));
					}
					panelCount++;
				}
			}
		});

		public DeckView()
		{
			InitializeComponent();
			stackContainer.WidthRequest = AppConfig.SCREEN_WIDTH;
			stackContainer.HeightRequest = AppConfig.SCREEN_HEIGHT;


			_panGesture.TouchPoints = 1;
			_panGesture.PanUpdated += OnPanUpdated;
		}
	}
}
