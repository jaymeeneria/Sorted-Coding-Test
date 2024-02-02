using System.ComponentModel;

namespace RainfallAPI.Models
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    public class rainfallReadingResponse
    {
        /// <summary>
        /// Details of a rainfall reading
        /// </summary>
        public List<rainfallReading> rainfallReadings { get; set; } = new List<rainfallReading>();
    }
}
