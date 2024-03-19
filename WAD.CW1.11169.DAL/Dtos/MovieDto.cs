namespace WAD.CW1._11169.DAL.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
