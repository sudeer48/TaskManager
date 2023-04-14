using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Helper.Helper
{
    public class ApplicationSettings
    {
        public static ApplicationSettings Current { get; set; }

        public ApplicationSettings()
        {
            Current = this;
        }
        public string Key { get; set; }
    }
}
