using NewsApp.Models;
using NewsApp.Pages.ViewModels;
using NewsApp.Services;

namespace NewsApp;

public partial class NewsPage : ContentPage
{
    private bool _isNextPage = false;
    private readonly NewsPageVM _newsPageVM;
    public NewsPage(IApiService apiService)
	{
        _newsPageVM = new(apiService);
        BindingContext = _newsPageVM;
        if (!_isNextPage)
        {
            _newsPageVM?.Initialize();
        }
		InitializeComponent();
    }

    private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
        await _newsPageVM?.GetNewsWithSelectedCategory(selectedItem.Name);
    }

    private void News_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        _isNextPage = true;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));
    }
}