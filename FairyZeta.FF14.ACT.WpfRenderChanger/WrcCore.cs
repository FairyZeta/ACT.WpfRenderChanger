using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairyZeta.FF14.ACT.WpfRenderChanger
{
    /// <summary> WRC／コアプロセス
    /// </summary>
    public class WrcCore
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグインタブに追加されるスクリーンスペース
        /// </summary>
        public TabPage ScreenSpace { get; private set; }
        /// <summary> プラグイン一覧に表示されるステータスメッセージ
        /// </summary>
        public Label StatusText { get; private set; }

        private ACTTabPageControl actTabPageControl;
        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> WRC／コアプロセス／コンストラクタ
        /// </summary>
        public WrcCore(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.ScreenSpace = pluginScreenSpace;
            this.StatusText = pluginStatusText;

            this.initCore();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コアの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initCore()
        {

            this.StatusText.Text = "Plugin Started.";
            this.SetupTab();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグイン終了時の処理を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns>
        public bool DeInitPlugin()
        {

            Globals.RenderModeChanged = false;

            if (this.StatusText != null)
            {
                this.StatusText.Text = "Plugin Exited.";
            }

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> Actタブに表示される画面のセットアップを実行します。
        /// </summary>
        private void SetupTab()
        {
            this.ScreenSpace.Text = "FZ.WRC";

            actTabPageControl = new ACTTabPageControl();
            ScreenSpace.Controls.Add(actTabPageControl);
            ScreenSpace.Resize += screenSpace_Resize;
            screenSpace_Resize(this, null);

            actTabPageControl.Show();
        }

        /// <summary> タブページリサイズイベントを登録します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void screenSpace_Resize(object sender, EventArgs e)
        {
            actTabPageControl.Location = new System.Drawing.Point(0, 0);
            actTabPageControl.Size = ScreenSpace.Size;
        }
    }
}
