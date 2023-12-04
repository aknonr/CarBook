using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarDescription
    {
        //Bu sınıfı bilerek ayrı açtım çünkü açıklamalar uzun olabilir o yüzden burada oluşturdum   

        public int CarDescriptionID { get; set; }

        public string Details { get; set; }


        //Relational Property

        public Car Car { get; set; }

        public int CarID { get; set; }
    }
}
