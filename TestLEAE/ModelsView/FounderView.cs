
using TestLEAE.BusinessLayer.AutoMapper;
using TestLEAE.DataLayer;

namespace TestLEAE.ModelsView
{
    public class FounderView : IMapWith<Founder>
    {
        public long Inn { get; set; }
        public string? Fio { get; set; }
        public DateTime DateToAdd { get; set; }
        public DateTime DateToUpdate { get; set; }
    }
}
