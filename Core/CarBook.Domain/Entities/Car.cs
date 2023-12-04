using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {

        public int CarID { get; set; }
        public int BranID { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; } //Kapak fotoğrafı için
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }  //Büyük görselin yolu

        // Relational Property
        public Brand Brand { get; set; }

        public List<CarFeature> CarFeatures { get; set; }

        public List<CarDescription> CarDescriptions { get; set; }

        public List<CarPricing> CarPricings { get; set; }

    }
}
