using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public  class CarFeature
    {


        public int CarFeatureID { get; set; }

        public int CarID { get; set; }
        public bool Available { get; set; }   //Özellik var mı yok buna ulaşabiliyor muyuz bunun için yaptık..



        //Relational Property   
        public Car Car { get; set; }

        public Feature Feature { get; set; }

        public int FeatureID { get; set; }

    }
}
