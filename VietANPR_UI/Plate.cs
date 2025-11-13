using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace VietANPR_UI
{
    class Plate
    {
        public int index = 0;
        string imagePath = "";
        string text = "";
        string alphanumeric = "";

        public Plate(string _imagePath, string _text, string _alphanumeric)
        {
            imagePath = _imagePath;
            text = _text;
            alphanumeric = _alphanumeric;
        }

        public string[] ToArray(bool fullPath = true)
        {
            string[] arr = new string[4];
            arr[0] = index.ToString();
            arr[1] = fullPath ? imagePath : Path.GetFileName(imagePath);
            arr[2] = text;
            arr[3] = alphanumeric;
            return arr;
        }
    }
}

