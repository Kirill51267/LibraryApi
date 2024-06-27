using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book
    {
        public Guid Id { get; }

        public string Title { get;} = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public const int MAX_TITLE_LENGHT = 250;

        private Book(Guid id, string title, string description, decimal price) 
        { 
            Id= id;
            Title= title;
            Description= description;
            Price= price;
        }
        
        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var book = new Book(id, title, description, price);

            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || MAX_TITLE_LENGHT < title.Length)
            {
                error = "Title cannot be empti or longer 250";
            }

            return (book, error);
        }

    }
}
