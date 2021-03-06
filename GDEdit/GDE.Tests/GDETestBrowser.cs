﻿using GDE.App.Main;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;
using osu.Framework.Testing;
using osuTK.Graphics;

namespace GDE.Tests
{
    public class GDETestBrowser : GDEAppBase
    {
        protected override void LoadComplete()
        {
            base.LoadComplete();

            Add(new TestBrowser("GDE.Tests"));
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
        }
    }
}
