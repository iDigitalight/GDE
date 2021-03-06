﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Functions.Extensions;
using GDEdit.Utilities.Enumerations.GeometryDash;

namespace GDEdit.Utilities.Objects.GeometryDash.ColorChannels
{
    /// <summary>Represents the color channels of a level.</summary>
    public class LevelColorChannels
    {
        private ColorChannel[] colors = new ColorChannel[5000];

        /// <summary>Gets or sets the color at the specified color channel ID.</summary>
        /// <param name="colorID">The color channel ID whose color to get or set.</param>
        public ColorChannel this[int colorID]
        {
            get => colors[colorID];
            set => colors[colorID] = value;
        }
        /// <summary>Gets or sets the color at the specified special color channel ID.</summary>
        /// <param name="colorID">The special color channel ID whose color to get or set.</param>
        public ColorChannel this[SpecialColorID colorID]
        {
            get => colors[(int)colorID];
            set => colors[(int)colorID] = value;
        }

        /// <summary>Clones this <seealso cref="LevelColorChannels"/> instance and returns the cloned instance.</summary>
        public LevelColorChannels Clone()
        {
            LevelColorChannels result = new LevelColorChannels();
            result.colors = colors.CopyArray();
            return result;
        }

        /// <summary>Parses the level color string into a <seealso cref="LevelColorChannels"/> object.</summary>
        /// <param name="colorChannels">The level color string to parse.</param>
        public static LevelColorChannels Parse(string colorChannels)
        {
            string[] split = colorChannels.Split('|');
            LevelColorChannels result = new LevelColorChannels();
            foreach (var s in split)
            {
                if (s.Length == 0)
                    continue;
                var c = ColorChannel.Parse(s);
                result[c.ColorChannelID] = c;
            }
            return result;
        }
        /// <summary>Gets the common colors between a number of levels.</summary>
        /// <param name="levels">The levels to get the common colors of.</param>
        public static LevelColorChannels GetCommonColors(Level[] levels)
        {
            LevelColorChannels result = levels[0].ColorChannels.Clone();
            for (int i = 0; i < levels.Length; i++)
                for (int j = 0; j < result.colors.Length; j++)
                    if (result[j] != levels[i].ColorChannels[j])
                        result[j] = default;
            return result;
        }

        /// <summary>Returns the string of the <seealso cref="LevelColorChannels"/>.</summary>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var c in colors)
            {
                if (c == null)
                    continue;
                result.Append($"{c}|");
            }
            return result.ToString();
        }
    }
}
