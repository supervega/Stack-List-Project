using System;
using System.Collections.Generic;
using System.Text;

namespace barces
{
    public class List
    {
        public ListElement head;
        public ListElement tail;
        public ListElement n;
        public int count;
        bool confirmHead = true;

        public List()
        {
            head = new ListElement();
            tail = new ListElement();
            n = new ListElement();
            count = 0;
        }

        public void Append(element e)
        {
            if (head.St.count<5)
            {               
                head.St.Push(e);
                tail = head;                
            }
            else
            {
                if (head.St.count == 5 && confirmHead)
                {
                    count++;
                    confirmHead = false;
                }
                    if (n.St.count == 0)
                    {
                        tail.Next = n;
                        tail = n;
                    }
                    if (n.St.count == 5)
                    {
                        n = new ListElement();
                        tail.Next = n;
                        tail = n;
                        count++;
                    }                    
                    n.St.Push(e);             
            }           
        }

        public string Find(int Value)
        {
            ListElement Le = head;
            string Nop = "";
            element[] ECollector = new element[5];
            int counter = 0;
            for (int i = 0; i <= count; i++)
            {
                counter = Le.St.count;
                for (int j = 0; j < counter; j++)
                {
                    element e = Le.St.Top();
                    if (e != null)
                    {
                        ECollector[((counter - j) - 1)] = Le.St.Top();
                        if (e.value == Value)
                        {
                            Nop += Convert.ToString(i + " " + ((counter-j)-1) + ",");
                        }
                    }
                    Le.St.Pop();
                }
                for (int k = 0; k < counter; k++)
                {
                    if(ECollector[k]!=null)
                        Le.St.Push(ECollector[k]);
                }
                Le=Le.Next;
                counter = 0;
            }
            return Nop;
        }
    }
}
