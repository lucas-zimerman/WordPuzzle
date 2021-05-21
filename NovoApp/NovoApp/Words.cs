using System;
using System.Collections.Generic;
using System.Text;

namespace NovoApp
{
    public class Words
    {
        public bool Found { get; set; }
        public string Name { get; set; }

        public Words(string name) => Name = name;

    }
}
