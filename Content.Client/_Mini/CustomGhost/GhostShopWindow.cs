using System.Numerics;
using Content.Shared._Mini.CustomGhost;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.Localization;
using Robust.Shared.Prototypes;

namespace Content.Client._Mini.CustomGhost;

public sealed class GhostShopWindow : DefaultWindow
{
    private readonly IPrototypeManager _proto;
    private readonly IResourceCache _resourceCache;
    private readonly GhostShopSystem _system;
    private readonly BoxContainer _themeContainer;
    private readonly Label _balanceLabel;
    private readonly Label _statusLabel;
    private int _balance;

    private static readonly string CoinIconPath = "/Textures/_Mini/Interface/Coin.png";

    public GhostShopWindow(IPrototypeManager proto, IResourceCache resourceCache, GhostShopSystem system)
    {
        _proto = proto;
        _resourceCache = resourceCache;
        _system = system;

        Title = Loc.GetString("ghost-shop-window-title");
        MinSize = new Vector2(600, 500);

        var root = new BoxContainer
        {
            Orientation = BoxContainer.LayoutOrientation.Vertical,
            Margin = new Thickness(8),
            VerticalExpand = true,
        };

        var headerContainer = new BoxContainer
        {
            Orientation = BoxContainer.LayoutOrientation.Horizontal,
            HorizontalExpand = true,
            Margin = new Thickness(0, 0, 0, 8),
        };

        var coinIcon = new TextureRect
        {
            Texture = _resourceCache.GetResource<TextureResource>(CoinIconPath),
            TextureScale = new Vector2(0.5f, 0.5f),
            Margin = new Thickness(0, 0, 4, 0),
        };

        _balanceLabel = new Label
        {
            Text = Loc.GetString("ghost-shop-loading"),
            VerticalAlignment = VAlignment.Center,
            FontColorOverride = Color.Gold,
        };

        headerContainer.AddChild(coinIcon);
        headerContainer.AddChild(_balanceLabel);

        var scrollContainer = new ScrollContainer
        {
            HScrollEnabled = false,
            VScrollEnabled = true,
            VerticalExpand = true,
            Margin = new Thickness(0, 4),
        };

        _themeContainer = new BoxContainer
        {
            Orientation = BoxContainer.LayoutOrientation.Vertical,
            HorizontalExpand = true,
        };

        scrollContainer.AddChild(_themeContainer);

        _statusLabel = new Label
        {
            Text = Loc.GetString("ghost-shop-status-select"),
            HorizontalAlignment = HAlignment.Center,
            Margin = new Thickness(0, 4),
        };

        root.AddChild(headerContainer);
        root.AddChild(scrollContainer);
        root.AddChild(_statusLabel);

        Contents.AddChild(root);
    }

    public void UpdateState(GhostShopStateEvent state)
    {
        _balance = state.Balance;
        _balanceLabel.Text = Loc.GetString("ghost-shop-balance", ("balance", _balance));
        _themeContainer.RemoveAllChildren();

        if (state.Themes.Count == 0)
        {
            _themeContainer.AddChild(new Label
            {
                Text = Loc.GetString("ghost-shop-empty"),
                HorizontalAlignment = HAlignment.Center,
                VerticalAlignment = VAlignment.Center,
            });
            return;
        }

        foreach (var entry in state.Themes)
        {
            var card = new GhostThemeCard(entry, _resourceCache, _system);
            _themeContainer.AddChild(card);
        }
    }

    private sealed class GhostThemeCard : PanelContainer
    {
        public GhostThemeCard(GhostThemeEntry entry, IResourceCache resourceCache, GhostShopSystem system)
        {
            Margin = new Thickness(0, 0, 0, 4);
            MinSize = new Vector2(0, 80);
            ModulateSelfOverride = new Color(0.12f, 0.12f, 0.14f);

            var root = new BoxContainer
            {
                Orientation = BoxContainer.LayoutOrientation.Horizontal,
                Margin = new Thickness(8),
                HorizontalExpand = true,
            };

            var icon = new TextureRect
            {
                TextureScale = new Vector2(2f, 2f),
                MinSize = new Vector2(64, 64),
                VerticalAlignment = VAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0),
            };

            if (!string.IsNullOrEmpty(entry.IconRsiPath) && !string.IsNullOrEmpty(entry.IconRsiState))
            {
                var tex = system.GetIconTexture(entry.IconRsiPath, entry.IconRsiState);
                if (tex != null)
                    icon.Texture = tex;
            }

            var infoContainer = new BoxContainer
            {
                Orientation = BoxContainer.LayoutOrientation.Vertical,
                HorizontalExpand = true,
                VerticalAlignment = VAlignment.Center,
            };

            var nameLabel = new Label
            {
                Text = entry.Name,
            };

            var descLabel = new Label
            {
                Text = entry.Description,
                FontColorOverride = Color.Gray,
            };

            infoContainer.AddChild(nameLabel);
            infoContainer.AddChild(descLabel);

            var buttonContainer = new BoxContainer
            {
                Orientation = BoxContainer.LayoutOrientation.Horizontal,
                VerticalAlignment = VAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0),
            };

            Button actionButton;

            if (entry.Owned && entry.Selected)
            {
                actionButton = new Button
                {
                    Text = Loc.GetString("ghost-shop-btn-selected"),
                    Disabled = true,
                    MinWidth = 100,
                };
            }
            else if (entry.Owned && !entry.Selected)
            {
                actionButton = new Button
                {
                    Text = Loc.GetString("ghost-shop-btn-select"),
                    MinWidth = 100,
                };
                actionButton.OnPressed += _ => system.RequestSelect(entry.Id);
            }
            else
            {
                var priceText = $"{entry.Price}";
                var priceContainer = new BoxContainer
                {
                    Orientation = BoxContainer.LayoutOrientation.Horizontal,
                    Margin = new Thickness(0, 0, 4, 0),
                    VerticalAlignment = VAlignment.Center,
                };

                TextureRect coinIcon;
                try
                {
                    coinIcon = new TextureRect
                    {
                        Texture = resourceCache.GetResource<TextureResource>(CoinIconPath),
                        TextureScale = new Vector2(0.4f, 0.4f),
                        Margin = new Thickness(0, 0, 2, 0),
                    };
                }
                catch
                {
                    coinIcon = new TextureRect();
                }

                priceContainer.AddChild(coinIcon);
                priceContainer.AddChild(new Label { Text = priceText, FontColorOverride = Color.Gold });

                actionButton = new Button
                {
                    Text = Loc.GetString("ghost-shop-btn-buy"),
                    MinWidth = 100,
                };
                actionButton.OnPressed += _ =>
                {
                    actionButton.Disabled = true;
                    system.RequestBuy(entry.Id);
                };

                buttonContainer.AddChild(priceContainer);
            }

            buttonContainer.AddChild(actionButton);
            root.AddChild(icon);
            root.AddChild(infoContainer);
            root.AddChild(buttonContainer);
            AddChild(root);
        }
    }
}
