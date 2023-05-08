using WebUI.Models.AuthorModels;
using WebUI.Models.CategoryModels;

namespace WebUI.Models.BookModels
{
    public class CreateBookModel
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public bool BookState { get; set; }


        public List<AuthorModel> Authors { get; set; }
        public List<CategoryModel> Categories { get; set; }

    }
}
