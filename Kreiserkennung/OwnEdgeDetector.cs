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
    class OwnEdgeDetector : BaseUsingCopyPartialFilter
    {
        private Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations
        {
            get { return formatTranslations; }
        }

        public OwnEdgeDetector()
        {
            // initialize format translation dictionary
            formatTranslations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
        }

        private byte limit(int n)
        {
            if (n < 0) return 0;
            else if (n > 255) return 255;
            return (byte)n;
        }

        protected override unsafe void ProcessFilter(UnmanagedImage sourceData, UnmanagedImage destinationData, System.Drawing.Rectangle rect)
        {
            int[] filterParam = new int[] { -1, -3, -3, -3, 0, 3, 3, 3, 1 };
            int max = 0;
            int[] gradient = new int[rect.Width];
            int shift = (filterParam.Count() - 1) / 2;
            for (int i = 0; i < rect.Height; i++)
            {
                for (int a = 0; a < (rect.Width - shift); a++)
                {
                    gradient[a] = 0;
                    for (int b = 0; b < filterParam.Count(); b++)
                    {
                        gradient[a] += filterParam[b] * ((((a + b) - shift) < 0) ? (0) : (sourceData.GetPixel(((a + b) - shift), i).R));
                    }
                    gradient[a] = Math.Abs(gradient[a]);
                    max = Math.Max(max, gradient[a]);
                }
                for(int a = 0; a < rect.Width; a++)
                {
                    if (max == 0)
                        continue;
                    gradient[a] = gradient[a] * 255 / max;
                    destinationData.SetPixel(a, i, (byte)gradient[a]);
                }
            }
        }
    }
}
