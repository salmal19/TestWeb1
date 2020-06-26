using System;
using System.Collections.Generic;
using TestWeb1.Models.ValueTypes;

namespace TestWeb1.Models.Entities
{
    public partial class Course
    {
        public Course(string title, string author)
        {
            //Mi assicuro che i parametri del costruttore non siano vuoti
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Il corso deve avere un titolo");
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Il corso deve avere un autore");
            }
            Title = title;
            Author = author;
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Author { get; private set; }
        public string Email { get; private set; }
        public double Rating { get; private set; }
        public Money FullPrice { get; private set; }
        public Money CurrentPrice { get; private set; }
        

        public void ChangeTitle(string newTitle){
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Il corso deve avere un titolo");
            }
            Title = newTitle;
        }

        public void ChangePrices(Money newFullPrice, Money newDiscountPrice){
            if (newFullPrice == null || newDiscountPrice == null)
            {
                throw new ArgumentException("Il prezzo non deve essere nullo");
            }
            if (newFullPrice.Currency != newDiscountPrice.Currency)
            {
                throw new ArgumentException("La valuta non corrisponde");
            }
            if (newFullPrice.Amount < newDiscountPrice.Amount)
            {
                throw new ArgumentException("Il prezzo intero non può essere minore del prezzo scontato");
            }
            FullPrice = newFullPrice;
            CurrentPrice = newDiscountPrice;
        }



        public virtual ICollection<Lesson> Lessons { get; private set; }
    }
}
