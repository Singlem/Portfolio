using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSeller
{
    class Books
    {
        public string Title;
        public string Author;
        public string ISBN;
        public string Year;
        public int Pages;
        public decimal Price;
        public int In_Stock;
        public int Hired_Out;
        public byte[] pic;

        public override string ToString()
        {
            return Title;
        }
    }
}
