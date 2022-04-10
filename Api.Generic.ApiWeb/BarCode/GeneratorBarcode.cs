using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Generic.ApiWeb.BarCode
{
    public class GeneratorBarcode
    {
        public Image GenerateCodebar(string Code, int Width, int Height, bool IncludeLabel)
        {
            BarcodeLib.Barcode _Barcode = new BarcodeLib.Barcode
            {
                IncludeLabel = IncludeLabel
            };
            return _Barcode.Encode(BarcodeLib.TYPE.CODE128, Code, Color.Black, Color.White, Width, Height);
        }
        public Image GenerateCodebar(string Code, bool IncludeLabel)
        {
            BarcodeLib.Barcode _Barcode = new BarcodeLib.Barcode
            {
                IncludeLabel = IncludeLabel
            };
            return _Barcode.Encode(BarcodeLib.TYPE.CODE128, Code, Color.Black, Color.White);
        }
    }
}
