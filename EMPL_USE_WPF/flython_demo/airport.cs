using System;
using System.Collections.Generic;
using System.Text;

namespace flython_demo
{
    class airport
    {
        public string name      { set; get; }
        public string adress    { set; get; }
        public double lat       { set; get; }
        public double lng       { set; get; }
        public double rating    { set; get; }

        public override string ToString ( )
        {
            return name + "|" + adress + "|" + lat.ToString() + "|" + lng.ToString() + "|" + rating.ToString();
        }
    }
}
