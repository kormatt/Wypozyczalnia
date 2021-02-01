using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekcior {
    public static class Exrensions {
        public static ILog GetLog<T>(this Ilogger<T> logger) {
            return LoggerImpl<T>.Log;
        }
    }
}