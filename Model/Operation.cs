using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileTeijkhrebKursach.Model
{
    public class Operation
    {
        public string containtment;
        public int position;
        public bool isCut;
        public bool isDelete;
        public Operation(string containts, int pos, bool isCut, bool isDelete)
        {
            containtment = containts;
            position = pos;
            this.isCut = isCut;
            this.isDelete = isDelete;
        }
    }
}
