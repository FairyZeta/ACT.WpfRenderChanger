using System;
using System.Linq;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace FairyZeta.FF14.ACT.WpfRenderChanger
{
    /// <summary> WRC／プラグインインタフェース
    /// </summary>
    public class ACTPlugin : IActPluginV1
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

          /// <summary> WRCコアクラス
          /// </summary>
          public WrcCore WrcCore { get; set; }

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [IF] プラグイン停止時の処理を実行します。
        /// </summary>
        public void DeInitPlugin()
        {
            this.WrcCore.DeInitPlugin();
        }

        /// <summary> [IF] プラグイン開始時の処理を実行します。
        /// </summary>
        /// <param name="pluginScreenSpace"></param>
        /// <param name="pluginStatusText"></param>
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            Globals.PluginDllDirectoryPath = GetPluginDirectory();
            
            this.WrcCore = new WrcCore(pluginScreenSpace, pluginStatusText);
        }


        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> このDLLまでのディレクトリパスを取得します。
        /// </summary>
        /// <returns> DLLまでのフルパス </returns>
        private string GetPluginDirectory()
        {
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            if (plugin != null)
            {
                return System.IO.Path.GetDirectoryName(plugin.pluginFile.FullName);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
