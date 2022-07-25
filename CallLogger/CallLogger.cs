using System.Text;

namespace Task_5th_ATE
{
    public class CallLogger
    {
        private readonly string _logTemplate = "Date:{0}, Number:{1}, CallDuration:{2} minutes, Cost:{3} ";
        
        public void CallLogging(LogEventArgs logEventArgs)
        {
            _ = logEventArgs ?? throw new ArgumentNullException("LogEventArgs was null");

            var log = (String.Format(
                _logTemplate, logEventArgs.CallDetails.Date,
                logEventArgs.CallDetails.Number,
                logEventArgs.CallDetails.CallDuration,
                logEventArgs.CallDetails.Cost));

            using var sw = new StreamWriter($"{logEventArgs.CallingNumber}.txt", true, Encoding.UTF8) { };

            sw.WriteLine(log);
        }
    }
}
