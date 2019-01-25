using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpConfigManager.Model
{
    public enum FrpConfigType
    {
        Common = 1,
        Appliction = 2
    }

    public enum LogLevel
    {
        trace,
        debug,
        info,
        warn,
        error
    }
}
