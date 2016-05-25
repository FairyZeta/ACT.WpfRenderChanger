using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Interop;

namespace FairyZeta.FF14.ACT.WpfRenderChanger
{
    /// <summary> WRC／ネイティブ領域
    /// </summary>
    public static class Globals
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグインDLLまでのパス
        /// </summary>
        public static string PluginDllDirectoryPath { get; set; }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> WPFのレンダーモードを変更します。
        /// <para> => [True] Cpu Render / [False] GPU Render </para>
        /// </summary>
        public static bool RenderModeChanged
        {
            set
            {
                if (value)
                {
                    RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
                }
                else
                {
                    RenderOptions.ProcessRenderMode = RenderMode.Default;
                }
            }
        }

    }
}
