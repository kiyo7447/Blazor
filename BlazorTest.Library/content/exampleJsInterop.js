// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

console.log('Blazor.registerFunction() Start');

Blazor.registerFunction('BlazorTest.Library.ExampleJsInterop.Prompt', function (message) {
    return prompt(message, 'Type anything here');
});


Blazor.registerFunction('BlazorFocus.FocusElement', function (element) {
    element.focus();
    element.select();

    //動作しない
    //var f = element;
    //setTimeout(function (f) {
    //    f.focus();
    //    f.select();
    //}, 100);
});


// コネクション作成
//let connection = new signalR.HubConnection('/chathub');

console.log('connection instance start');
var connection = new signalR.HubConnectionBuilder().withUrl('/chathub').build();
console.log('connection instance end');

// 受信処理
connection.on('AddMessage', Msg => {
    console.log("AddMessage()：受信処理：Msg.name=" + Msg.name + ", Msg.message=" + Msg.message);
    let AddMessageSMethod = Blazor.platform.findMethod(
        "BlazorTest.Client",                //assambleyName
        "BlazorTest.Client.Pages",          //namespace
        "Chat",                             //typeName
        "jusin"                             //methodName
    );
//    var ts = Blazor.platform.toDotNetString(Msg);
//↓オブジェクトを渡すことは出来ない。。。
    var ts = Blazor.platform.toDotNetString(JSON.stringify(Msg));
    Blazor.platform.callMethod(AddMessageSMethod, null, [ts]);
});

// 送信処理
Blazor.registerFunction("迷信", Msg => {
    console.log("迷信():Msg.name=" + Msg.name + ", Msg.message" + Msg.message);
    connection.invoke("PostMessage", Msg)
        .catch(e => console.log("迷信()" + e));
    console.log("迷信():Msg.name=" + Msg.name + ", Msg.message" + Msg.message);
    return true;
});

// ログ出力
Blazor.registerFunction("log", Msg => {
    console.log(Msg);
    return true;
});

// 接続開始
connection.start().catch(e => console.log(e));

console.log('Blazor.registerFunction() End');
