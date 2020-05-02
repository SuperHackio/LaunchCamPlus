using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackio.IO.BCAM;

namespace LaunchCamPlus.CameraPanels
{
    /// <summary>
    /// Interface for all Camera Panels
    /// </summary>
    interface ICameraPanel
    {
        void LoadCamera(BCAMEntry Target);
        void UnLoadCamera(BCAMEntry Target);
    }
}
