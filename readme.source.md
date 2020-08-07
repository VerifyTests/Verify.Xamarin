# <img src="/src/icon.png" height="30px"> Verify.Xamarin

[![Build status](https://ci.appveyor.com/api/projects/status/4qpinobb73u233lj?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-xamarin)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Xamarin.svg)](https://www.nuget.org/packages/Verify.Xamarin/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [Xamarin UIs](https://dotnet.microsoft.com/apps/xamarin).

Leverages [Xamarin.UITest](https://docs.microsoft.com/en-us/appcenter/test-cloud/frameworks/uitest/) to capture the state of an app.

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-verify?utm_source=nuget-verify&utm_medium=referral&utm_campaign=enterprise).


<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>

toc


## NuGet package

https://nuget.org/packages/Verify.Xamarin/


## Usage


### App


#### Main content

snippet: content_main.xml


#### Make Fullscreen

To prevent the tool bar header (that contains a clock) from making the snapshots unreliable, it is necessary to make the app full screen when running tests.

Add the following to the main activity:

snippet: makeFullscreen


### Testing


#### Setup

Enable VerifyXamarin once at assembly load time:

snippet: Enable

Setup the app

snippet: AppSetup


#### App test

The current app state can then be verified as follows:

snippet: AppUsage

With the state of the control being rendered as a verified files:

snippet: TheTests.AppUsage.info.verified.txt

[TheTests.AppUsage.verified.png](/src/Tests/TheTests.AppUsage.verified.png):

<img src="/src/Tests/TheTests.AppUsage.verified.png" width="400px">


#### Control test

An element can be verified as follows:

snippet: ControlUsage

With the state of the control being rendered as a verified files:

snippet: TheTests.ControlUsage.info.verified.txt

[TheTests.ControlUsage.verified.png](/src/Tests/TheTests.ElementControlUsage.verified.png):

<img src="/src/Tests/TheTests.ControlUsage.verified.png" width="400px">


## OS specific rendering

The rendering of Form elements can very slightly between different OS versions. This can make verification on different machines (eg CI) problematic. There are several approaches to mitigate this:

 * Using a [custom comparer](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md)


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Monkey](https://thenounproject.com/term/monkey/2006781/) designed by [Maxim Kulikov](https://thenounproject.com/maxim221/) from [The Noun Project](https://thenounproject.com).