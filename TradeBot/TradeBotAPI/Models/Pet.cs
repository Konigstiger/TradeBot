namespace TradeBotAPI.Models
{
    public class Pet
    {
        public Pet(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}