using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace Kreiserkennung
{
    public class GradientFilter : BaseUsingCopyPartialFilter
    {
        public int levels
        {
            get;
            set;
        }

        private Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations
        {
            get { return formatTranslations; }
        }

        public GradientFilter()
        {
            // initialize format translation dictionary
            formatTranslations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
            levels = 16;
        }

        public GradientFilter(int level)
        {
            // initialize format translation dictionary
            formatTranslations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
            levels = level;
        }

        protected override unsafe void ProcessFilter(UnmanagedImage sourceData, UnmanagedImage destinationData, System.Drawing.Rectangle rect)
        {
            int tmp;
            for (int i = rect.X; i < rect.Width; i++)
            {
                for (int a = rect.Y; a < rect.Height; a++)
                {
                    tmp = (sourceData.GetPixel(i, a).R * levels / 256);
                    tmp = tmp * 256 / levels;
                    destinationData.SetPixel(i, a, (byte)tmp);
                }
            }
        }
    }
}
