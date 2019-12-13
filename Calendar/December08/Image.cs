using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace December08
{
    public struct Pixel
    {
        public int Value;
        public bool T;

        public Pixel(int Value, bool T)
        {
            this.Value = Value;
            this.T = T;
        }
    }

    public class Image
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public List<Layer> Layers { get; private set; }

        public Image(string Data, int Height, int Width)
        {
            var layerSize = Height * Width;
            Debug.Assert(Data.Length % layerSize == 0);
            Layers = new List<Layer>();


            for (int i = 0; i < Data.Length; i += layerSize)
            {
                Layers.Add(new Layer(Data.Substring(i, layerSize), Height, Width));
            }
            this.Height = Height;
            this.Width = Width;
        }

        public string GetImageOutput()
        {
            var visualData = new Pixel[Height * Width];
            for (int i = 0; i < visualData.Length; i++)
            {
                visualData[i].T = true;
            }

            foreach (var layer in Layers)
            {
                for (int i = 0; i < layer.PixelData.Length; i++)
                {
                    if (visualData[i].T)
                    {
                        visualData[i] = layer.PixelData[i];
                    }
                }
            }
            var sb = new StringBuilder();
            foreach (var pixel in visualData)
            {
                sb.Append(pixel.Value);
            }
            return sb.ToString();
        }

        public string Draw()
        {
            var output = GetImageOutput();
            var sb = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                sb.Append('\n');
                for (var j = 0; j < Width; j++)
                {
                    var x = output[i * Width + j];
                    sb.Append(char.GetNumericValue(x) == 1 ? '#' : ' ');
                }
            }
            return sb.ToString();
        }

        public Pixel GetPixel(int row, int column, int layer)
        {
            return Layers[layer].GetPixel(row, column);
        }

        public static Pixel DecodePixel(string PixelData)
        {
            return new Pixel(-1, true);
        }
        
    }

    public class Layer
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Pixel[] PixelData { get; private set; }
        public int[] RawData { get; private set; }
        public Layer(string Data, int Height, int Width)
        {
            var layerSize = Height * Width;
            Debug.Assert(Data.Length == layerSize);

            this.Height = Height;
            this.Width = Width;

            RawData = new int[layerSize];
            PixelData = new Pixel[layerSize];
            Func<char, int> CharToInt = x => { return (int)char.GetNumericValue(x); };

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var pixelValue = CharToInt(Data[i * Width + j]);
                    RawData[i * Width + j] = pixelValue;
                    switch (pixelValue)
                    {
                        case 0:
                        case 1:
                            PixelData[i * Width + j] = new Pixel(pixelValue, false);
                            break;
                        case 2:
                            PixelData[i * Width + j] = new Pixel(0, true);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public Pixel GetPixel(int row, int column)
        {
            return PixelData[row * Width + column];
        }
    }

}
