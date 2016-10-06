# bgwait

bgwaitコマンドは、unix シェルの waitコマンドのような働きをします。  

## 使い方

a.bat と b.bat と c.bat  を並列で実行し、全ての実行が終了したら d.bat を実行したい。  

以下の例では、a.bat b.bat c.bat をバックグラウンドで起動し d.bat を起動しています。  
a.bat b.bat c.bat それぞれの実行終了を待たずに d.bat が実行されることになります。
    @echo off
    start a.bat
    start b.bat
    start c.bat
    rem -- 
    call d.bat

bgwaitコマンドを使えば a.bat b.bat c.bat が終了するまで d.bat の実行が行われません。
    @echo off
    start a.bat
    start b.bat
    start c.bat
    rem -- wait a.bat,b.bat,c.bat
    bgwait
    call d.bat
	
## 実行時の制限

bgwaitコマンドは、自分の親プロセスと同じ親プロセスIDを持つプロセスをWMIを使って10秒間隔で監視します。 バックグラウンド実行させたプログラムが10秒以内に終了していてもbgwaitコマンドの終了まで最大10秒待たされることになります。
