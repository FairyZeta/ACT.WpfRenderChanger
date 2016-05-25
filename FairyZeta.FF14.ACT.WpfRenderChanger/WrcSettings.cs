using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.IO;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.WpfRenderChanger
{
    /// <summary> WRC／設定データ
    /// </summary>
    public class WrcSettings : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/
        
        #region #- [Property] bool.CpuRenderMode - ＜CPUレンダーモードの有効状態＞ -----
        /// <summary> CPUレンダーモードの有効状態 </summary>
        private bool _CpuRenderMode;
        /// <summary> CPUレンダーモードの有効状態 </summary>    
        public bool CpuRenderMode
        {
            get { return _CpuRenderMode; }
            set
            {
                this.SetProperty(ref this._CpuRenderMode, value);
                Globals.RenderModeChanged = value;

                if (!init)
                {
                    this.SaveSettings();
                }
            }

        }
        #endregion

        private bool init;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> WRC／設定データ／コンストラクタ
        /// </summary>
        public WrcSettings()
        {
            this.init = true;

            this.initSettings();

            this.init = false;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 設定の初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initSettings()
        {
            this.CpuRenderMode = false;

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 設定データの保存を実行します。
        /// </summary>
        public void SaveSettings()
        {
            if (!string.IsNullOrWhiteSpace(Globals.PluginDllDirectoryPath))
            {
                string fPath = Path.Combine(Globals.PluginDllDirectoryPath, "WrcSettings.xml");
                this.xmlSave_NonException(fPath, this);
            }
        }


        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> シリアライズエラーを無視して、オブジェクトをXMLにシリアライズします。 
        /// </summary>
        /// <param name="path"> string : 書込XMLのファイルパス </param>
        /// <param name="obj"> object : 保存するオブジェクト </param>
        private void xmlSave_NonException(string path, object obj)
        {
            try
            {
                this.xmlSave(path, obj);
            }
            catch
            {
            }

            return;
        }

        /// <summary> オブジェクトをXMLにシリアライズします。 
        /// </summary>
        /// <param name="path"> string : 書込XMLのファイルパス </param>
        /// <param name="obj"> object : 保存するオブジェクト </param>
        private void xmlSave(string path, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);

            try
            {
                serializer.Serialize(fs, obj);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
