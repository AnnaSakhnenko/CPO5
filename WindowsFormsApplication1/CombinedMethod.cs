using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class CombinedMethod
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

        int freeAddress = 0;

        public void Entry(string identifier, List<string>[,] addressSpace, int[] hashTable)
        {
            int address = h.HF(identifier);

            if (hashTable[address] == -1)
            {
                List<string> list = new List<string>();
                list.Add(identifier);
                addressSpace[freeAddress, 0] = list;
                hashTable[address] = freeAddress;
                freeAddress++;
            }
            else
            {
                int addressIndex = 0;
                bool link = false;

                while (link != true)
                {
                    if (addressSpace[hashTable[address], addressIndex] == null) 
                    {
                        List<string> list = new List<string>();
                        list.Add(identifier);
                        addressSpace[hashTable[address], addressIndex] = list;
                        link = true;
                    }
                    else
                    {
                        if (addressSpace[hashTable[address], addressIndex][0] != identifier)
                        {
                            addressIndex++;
                        }
                        else
                        {
                            link = true;
                        }
                    }                    
                }
            }
        }

        public string Search(string identifier, List<string>[,] addressSpace, int[] hashTable)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            comparisons = 0;
            int address = h.HF(identifier);
            string mes = "";

            if (hashTable[address] == -1)
            {
                mes = "Элемент не найден";
            }
            else
            {
                int addressIndex = 0;
                bool link = false;

                while (link != true)
                {
                    if (addressSpace[hashTable[address], addressIndex] == null)
                    {
                        mes = "Элемент не найден";
                        comparisons++;
                        link = true;
                    }
                    else
                    {
                        if (addressSpace[hashTable[address], addressIndex][0] != identifier)
                        {
                            addressIndex++;
                            comparisons++;
                        }
                        else
                        {
                            mes = "Элемент найден";
                            comparisons++;
                            link = true;
                        }
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
