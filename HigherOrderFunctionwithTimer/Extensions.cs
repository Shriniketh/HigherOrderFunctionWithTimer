using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigherOrderFunctionwithTimer
{
    public static class Extensions
    {
        public static T WithRetry<T>(this Func<T> action)
        {
            var result = default(T);

            var retryCount = 0;

            var retry = false;

            do
            {
                try
                {
                    result = action();
                    retry = true;
                }

                catch (WebException ex)
                {
                    retryCount++;
                }
            } while (retryCount < 2 && !retry );

            return result;
        } 
    }
}
