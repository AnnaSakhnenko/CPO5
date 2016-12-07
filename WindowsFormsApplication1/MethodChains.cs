using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MethodChains
    {
        int comparisons;
        public int Сomparisons
        {
            get { return comparisons; }
        }

        string elapsedTime;
        public string ElapsedTime
        {
            get { return elapsedTime; }
        }

        Hash h = new Hash();

        int freePtr = 0;

        public void Entry(string identifier, List<IdentifierTable> list, int[] hashTable)
        {            
            int address = h.HF(identifier);

            if(hashTable[address] == -1)
            {
                IdentifierTable IT = new IdentifierTable();
                hashTable[address] = freePtr;
                IT.item = identifier;                
                list.Add(IT);
                freePtr++;
            }
            else
            {
                bool link = false;
                int addressLink = hashTable[address];

                while (link != true)
                {
                    if (list[addressLink].item != identifier)
                    {
                        if (list[addressLink].link == 0)
                        {
                            list[addressLink].link = freePtr;
                            IdentifierTable IT = new IdentifierTable();
                            IT.item = identifier;
                            list.Add(IT);
                            freePtr++;
                            link = true;
                        }
                        else
                        {
                            addressLink = list[addressLink].link;
                        }
                    }
                    else
                    {
                        link = true;
                    }
                }
            }
        }

        public string Search(string identifier, List<IdentifierTable> list, int[] hashTable)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int address = h.HF(identifier);
            string mes = "";
            comparisons = 0;

            if (hashTable[address] == -1)
            {
                 mes = "Элемент не найден";
            }
            else
            {
                bool link = false;
                int addressLink = hashTable[address];

                while (link != true)
                {
                    if (list[addressLink].item != identifier)
                    {
                        if (list[addressLink].link == 0)
                        {
                            mes = "Элемент не найден";
                            link = true; 
                            comparisons++;
                        }
                        else
                        {
                            addressLink = list[addressLink].link;
                            comparisons++;
                        }
                    }
                    else
                    {
                        mes = "Элемент найден";
                        link = true;
                        comparisons++;
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            elapsedTime = String.Format(ts.TotalMilliseconds.ToString());
            return mes;
        }
    }
}
