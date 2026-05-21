using Content.Client.Stylesheets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Client.Stylesheets.Sheetlets;

[CommonSheetlet]
public sealed class ItzushiPanelSheetlet<T> : Sheetlet<T>
    where T : PalettedStylesheet
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        var yokaiPanel = new StyleBoxFlat
        {
            BackgroundColor = Color.FromHex("#050505"),
            BorderColor = Color.FromHex("#8A8A8A"),
            BorderThickness = new Thickness(2),
        };
        var yokaiButton = new StyleBoxFlat
        {
            BackgroundColor = Color.White,
            BorderColor = Color.Black,
            BorderThickness = new Thickness(2),
        };

        var yokaiButtonHover = new StyleBoxFlat
        {
            BackgroundColor = Color.Black,
            BorderColor = Color.White,
            BorderThickness = new Thickness(2),
        };

        var yokaiButtonPressed = new StyleBoxFlat
        {
            BackgroundColor = Color.FromHex("#707070"),
            BorderColor = Color.White,
            BorderThickness = new Thickness(2),
        };

        var yokaiButtonDisabled = new StyleBoxFlat
        {
            BackgroundColor = Color.FromHex("#303030"),
            BorderColor = Color.FromHex("#555555"),
            BorderThickness = new Thickness(2),
        };

        return
        [
            E<PanelContainer>()
                .Class("YokaiPanel")
                .Prop(PanelContainer.StylePropertyPanel, yokaiPanel),

            E<PanelContainer>()
                .Class("YokaiPanelGray")
                .Prop(PanelContainer.StylePropertyPanel,
                    new StyleBoxFlat
                {
                    BackgroundColor = Color.FromHex("#181818"),
                    BorderColor = Color.FromHex("#8A8A8A"),
                    BorderThickness = new Thickness(2),
                }),

            E<PanelContainer>()
                .Class("YokaiPanelWhite")
                .Prop(PanelContainer.StylePropertyPanel,
                    new StyleBoxFlat
                {
                    BackgroundColor = Color.FromHex("#E8E8E8"),
                    BorderColor = Color.Black,
                    BorderThickness = new Thickness(2),
                }),

            CButton()
                .Class("YokaiButton")
                .PseudoNormal()
                .Box(yokaiButton)
                .Modulate(Color.White),

            CButton()
                .Class("YokaiButton")
                .PseudoHovered()
                .Box(yokaiButtonHover)
                .Modulate(Color.White),

            CButton()
                .Class("YokaiButton")
                .PseudoPressed()
                .Box(yokaiButtonPressed)
                .Modulate(Color.White),

            CButton()
                .Class("YokaiButton")
                .ParentOf(E<Label>())
                .FontColor(Color.Black),

            CButton()
                .Class("YokaiButton")
                .PseudoHovered()
                .ParentOf(E<Label>())
                .FontColor(Color.White),

            CButton()
                .Class("YokaiButton")
                .PseudoPressed()
                .ParentOf(E<Label>())
                .FontColor(Color.White),

            CButton()
                .Class("YokaiButton")
                .PseudoDisabled()
                .Box(yokaiButtonDisabled)
                .Modulate(Color.White),

            CButton()
                .Class("YokaiButton")
                .PseudoDisabled()
                .ParentOf(E<Label>())
                .FontColor(Color.FromHex("#777777")),
        ];

    }
    private static MutableSelectorElement CButton()
    {
        return E<ContainerButton>().Class(ContainerButton.StyleClassButton);
    }
}

