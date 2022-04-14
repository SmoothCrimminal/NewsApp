using NewsApp.Models;
using NewsApp.Pages.ViewModels;

namespace NewsApp;

public partial class NewsDetailPage : ContentPage
{
	private readonly NewsDetailsPageVM _newsDetailsPageVM;
	public NewsDetailPage(Article article)
	{
		_newsDetailsPageVM = new(article);
		BindingContext = _newsDetailsPageVM;
		InitializeComponent();
	}

    private async void TbShare_Clicked(object sender, EventArgs e)
    {
		await _newsDetailsPageVM?.ShareURL();
	}
}