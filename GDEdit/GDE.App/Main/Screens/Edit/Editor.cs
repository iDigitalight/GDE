﻿using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;
using GDE.App.Main.Colours;
using GDE.App.Main.Levels;

namespace GDE.App.Main.Screens.Edit
{
    public class Editor : Screen
    {
        private TextureStore texStore;
        private Box background;

        public Editor()
        {
            AddRange(new Drawable[]
            {
                background = new Box
                {
                    Origin = Anchor.BottomLeft,
                    Anchor = Anchor.BottomLeft,
                    Depth = float.MaxValue,
                    Colour = GDEColours.FromHex("287dff"),
                    Size = new Vector2(2048, 2048)
                },
                new LevelPreview
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                }
            });
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore ts)
        {
            texStore = ts;
            background.Texture = texStore.Get("Backgrounds/game_bg_01_001-uhd.png");
        }
    }
}