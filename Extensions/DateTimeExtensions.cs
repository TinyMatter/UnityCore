
using System;

namespace TinyMatter.Core.Extensions {
    
    public static class DateTimeExtensions {
        
        public static long UTCSeconds(this System.DateTime dateTime) {
            return dateTime.Ticks / TimeSpan.TicksPerSecond;
        }

        public static long UTCNowAddSeconds(int addSeconds = 0) {
            var finishTime = System.DateTime.UtcNow.AddSeconds(addSeconds);
            return finishTime.UTCSeconds();
        }
        
    }
    
}