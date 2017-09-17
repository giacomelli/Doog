Doog
===========

[![Build status](https://ci.appveyor.com/api/projects/status/57spmopic2m8kau5?svg=true)](https://ci.appveyor.com/project/giacomelli/doog) [![Coverage Status](https://coveralls.io/repos/github/giacomelli/Doog/badge.svg?branch=master)](https://coveralls.io/github/giacomelli/Doog?branch=master)

Doog is a platform to create games that looks like old games, but using advanced game programming patterns in order to create games where the implementation is agnostic of how its graphics, sounds and inputs are really implemented.

The default support is for console/terminal graphics, as you can see in the images below, but we also have a initial MonoGame graphics implementation and an experimental implementio of Unity3d graphics.

![](docs/gifs/Easings-2017-09-16.gif)

--------

## Feature
* Animations (30+ easings)
* Font System
* Graphic system (console/terminal and MonoGame)
* Input system
* Log system (console and file)
* Physic system (currently supporing just collision detection)
* Transform (position, scale and rotation)

## Games
Nowadays we have just a Snake game implementation that show how to use Doog.Framework to create a old style game. 

### Snake
![](docs/gifs/Snake-2017-09-16.gif)

## Boundaries
* Graphic agnostic
* Sound agnostic
* Input agnostic
* Use of classic game programming patterns (http://gameprogrammingpatterns.com)
* Follow the SOLID principles

## How to run it?
1. Download the binaries from the lastest CI build: [https://ci.appveyor.com/project/giacomelli/doog/build/artifacts](https://ci.appveyor.com/project/giacomelli/doog/build/artifacts)

2. Open a console/terminal and type:

### Using the console runner

*Snake game*:

```shell
mono Doog.Runners.Console.exe Snake.dll
```

*Doog.Framework samples:*

```shell
mono Doog.Runners.Console.exe Doog.Framework.Samples.dll
```

### Using the MonoGame runner

*Snake game*:

```shell
mono Doog.Runners.MonoGameDesktop.exe Snake.dll
```

*Doog.Framework samples:*

```shell
mono Doog.Runners.MonoGameDesktop.exe Doog.Framework.Samples.dll
```


*Note: the "mono" is only need in a non Windows SO*

## How to debug it?
If you are developing a game using Doog.Framework and want some help to debug it, you can use the runners arguments below:

### debug-enabled
Shows some stats about the game world in the left-top corner of the game screen. Informations like FPS and currenlty enabled components count.

```shell
mono Doog.Runners.Console.exe Snake.dll debug-enabled
```

### ingame-log
Show the log messages registered by the LogSystem in the bottom part of the game screen.

```shell
mono Doog.Runners.Console.exe Snake.dll ingame-log
```

### file-log
Write the log messages registered by the LogSystem to the log.txt file.

```shell
mono Doog.Runners.Console.exe Snake.dll file-log
```

You can combine those arguments:

```shell
mono Doog.Runners.Console.exe Snake.dll debug-enabled ingame-log
```

## How to improve it?

Create a fork of [Doog](https://github.com/giacomelli/Doog/fork). 

Did you change it? [Submit a pull request](https://github.com/giacomelli/Doog/pull/new/master).

## License
Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.
