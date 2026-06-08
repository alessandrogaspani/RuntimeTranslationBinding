# RuntimeTranslationBinding

RuntimeTranslationBinding is a .NET 8 sample that shows how to implement runtime localization and culture switching in desktop apps.

It includes both:

- **WPF**
- **WinUI 3**

The goal of the project is to keep UI strings fully bindable so the language can change at runtime without restarting the application.

## Features

- Runtime culture switching
- Resource-based localization with `.resx` files
- Dynamic UI updates when the language changes
- Shared localization core for multiple desktop UI frameworks
- Sample implementations for WPF and WinUI 3

## Supported languages

- English (`en-US`)
- Italian (`it-IT`)

## Solution structure

- `RuntimeTranslationBinding.Core`  
  Shared localization logic, culture handling, and resource access.

- `RuntimeTranslationBinding.Wpf`  
  WPF sample application using a custom binding extension for localized strings.

- `RuntimeTranslationBinding.WinUI3`  
  WinUI 3 sample application using a markup extension for localized strings.

## How it works

The localization system is based on:

1. A shared `LocalizationService` class.
2. A `TranslationSource` object that exposes localized values through indexer binding.
3. Resource files containing the translated strings.
4. UI bindings that refresh automatically when the current culture changes.

When the user selects a language, the app updates the current culture and notifies the UI so the visible text changes immediately.

## Getting started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2026 or later with desktop development workload
- Windows App SDK / WinUI 3 support for the WinUI project

### Build and run

1. Open the solution in Visual Studio.
2. Select either the WPF or WinUI 3 startup project.
3. Build and run the application.
4. Use the language buttons to switch between English and Italian.

## Localization files

Translations are stored in the shared resource files:

- `RuntimeTranslationBinding.Core/Properties/Resources.resx`
- `RuntimeTranslationBinding.Core/Properties/Resources.it-IT.resx`

To add a new language:

1. Create a new `.resx` file for the target culture.
2. Add the translated keys.
3. Extend the `LanguageValues` enum.
4. Update `LocalizationService.GetCultureInfo` and `SupportedLanguages`.

## Example usage

```csharp
LocalizationService.ChangeCulture(LanguageValues.it_IT);
```

## Notes

This repository is intended as a learning and reference project for runtime localization patterns in modern .NET desktop applications.

## License

Add your preferred license here.
