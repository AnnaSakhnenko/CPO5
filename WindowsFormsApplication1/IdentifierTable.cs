using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class IdentifierTable
    {
        public string item;
        public int link;
    }

    public class IdentifierTableList
    {
        public IdentifierTableList() { }
        public List<IdentifierTable> list;
    }
}
