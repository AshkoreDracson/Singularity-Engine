using System;
using System.Drawing;
using System.Collections.Generic;
using Singularity;

namespace Singularity.Core
{
    public class TileSet
    {
        public Image tileSet;
        public List<Image> tileList = new List<Image>();
        public TileSet(Image tileset, int size)
        {
            tileSet = tileset;
            Bitmap curImage = new Bitmap(tileSet);
            for (int y = 0; y < tileSet.Height; y+=size)
            {
                for (int x = 0; x < tileSet.Width; x+=size)
                {
                    Bitmap newImage = new Bitmap(size, size);
                    for (int y2 = 0; y2 < size; y2++)
                    {
                        for (int x2 = 0; x2 < size; x2++)
                        {
                            newImage.SetPixel(x2, y2, curImage.GetPixel(x, y));
                        }
                    }
                    tileList.Add((Image)newImage);
                }
            }
        }
    }
}
