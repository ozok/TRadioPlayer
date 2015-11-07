/*
The MIT License (MIT)

Copyright (c) 2015 ozok26@gmail.com - Okan Özcan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRadioPlayer.Settings
{
    public class EqSettings
    {
        public int EqVal1 { get; set; }
        public int EqVal2 { get; set; }
        public int EqVal3 { get; set; }
        public int EqVal4 { get; set; }
        public int EqVal5 { get; set; }
        public int EqVal6 { get; set; }
        public int EqVal7 { get; set; }
        public int EqVal8 { get; set; }
        public int EqVal9 { get; set; }
        public int EqVal10 { get; set; }
        public bool Enabled { get; set; }
        public int PresetIndex { get; set; }

        public EqSettings()
        {
            EqVal1 = 0;
            EqVal2 = 0;
            EqVal3 = 0;
            EqVal4 = 0;
            EqVal5 = 0;
            EqVal6 = 0;
            EqVal7 = 0;
            EqVal8 = 0;
            EqVal9 = 0;
            EqVal10 = 0;
            Enabled = false;
        }
    }
}
