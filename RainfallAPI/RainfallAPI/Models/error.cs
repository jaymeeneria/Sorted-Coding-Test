namespace RainfallAPI.Models
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    public class error
    {
        public string message { get; set; }
        public string[] details { get; set; }
        public string[] items { get; set; }
    }
}
