# TR.ATSPI.Logger
[![Build & Test](https://github.com/TetsuOtter/TR.ATSPI.Logger/actions/workflows/dotnet.yml/badge.svg)](https://github.com/TetsuOtter/TR.ATSPI.Logger/actions/workflows/dotnet.yml)
[![Publish To nuget.org](https://github.com/TetsuOtter/TR.ATSPI.Logger/actions/workflows/publish.yml/badge.svg)](https://github.com/TetsuOtter/TR.ATSPI.Logger/actions/workflows/publish.yml)

Print the ATSPI-Function Exec log

BVEから実行されたATSPIの機能(関数)を, デバッグコンソールに出力します.

## How to use
車両のATSPIとして本dllが読み込まれるようにしてください.  BVE5の場合は"TR.ATSPI.Logger.x86.dll"を, BVE6の場合は"~.x64.dll"を, それぞれ使用してください.

プラグインが読み込まれると, デバッガを指定するようウィンドウで通知されます.  指示に従い, デバッガをあててください.

## License
本リポジトリには, 異なるライセンスを持つファイルが含まれています.  ご注意ください.

リポジトリのルートにある"DllExport.bat"は, DllExport使用のために含んでいるファイルです.  このファイルに関しては, [Denis Kuzmin氏(github/3F)](https://github.com/3F)が著作権を有しており, MITライセンスの下, リポジトリに含ませていただいています.

上で挙げたファイル以外は, 成果物を含めCC0として出します.  デバッグ用途にしか使えないと思いますし, 車両に組み込んだまま公開するとかは想像できないですが, どうにせよ自由に使ってください.

## Add the output destination
既定では, デバッグコンソールへの出力としています.  これは, ILoggerインターフェースを実装するLogToDebugクラスを使用して実現しています.

LogToDebugクラスを使用する指定は, ManagedIFクラス内7行目付近で行っています.  別の場所への出力機能を実装したクラスを使用したい場合は, この箇所で初期化するクラスを変更してください.

ILoggerインターフェースでは, string型のコメントまたはint型の値引数と, 呼び出し元のメソッド名を取得する為の引数の2引数をもつ2メソッドを要件としています.  
LogToDebugクラスみたく, 適当にプライベートメソッドを作って, それを使用して出力する方法が楽だと思います.

## Reference
参照しているライブラリは, 以下のとおりです.

- DllExport v1.7.4 (MIT License)
  - [GitHub (3F/DllExport)](https://github.com/3F/DllExport)
  - [nuget.org](https://www.nuget.org/packages/DllExport/)
- ILMerge v3.0.41 (MIT License)
  - [GitHub (dotnet/ILMerge)](https://github.com/dotnet/ILMerge)
  - [nuget.org](https://www.nuget.org/packages/ILMerge/)
- IAtsPI v1.0.0.2 (CC0 License)
  - [GitHub (TetsuOtter/IAtsPI)](https://github.com/TetsuOtter/IAtsPI)
  - [nuget.org](https://www.nuget.org/packages/IAtsPI/)
