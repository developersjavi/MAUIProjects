namespace MauiAppNavigationPage;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
	}

    private void GoToNextPage(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page2());
    }
}