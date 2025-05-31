using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Response
{
    public class LocationRes
    {
        public string Place_Id { get; set; }
        public string Osm_id { get; set; }
        public string Osm_type { get; set; }
        public string Licence { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public List<string> Boundingbox { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public string Display_name { get; set; }
        public string Display_place { get; set; }
        public string Display_address { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Name { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Country_code { get; set; }
    }

    

}
