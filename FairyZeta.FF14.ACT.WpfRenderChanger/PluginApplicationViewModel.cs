using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using System.IO;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.WpfRenderChanger
{
    /// <summary> WRC／ビューモデル
    /// </summary>
    public class PluginApplicationViewModel : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> WRC設定データ
        /// </summary>
        public WrcSettings WrcSettings { get; set; }
       
      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> WRC／ビューモデル／コンストラクタ
        /// </summary>
        public PluginApplicationViewModel()
        {
            this.initViewModel();

            this.LoadSettings();
            Globals.RenderModeChanged = this.WrcSettings.CpuRenderMode;
            
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            this.WrcSettings = new WrcSettings();

            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 設定データの読込を実行します。
        /// </summary>
        public void LoadSettings()
        {
            if (!string.IsNullOrWhiteSpace(Globals.PluginDllDirectoryPath))
            {
                string fPath = Path.Combine(Globals.PluginDllDirectoryPath, "WrcSettings.xml");
                var data = this.xmlLoad_NonException<WrcSettings>(fPath);

                if (data != null)
                {
                    this.WrcSettings = data;
                }
            }
        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


        /// <summary> シリアライズエラーを無視して、XMLファイルを逆シリアライズします。 
        /// </summary>
        /// <param name="path"> 読込XMLのファイルパス </param>
        /// <returns> 復元オブジェクト </returns>
        private T xmlLoad_NonException<T>(string path)
        {
            try
            {
                return this.xmlLoad<T>(path);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary> XMLファイルを逆シリアライズします。 
        /// </summary>
        /// <param name="path"> 読込XMLのファイルパス </param>
        /// <returns> 復元オブジェクト </returns>
        private T xmlLoad<T>(string path)
        {
            if (File.Exists(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    var result = serializer.Deserialize(fs);
                    return (T)result;
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                return default(T);
            }

        }
    }
}
