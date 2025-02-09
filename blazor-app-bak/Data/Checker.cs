namespace blazor_app.Data 
{
    public class Checker 
    {
        public int Row { get; set; }
        public int Column { get; set; }   
        
        public CheckerDirection Direction { get; set; }
        public string Color { get; set; }

    }

    public enum CheckerDirection 
    {
        Down, Up, Both
    }
}
