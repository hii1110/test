using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HaQuangHuy_SE18C.NET_A02.Models;
using HaQuangHuy_SE18C.NET_A02.Repositories;

namespace HaQuangHuy_SE18C.NET_A02.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INewsArticleRepository _newsRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(INewsArticleRepository newsRepository, ILogger<IndexModel> logger)
        {
            _newsRepository = newsRepository;
            _logger = logger;
        }

        public List<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
        public string? SearchTerm { get; set; }

        public void OnGet(string? searchTerm)
        {
            SearchTerm = searchTerm;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                NewsArticles = _newsRepository.SearchNewsArticles(searchTerm)
                    .Where(na => na.NewsStatus == true)
                    .ToList();
            }
            else
            {
                NewsArticles = _newsRepository.GetActiveNewsArticles();
            }
        }
    }
}
