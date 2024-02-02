namespace RainfallAPI.Models
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    public class rainfallReading
    {
        public DateTime dateMeasured { get; set; }
        public double amountMeasured { get; set; }
    }
}
