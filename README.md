# Coffee.Security

**Security simplified**

![Logo][logo]

## Overview

* [Installation](#installation)
* [Example](#example)

## Installation

```
nuget install Coffee.Security -Source http://robhendriks.azurewebsites.net/nuget
```

## Example

```cs
var manager = UserManager.Instance;

manager.SignedIn += (sender, e) => Console.WriteLine($"{e.User} signed in..");
manager.SignedOut += (sender, e) => Console.WriteLine($"{e.User} signed out..");
```

```cs
IUser john = new DummyUser("John")
    , jane = new DummyUser("Jane");

john.SignIn(); // Sign in as John
jane.SignIn(); // Sign in as Jane (replacing John)
jane.SignOut(); // Sign out
```

```
> John signed in..
> John signed out..
> Jane signed in..
> Jane signed out..
```

[logo]: /docs/logo-64x64.png