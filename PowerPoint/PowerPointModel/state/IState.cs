using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.PowerPointModel.state
{
    public interface IState
    {
        // this function is to handle mouse pressed
        void MouseDown();

        // this function is to handle mouse released
        void MouseMove();
    }
}
