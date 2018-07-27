// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

console.log('Blazor.registerFunction() Start');

Blazor.registerFunction('BlazorTest.Library.ExampleJsInterop.Prompt', function (message) {
    return prompt(message, 'Type anything here');
});

Blazor.registerFunction('BlazorTest.Library.ExampleJsInterop.Confirm', function (message) {
    return confirm(message);
});

console.log('Blazor.registerFunction() End');

console.log('Blazor.registerFocus() Start');

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


Blazor.registerFunction('BlazorTest.Library.ExampleJsInterop.Focus', function (id) {
    var elem = document.getElementById(id);
    elem.focus();
    elem.select();
});

console.log('Blazor.registerFocus() End');


console.log('Blazor.registerChat() Start');

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

console.log('Blazor.registerChat() End');


console.log('Geolocation Start');



/***** ユーザーの現在の位置情報を取得 *****/
function successCallback(position) {
    var gl_text = "緯度：" + position.coords.latitude + "<br>";
    gl_text += "経度：" + position.coords.longitude + "<br>";
    gl_text += "高度：" + position.coords.altitude + "<br>";
    gl_text += "緯度・経度の誤差：" + position.coords.accuracy + "<br>";
    gl_text += "高度の誤差：" + position.coords.altitudeAccuracy + "<br>";
    gl_text += "方角：" + position.coords.heading + "<br>";
    gl_text += "速度：" + position.coords.speed + "<br>";
    //document.getElementById("show_result").innerHTML = gl_text;

    console.log(gl_text);
}



/***** 位置情報が取得できない場合 *****/
function errorCallback(error) {
    var err_msg = "";
    switch (error.code) {
        case 1:
            err_msg = "位置情報の利用が許可されていません";
            break;
        case 2:
            err_msg = "デバイスの位置が判定できません";
            break;
        case 3:
            err_msg = "タイムアウトしました";
            break;
    }
    //document.getElementById("show_result").innerHTML = err_msg;
    //デバッグ用→　document.getElementById("show_result").innerHTML = error.message;
    console.log('Geolocation API error:' + err_msg);
    
}

console.log('Geolocation API チェック開始');
if (navigator.geolocation) {
    console.log('Geolocation APIは使えます');
    //Geolocation APIを利用できる環境向けの処理
    //ユーザーの現在の位置情報を取得
    navigator.geolocation.getCurrentPosition(
        successCallback, errorCallback
    );

} else {
    //Geolocation APIを利用できない環境向けの処理

    console.log('Geolocation APIが使用できません。');
}

console.log('Geolocation End');
