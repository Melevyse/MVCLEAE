using TestLEAE.DataLayer;

namespace TestLEAE.ModelsView
{
    public class ClientView
    {
        public long Inn { get; set; }
        public string Name { get; set; }
        public ClientType Type { get; set; }
        public DateTime DateToAdd { get; set; }
        public DateTime DateToUpdate { get; set; }
    }
}
