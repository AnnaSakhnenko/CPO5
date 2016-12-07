using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Hash
    {
        public int HF(string key)
        {
            int hashf = 0;

            if (key.Length == 1)
            {
                hashf = Convert.ToChar(key[0]);
            }
            else
            {
                hashf = Convert.ToChar(key[0] + key[key.Length - 1]);
            }

            return hashf % 101;
        }
    }
}
