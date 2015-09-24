using System.Data;

namespace WindowsFormsApplication1
{
    public class CarInfo
    {
        public BrandAndModel BrandAndModel { get; set; }

        public int Id { get; set; }

        public string StateNumberCar { get; set; }

        public string OwnerCar { get; set; }

        public CarInfo(DataRow dataRow)
        {
            BrandAndModel = new BrandAndModel
            {
                BrandCar = dataRow["Brand"].ToString(),
                ModelCar = dataRow["Model"].ToString()
            };
            OwnerCar = dataRow["Owner"].ToString();
            StateNumberCar = dataRow["LicenseNumber"].ToString();
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var carInfo = (CarInfo)obj;
            return BrandAndModel.Equals(carInfo.BrandAndModel);
        }

        public override int GetHashCode()
        {
            return BrandAndModel.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", BrandAndModel, StateNumberCar);
        }
    }
}
