using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Click_TV
{
    class DoubleBufferedPanel : System.Windows.Forms.Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
