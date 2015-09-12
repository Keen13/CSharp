using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class BrandAndModel
    {
        public string BrandCar { get; set; }

        public string ModelCar { get; set; }

        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var brandAndModel = (BrandAndModel)obj;
            return (BrandCar == brandAndModel.BrandCar) && (ModelCar == brandAndModel.ModelCar);
        }

        public override int GetHashCode()
        {
            return BrandCar.GetHashCode() ^ ModelCar.GetHashCode();
        }
    }
}
