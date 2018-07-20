using System;

namespace XmlSerialization
{
    public class Address
    {
        public string City { get; set; }

        public string RoadNo { get; set; }

        public string HouseNo { get; set; }

        public override string ToString()
            => $"{Environment.NewLine}City => {City}, Road => {RoadNo}, House => {HouseNo}";
    }
}