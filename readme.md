# C#入門勉強会 

## 付箋WebAPIを作ろう

* VisualStudioでは次のソリューションファイルを開いてください。
`\StickyWebApi.sln`
* WebAPIのメソッドは、次のコントローラークラスに記述されています。
`\Controllers\StickyController.cs`

### 2020/9/17のハイライト

[本編]
* WebAPIには、RESTfulという設計方針がある。これに即して作られたWebAPIを、俗に「REST API」と呼ぶ。
* RESTfulに従えば、GET(取得), POST(送信), PUT(置換), DELETE(削除)といったHttpメソッドを使い分ける必要がある。
* ASP.NET Core MVCのControllerクラスでは、メソッドの属性を HttpGet, HttpPost, HttpPut, HttpDeleteと書き分けることで対応する。
* RESTfulに従っていれば、みんなが直感的に理解しやすい設計になる。

[基本]
* Httpメソッドの仕様は、ここがおすすめ: https://developer.mozilla.org/ja/docs/Web/HTTP/Methods
* POSTとPUTの使い分けはこれを読もう: https://developer.mozilla.org/ja/docs/Web/HTTP/Methods/POST
* 今回は新規追加にPUTを使ったが、Restfulに従えば、POSTが正解。

[おまけ]
* リストを並び変える場合は、OrderByメソッド(System.Linq名前空間)を利用することができる。

### 2020/9/15のハイライト

[基本]
* ASP.NET Coreで作成すれば、WindowsだけでなくLinuxやMacでも動作させられる。
* デバッグはIIS Expressじゃなく、dotnet coreの仕組みを使おう

[本編]
* URLは、`パス`と`クエリパラメータ`に分けることができる
* `パス`によって、「どのコントローラークラス」の「どのメソッド」が呼ばれるかが決まる。
* `パス`は、http://localhost:5000/「どのコントローラークラス」/「どのメソッド」 という形式。
* `クエリパラメータ`は、メソッドの引数に渡される。(Addメソッド参照)
* `パス`の一部をメソッドの引数に渡すこともできる。(Getメソッド参照)

[おまけ]
* 文字列は `$"文字{変数}文字`のようにして組み立てることもできる。
* `Guid`は世界で一つだけのユニークなIdを作る仕組み。
* WebAPIはマルチスレッドで動作するので、`Dictionary`の代わりに`ConcurrentDictionary`を使おう。
