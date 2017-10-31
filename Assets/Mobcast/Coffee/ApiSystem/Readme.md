NetworkSystem
===

## Overview

A management system for Game API.




## Requirement

* Unity5.4+ *(included Unity 2017.x)*
* No other SDK




## Usage

1. Download [ApiSystem.unitypackage](https://github.com/mob-sakai/ApiSystem/raw/master/ApiSystem.unitypackage) and install to your project.
1. From the menu, click `Coffee > ApiSystem > Setup`
1. Use in your script.
```cs
ApiManager.Initialize();
ApiManager.Request();
...```


### プロジェクト用のAPIを準備する

#### リクエストメタデータを作る

* リクエストヘッダに追加したい項目がある場合、追加
* ToDictionaryメソッドのオーバーライド

#### リクエストパケットを作る

* url、methodなどをオーバーライド
* シリアライズ項目を追加

#### レスポンスパケットを作る

* シリアライズ項目を追加
* OnAfterSerializeをオーバーライド

### ApiManagerを準備する

#### シーンにApiManagerを追加する

* メニューから追加できる

#### リクエストメタデータを生成する

* UIDやPIDを設定する
* AES暗号化キーを設定する
* その他、言語コードなどを設定する

#### APIマネージャを初期化する

* ApiManager.Initialize(meta)

### リクエストパケットをリクエストし、コールバックさせる

* new RequestPacket().Request();
* yield return new RequestPacket().Request();


## Release Notes

### ver.0.1.0:

* 