using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlight
{
    class tagModel
    {
        public tagModel(byte priority, string content)
        {
            Priority = priority;
            Content = content;
        }

        public byte Priority { get; set; }
        public string Content { get; set; }
    }
}
