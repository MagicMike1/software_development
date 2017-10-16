using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TrafficLight : TrafficObject
    {
        int id { get; set;  }
        int status { get; set; }

        public TrafficLight(int id, int status, Vector2 position, Vector2 direction, int width, int height, Bitmap image) : base(position, direction, width, height, image)
        {
            this.id = id;
            this.status = status;
        }
    }
}
