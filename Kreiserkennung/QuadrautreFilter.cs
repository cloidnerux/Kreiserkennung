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
    class QuadrautreFilter : BaseUsingCopyPartialFilter
    {
        private Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations
        {
            get { return formatTranslations; }
        }

        public QuadrautreFilter()
        {
            // initialize format translation dictionary
            formatTranslations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
        }

        protected override void ProcessFilter(UnmanagedImage sourceData, UnmanagedImage destinationData, Rectangle rect)
        {
            int tmp;
            for (int i = 0; i < rect.Width; i++)
            {
                for (int a = 0; a < rect.Height; a++)
                {
                    tmp = sourceData.GetPixel(i+rect.X, a+rect.Y).R;
                    tmp *= tmp;
                    tmp /= 255;
                    destinationData.SetPixel(i + rect.X, a + rect.Y, (byte)tmp);
                }
            }
        }
    }
}
