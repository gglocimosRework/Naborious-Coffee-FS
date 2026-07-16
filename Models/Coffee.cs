namespace NaboriousCoffee.Models
{
    public class Coffee
    {
        public int Id { get; set; } 
        public string Type { get; set; }             
        public string Title { get; set; }            
        public string ShortDescription { get; set; }  
        public string Description { get; set; }       
        public decimal Price { get; set; }           
        public string Image { get; set; }           
    }
}