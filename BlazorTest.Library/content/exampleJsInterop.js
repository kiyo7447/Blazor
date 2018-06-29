// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

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



