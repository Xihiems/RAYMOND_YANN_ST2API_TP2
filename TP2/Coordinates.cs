using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Coordinates
    {
        public float _latitude { get; set; }
        public float _longitude { get; set; }

        public Coordinates(float latitude, float longitude) 
        {
            _latitude = latitude;
            _longitude = longitude;

        }
    }
}
