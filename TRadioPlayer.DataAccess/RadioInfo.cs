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

namespace TRadioPlayer.DataAccess
{
    public class RadioInfo
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public string StreamUrl { get; set; }
        public string StreamUrl2 { get; set; }
        public string StreamUrl3 { get; set; }
        public string HomePage { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; }
        public bool Faved { get; set; }

        public RadioInfo()
        {
            Active = true;
            Faved = false;
        }
    }
}
