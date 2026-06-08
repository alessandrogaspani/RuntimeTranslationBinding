using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;
using RuntimeTranslationBinding.Core.Localization;

namespace RuntimeTranslationBinding.WinUI3.Localization;

[MarkupExtensionReturnType(ReturnType = typeof(Binding))]
public sealed class LocalizationExtension : MarkupExtension
{
    public string? Key { get; set; }

    public LocalizationExtension()
    {
        LocalizationService.CurrentTranslationSource.PropertyChanged += (_, e) =>
        {
            // WinUI 3 bindings re-evaluate when the source notifies changes.
        };
    }

    protected override object ProvideValue()
    {
        var key = Key ?? string.Empty;

        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = new PropertyPath($"[{key}]"),
            Source = LocalizationService.CurrentTranslationSource,
            FallbackValue = key,
        };
    }
}
