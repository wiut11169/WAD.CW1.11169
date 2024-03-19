namespace WAD.CW1._11169.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
