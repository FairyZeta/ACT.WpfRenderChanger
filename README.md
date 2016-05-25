# ACT.WpfRenderChanger

WPFが使用されているACTプラグインの描画処理方法を  
「CPU+GPU」から「CPUのみ」に変更するだけのプラグインです。

#### ≪用途≫
WPFはCPUとGPUをバランス良く使って処理速度を上げるのが特徴ですが  
ゲーム中などでGPUをフルに使用している環境の場合  
GPUの処理が追いつかず、描画処理に遅延が発生する場合があります。  
  
本来GPUで処理するべき内容を強制的にCPU処理に書き換える事で  
WPF型プラグインの処理速度を向上させる事が、このプラグインの目的です。  
#### ≪注意点≫  
このプラグインを導入する事により、必ずしも描画速度が向上するとは限りません。  
  
* CPUに余裕があり、GPUに余裕がないPC環境の場合 => 改善が見込めます。
* CPUに余裕がなく、GPUに余裕があるPC環境の場合 => **処理が遅くなります。**
* 導入済プラグインがWPFを使用していない => 影響が一切ありません。

逆に処理が遅くなる可能性もリスクとしてありえます。  
自分のPC環境を確認後、導入を検討して下さい。
### ≪お約束≫【重要】
プラグインの性質上、WPFを使用した全てのプラグインに影響があります。
  
**このプラグインの影響により、他のWPF型プラグインが意図せぬ動作となったとしても**  
**そのプラグイン製作者様に文句をつけるような事は絶対にしないで下さい。**  
  
動作不良のクレームは全てFairyZetaまで。自己責任という事を約束して下さい。
#### ≪導入方法／使用方法≫
.Net Framework 4.5 以上  
  
リリースされているZIPファイルをダウンロード後、解凍して  
ACT本体から「FZ.WpfRenderChanger.dll」をプラグインとして認識させて下さい。  
  
ACTのプラグインタブ「FZ.WRC」に移動します。  
コントロール内にチェックボックス「□ Graphics Render is CPU Mode」という項目が存在します。  

* 未チェックの場合(デフォルト) => 描画処理はCPUとGPUを併用して実行されます。
* チェック済の場合 => 描画処理はCPUだけを使用して実行されます。  

実際にゲームを動かしながら描画の設定を検討して下さい。  
また、プラグインを無効化した場合は、自動的に未チェックと同じ設定に変更されます。
####≪プラグイン内のネットワーク通信≫
アップロード／ダウンロードの双方向ともに通信処理はありません。
####≪ライセンス≫
三条項BSDライセンス  
Copyright (c) <2016> (FairyZeta)  
All rights reserved.  
  
ソースコードの流用やプラグイン改造版の作成など、製作者への連絡は一切不要で自由に使用して頂いてかまいません。  
リリース物をそのまま再配布だけは、一言（１行でも）連絡を頂けると助かります。
####≪連絡先≫
mail to <info@fairyzeta.com>  
twitter <https://twitter.com/FairyZeta>
####≪動作確認した環境≫
CPU: Core i7 5930K (3.5G)  
MEM: DDR4 32G  
GPU: nVidia GTX980 *2 (SLI) 4K+FHD  
