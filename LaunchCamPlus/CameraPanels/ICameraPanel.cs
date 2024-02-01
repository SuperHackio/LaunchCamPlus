using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels
{
    /// <summary>
    /// Interface for all Camera Panels
    /// </summary>
    interface ICameraPanel
    {
        BCAM.Entry Item { get; set; }
        void LoadCamera(BCAM.Entry entry);
        void UnloadCamera();
    }
}
