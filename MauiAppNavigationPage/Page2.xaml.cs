namespace MauiAppNavigationPage;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private void GoToNextPage(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page3());
    }

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}