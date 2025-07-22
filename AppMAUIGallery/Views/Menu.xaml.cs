using AppMAUIGallery.Repositories;
using AppMAUIGallery.Views.Layouts;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();

        lblMainTitle.TextColor = Colors.Black;
        lblMainTitle.FontAttributes = FontAttributes.Bold;

        var categories = new CategoryRepository().GetCategories();

        foreach (var category in categories)
		{
            var lblCategory = new Label();
            lblCategory.Text = category.Name;
			lblCategory.FontFamily = "OpenSansSemibold";
			lblCategory.TextColor = Colors.Black;
			lblCategory.FontAttributes = FontAttributes.Bold;

            MenuContainer.Children.Add(lblCategory);

            foreach (var component in category.Components)
			{
				var tap = new TapGestureRecognizer();
				tap.CommandParameter = component.Page;
				tap.Tapped += OnTapComponent;

				var lblComponentTitle = new Label();
				lblComponentTitle.Text = component.Title;
				lblComponentTitle.FontFamily = "OpenSansSemibold";
				lblComponentTitle.FontAttributes = FontAttributes.Bold;
                lblComponentTitle.Margin = new Thickness(20, 10, 0, 0);
				lblComponentTitle.TextColor = Colors.Black;
				lblComponentTitle.GestureRecognizers.Add(tap);

                var lblDescription = new Label();
				lblDescription.Text = component.Description;
                lblDescription.Margin = new Thickness(20, 0, 0, 0);
				lblDescription.TextColor = Colors.Black;
				lblDescription.GestureRecognizers.Add(tap);

                MenuContainer.Children.Add(lblComponentTitle);
				MenuContainer.Children.Add(lblDescription);
            }
        }

    }

	private void OnTapComponent(object sender, EventArgs e)
	{
		var label = (Label)sender;
		var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
		var page = (Type)tap.CommandParameter;

		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
		((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }

    private void OnTapInicio(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}