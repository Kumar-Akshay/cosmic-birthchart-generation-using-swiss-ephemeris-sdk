namespace CosmicGame.Shared.Models.ViewModel
{
    public class TraditionalChartCell
    {
        public int HouseNumber { get; set; }
        public string ZodiacSign { get; set; }
        public string ZodiacSignTamil { get; set; }
        public int MinDegree { get; set; }
        public int MaxDegree { get; set; }
        public List<string> Planets { get; set; } = new();
    }
}
