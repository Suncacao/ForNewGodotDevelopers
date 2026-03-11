# Simple Game Options System (Godot C#)

A simple Options / Settings system example for games made with Godot + C#.

This project demonstrates several commonly used settings features, including saving and loading settings automatically.

The project can be exported and run on Windows OS.

This repository is mainly intended as a learning resource for beginner game developers.

godot ver:4.5.1

---

## Features

- Basic Options / Settings menu
- Automatic saving when settings are changed
- Automatic loading when the game restarts
- Implemented using C#
- Works with Windows export
- Custom language (localization) system
- Sound Manager plugin integration

---

## Audio System

Audio playback in this project uses the Sound Manager plugin.

Plugin link:  
https://godotengine.org/asset-library/asset/2048

also,BGM by MaouDamashii
---

## Localization System

The localization system in this project does not use Godot's built-in localization system.

Instead, I implemented a simple custom language system.  
All related files are included in the project for reference.

This may help developers understand how a basic localization system can be implemented manually.

Related files:
LanguageManager.cs
LanguageJsonData.cs
LoadLangforLable.cs
LocalizationManager.cs
---

## Purpose of This Project

This project was created as a practice and reference example.

I have never used this system in a real production project, but I hope it can help new developers learn how to implement a basic options system in their own games.

---

## Target Users

This project may be useful for:

- Beginner Godot developers
- Developers learning C# with Godot
- People looking for a simple Options menu example
- Developers who want to understand basic settings saving
