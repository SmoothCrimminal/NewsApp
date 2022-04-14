using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Pages.ViewModels
{
    public class NewsDetailsPageVM
    {
        private readonly string _newsUri;
        public string ArticleImage { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleBody { get; set; }
        public NewsDetailsPageVM(Article article)
        {
            ArticleImage = article.Image;
            ArticleTitle = article.Title;
            ArticleBody = article.Content;
            _newsUri = article.Url;
        }

        public async Task ShareURL()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = _newsUri,
                Title = "Share"
            });
        }
    }
}
