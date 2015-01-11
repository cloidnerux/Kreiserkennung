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
    class DifferentialFilter : BaseUsingCopyPartialFilter
    {
        private Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations
        {
            get { return formatTranslations; }
        }

        public DifferentialFilter()
        {
            // initialize format translation dictionary
            formatTranslations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
        }

        protected override void ProcessFilter(UnmanagedImage sourceData, UnmanagedImage destinationData, Rectangle rect)
        {
            for (int i = 1; i < rect.Width; i++)
            {
                for (int a = 0; a < rect.Height; a++)
                {
                    destinationData.SetPixel(i + rect.X, a + rect.Y, (byte)Math.Abs(sourceData.GetPixel(i + rect.X, a + rect.Y).R - sourceData.GetPixel(i + rect.X-1, a + rect.Y).R));
                }
            }
        }
    }
}
