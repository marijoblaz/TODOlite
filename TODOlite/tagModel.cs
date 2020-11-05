using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlite
{
    class tagModel
    {
        public tagModel(int priority, string content)
        {
            Priority = priority;
            Content = content;
        }

        public int Priority { get; set; }
        public string Content { get; set; }
    }
}
