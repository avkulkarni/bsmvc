using BsGridExt.BsGridImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsGridExt
{
    public class WidgetCollection
    {
        public Grid Grid(string gridId)
        {
            return new Grid(gridId);
        }
    }
}
