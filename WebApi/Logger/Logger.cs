using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApi.Logger
{
    public static class EventLogger
    {

        public static void LogError(string Err){

            Trace.Listeners.Add(new TextWriterTraceListener("TextWriterOutput.log", "myListener"));
            Trace.TraceInformation(Err);
         
            Trace.Flush();
        }

    }
}