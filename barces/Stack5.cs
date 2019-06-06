using System;
using System.Collections.Generic;
using System.Text;

namespace barces
{
    public class Stack5
    {
        public element head;
        public int count;

        public Stack5()
        {
            head = null;
            count = 0;
        }
        public void Push(element e)
        {
            e.Next = head;
            head = e;
            count++;
        }

        public element Pop()
        {
            element e;
            if (count == 0)
            {
                return null;
            }
            else
            {
                count--;
                e = head;
                head = head.Next;
                return e;
            }
        }

        public element Top()
        {
            if (count == 0)
                return null;
            else
                return head;
        }

        public int Count()
        {
            return count;
        }

        public bool Is_Empty()        
        {
            if (count == 0)
                return true;
            else
                return false;
        }
        

    }
}
