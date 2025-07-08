namespace MauiAppNavigationPage;

public partial class Page3 : ContentPage
{
	public Page3()
	{
		InitializeComponent();
	}

    private void GoBack(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private void GoBackToRoot(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}