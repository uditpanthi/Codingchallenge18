namespace Codingchallenge.Models
{
    public class Books
    {
         public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Author { get; set; } = string.Empty;
        public int ISBN {  get; set; }
        public string Genre {  get; set; }=string.Empty;
        public int PublicationYear {  get; set; }
        public string Publisher {  get; set; }=string.Empty;
        public int TotalCopies {  get; set; }
    }
}
