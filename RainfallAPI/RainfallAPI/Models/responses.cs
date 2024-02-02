namespace RainfallAPI.Models
{
    public class responses
    {
        /// <summary>
        /// Get rainfall readings response
        /// </summary>
        public rainfallReadingResponse rainfallReadingResponse { get; set; }

        /// <summary>
        /// An error object returned for failed requests
        /// </summary>
        public error errorResponse { get; set; }
    }
}
