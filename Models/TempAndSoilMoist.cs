namespace H3IoTApi.Models
{    public class TempAndSoilMoist
    {
        public int Id { get; set; }
        public string TemperatureStatus { get; set; }
        public float Temperature { get; set; }
        public string SoilStatus { get; set; }
        public float SoilMoist { get; set; }
        public string Timestamp { get; set; }
    }
}
