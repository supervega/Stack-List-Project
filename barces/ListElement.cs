using System;
using System.Collections.Generic;
using System.Text;

namespace barces
{
    public class ListElement
    {
        public Stack St;
        public ListElement Next;

        public ListElement()
        {
            St = new Stack();
        }
    }
}
