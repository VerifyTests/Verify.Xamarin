# <img src="/src/icon.png" height="30px"> Verify.Xamarin

[![Build status](https://ci.appveyor.com/api/projects/status/4qpinobb73u233lj?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-xamarin)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Xamarin.svg)](https://www.nuget.org/packages/Verify.Xamarin/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [Xamarin UIs](https://dotnet.microsoft.com/apps/xamarin).

Leverages [Xamarin.UITest](https://docs.microsoft.com/en-us/appcenter/test-cloud/frameworks/uitest/) to capture the state of an app.



## NuGet package

https://nuget.org/packages/Verify.Xamarin/


## Usage


### App


#### Main content

Given an app with a text control:

<!-- snippet: content_main.xml -->
<a id='snippet-content_main.xml'></a>
```xml
<?xml version="1.0" encoding="utf-8"?>
<RelativeLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    app:layout_behavior="@string/appbar_scrolling_view_behavior"
    tools:showIn="@layout/activity_main">

    <TextView
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:layout_centerInParent="true"
        android:id="@+id/theText"
        android:text="Hello World!" />

</RelativeLayout>
```
<sup><a href='/src/SampleXamarin/Resources/layout/content_main.xml#L1-L17' title='Snippet source file'>snippet source</a> | <a href='#snippet-content_main.xml' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### Make Fullscreen

To prevent the tool bar header (that contains a clock) from making the snapshots unreliable, it is necessary to make the app full screen when running tests.

Add the following to the main activity:

<!-- snippet: makeFullscreen -->
<a id='snippet-makefullscreen'></a>
```cs
protected override void OnCreate(Bundle bundle)
{
#if DEBUG
    Window.AddFlags(WindowManagerFlags.Fullscreen);
    Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
#endif
```
<sup><a href='/src/SampleXamarin/MainActivity.cs#L16-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-makefullscreen' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Testing


#### Setup

Enable VerifyXamarin once at assembly load time:

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
VerifyXamarin.Enable();
```
<sup><a href='/src/Tests/TheTests.cs#L56-L60' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Setup the app

<!-- snippet: AppSetup -->
<a id='snippet-appsetup'></a>
```cs
app = ConfigureApp
    .Android
    .EnableLocalScreenshots()
    .ApkFile(apkPath)
    .StartApp();
```
<sup><a href='/src/Tests/TheTests.cs#L43-L51' title='Snippet source file'>snippet source</a> | <a href='#snippet-appsetup' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### App test

The current app state can then be verified as follows:

<!-- snippet: AppUsage -->
<a id='snippet-appusage'></a>
```cs
[Test]
public async Task AppUsage()
{
    await Verify(app);
}
```
<sup><a href='/src/Tests/TheTests.cs#L28-L36' title='Snippet source file'>snippet source</a> | <a href='#snippet-appusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the control being rendered as:

<!-- snippet: TheTests.AppUsage.info.verified.txt -->
<a id='snippet-TheTests.AppUsage.info.verified.txt'></a>
```txt
[
  {
    Class: 'DecorView',
    Rect: 'w:1080 h:1920 x:0 y:0'
  },
  {
    Class: 'LinearLayout',
    Rect: 'w:1080 h:1794 x:0 y:0'
  },
  {
    Class: 'FrameLayout',
    Rect: 'w:1080 h:1794 x:0 y:0'
  },
  {
    Id: 'action_bar_root',
    Class: 'FitWindowsLinearLayout',
    Rect: 'w:1080 h:1794 x:0 y:0'
  },
  {
    Id: 'content',
    Class: 'ContentFrameLayout',
    Rect: 'w:1080 h:1794 x:0 y:0'
  },
  {
    Class: 'CoordinatorLayout',
    Rect: 'w:1080 h:1794 x:0 y:0'
  },
  {
    Class: 'AppBarLayout',
    Rect: 'w:1080 h:147 x:0 y:0'
  },
  {
    Id: 'toolbar',
    Class: 'Toolbar',
    Rect: 'w:1080 h:147 x:0 y:0'
  },
  {
    Text: 'SampleXamarin',
    Class: 'AppCompatTextView',
    Rect: 'w:379 h:71 x:42 y:38'
  },
  {
    Class: 'ActionMenuView',
    Rect: 'w:105 h:147 x:975 y:0'
  },
  {
    Label: 'More options',
    Class: 'ActionMenuPresenter$OverflowMenuButton',
    Rect: 'w:105 h:126 x:975 y:10'
  },
  {
    Class: 'RelativeLayout',
    Rect: 'w:1080 h:1647 x:0 y:147'
  },
  {
    Id: 'theText',
    Text: 'Hello World!',
    Class: 'AppCompatTextView',
    Rect: 'w:200 h:51 x:440 y:945'
  },
  {
    Id: 'fab',
    Class: 'FloatingActionButton',
    Rect: 'w:147 h:147 x:891 y:1605'
  },
  {
    Id: 'navigationBarBackground',
    Class: 'View',
    Rect: 'w:1080 h:126 x:0 y:1794'
  }
]
```
<sup><a href='/src/Tests/TheTests.AppUsage.info.verified.txt#L1-L71' title='Snippet source file'>snippet source</a> | <a href='#snippet-TheTests.AppUsage.info.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<img src="/src/Tests/TheTests.AppUsage.verified.png" width="300px">


#### Control test

A control can be verified as follows:

<!-- snippet: ControlUsage -->
<a id='snippet-controlusage'></a>
```cs
[Test]
public async Task ControlUsage()
{
    var appResult = app.Query(x => x.Id("theText"))
        .Single();
    var data = new ControlData(app, appResult);
    await Verify(data);
}
```
<sup><a href='/src/Tests/TheTests.cs#L15-L26' title='Snippet source file'>snippet source</a> | <a href='#snippet-controlusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the control being rendered as:

<!-- snippet: TheTests.ControlUsage.info.verified.txt -->
<a id='snippet-TheTests.ControlUsage.info.verified.txt'></a>
```txt
{
  Id: 'theText',
  Text: 'Hello World!',
  Class: 'AppCompatTextView',
  Rect: 'w:200 h:51 x:440 y:945'
}
```
<sup><a href='/src/Tests/TheTests.ControlUsage.info.verified.txt#L1-L6' title='Snippet source file'>snippet source</a> | <a href='#snippet-TheTests.ControlUsage.info.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<img src="/src/Tests/TheTests.ControlUsage.verified.png" width="300px">


## OS specific rendering

The rendering of Form elements can very slightly between different OS versions. This can make verification on different machines (eg CI) problematic. There are several approaches to mitigate this:

 * Using a [custom comparer](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md)



## Icon

[Monkey](https://thenounproject.com/term/monkey/2006781/) designed by [Maxim Kulikov](https://thenounproject.com/maxim221/) from [The Noun Project](https://thenounproject.com).
