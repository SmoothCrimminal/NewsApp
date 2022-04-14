using NewsApp;
using NewsApp.Models;
using NewsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Pages.ViewModels
{
    public class NewsPageVM : PagesBaseView
    {
        private readonly IApiService _apiService;
        private List<Article> _articles;
        public List<Article> Articles 
        {
            get { return _articles; }
            set
            {
                _articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }
        private List<Category> _categories;
        public List<Category> Categories 
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        

        public NewsPageVM(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async void Initialize()
        {
            Categories = new()
            {              
                new Category() { Name = "Breaking-news" },
                new Category() { Name = "World" },
                new Category() { Name = "Nation" },
                new Category() { Name = "Business" },
                new Category() { Name = "Technology" },
                new Category() { Name = "Entertainment" },
                new Category() { Name = "Sports" },
                new Category() { Name = "Science" },
                new Category() { Name = "Health" },
            };
        
            Articles = new List<Article>();
            await GetNewsWithSelectedCategory("breaking-news");
        }

        public async Task GetNewsWithSelectedCategory(string category)
        {
            Articles.Clear();
            var newsRes = await _apiService.GetNews(category);
            Articles = newsRes.Articles;
        }
    }
}
