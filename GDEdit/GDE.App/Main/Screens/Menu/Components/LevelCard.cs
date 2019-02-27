﻿using GDE.App.Main.Colors;
using GDEdit.Utilities.Objects.GeometryDash;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;

namespace GDE.App.Main.Screens.Menu.Components
{
    public class LevelCard : ClickableContainer
    {
        private Box selectionBar;
        private Box hoverBox;
        private SpriteText levelName, levelAuthor, levelLength;

        public Bindable<Level> Level = new Bindable<Level>(new Level
        {
            Name = "Unknown name",
            CreatorName = "UnkownCreator",
        });

        public Bindable<bool> Selected = new Bindable<bool>(false);

        public LevelCard()
        {
            Children = new Drawable[]
            {
                hoverBox = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = GDEColors.FromHex("161616")
                },
                selectionBar = new Box
                {
                    RelativeSizeAxes = Axes.Y,
                    Size = new Vector2(5, 1f),
                    Colour = GDEColors.FromHex("202020")
                },
                new FillFlowContainer
                {
                    Direction = FillDirection.Vertical,
                    RelativeSizeAxes = Axes.Both,
                    Margin = new MarginPadding
                    {
                        Left = 10
                    },
                    Children = new Drawable[]
                    {
                        levelName = new SpriteText
                        {
                            Text = Level.Value.Name,
                            TextSize = 30
                        },
                        levelAuthor = new SpriteText
                        {
                            Text = Level.Value.CreatorName,
                            TextSize = 20,
                            Colour = GDEColors.FromHex("aaaaaa")
                        }
                    }
                },
                levelLength = new SpriteText
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomRight,
                    Margin = new MarginPadding(5),
                    Text = "Tiny",
                    TextSize = 20,
                    Colour = GDEColors.FromHex("aaaaaa")
                }
            };

            Selected.ValueChanged += OnSelected;
            Level.ValueChanged += OnlevelChange;
        }

        private void OnlevelChange(Level obj)
        {
            levelName.Text = obj.Name;
            levelAuthor.Text = obj.CreatorName;
        }

        private void OnSelected(bool obj) =>
            selectionBar.FadeColour(obj ? GDEColors.FromHex("202020") : GDEColors.FromHex("00bc5c"), 200);

        protected override bool OnHover(HoverEvent e)
        {
            hoverBox.FadeColour(GDEColors.FromHex("1c1c1c"), 500);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            hoverBox.FadeColour(GDEColors.FromHex("161616"), 500);
            base.OnHoverLost(e);
        }

        protected override bool OnClick(ClickEvent e)
        {
            Selected.Value = !Selected.Value;
            return base.OnClick(e);
        }
    }
}