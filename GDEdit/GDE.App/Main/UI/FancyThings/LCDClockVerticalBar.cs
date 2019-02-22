﻿using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osu.Framework;
using osuTK;
using osuTK.Graphics;
using GDE.App.Main.Colors;
using osu.Framework.Input.Events;
using System;

namespace GDE.App.Main.UI.FancyThings
{
    public class LCDClockVerticalBar : LCDClockBar
    {
        public LCDClockVerticalBar(bool enabled = false) : base(enabled) { }

        protected override void InitializeBar()
        {
            Size = new Vector2(Dimension, SizeRatio * Dimension);
            Bar = new Box
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativePositionAxes = Axes.None,
                Size = new Vector2(Dimension, SizeRatio * Dimension),
            };
            TriangleA = new EquilateralTriangle
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativePositionAxes = Axes.None,
                Y = SizeRatio * Dimension / 2 + Dimension,
                Size = new Vector2(Dimension),
            };
            TriangleB = new EquilateralTriangle
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativePositionAxes = Axes.None,
                Y = -SizeRatio * Dimension / 2 - Dimension,
                Size = new Vector2(Dimension),
                Rotation = -180,
            };
        }
    }
}
