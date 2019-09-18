using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZHService
{
    /// <summary>
    /// 定时执行任务
    /// </summary>
    public class TimerRun
    {
        /// <summary>
        /// 定时器
        /// </summary>
        private Timer timer;


        public DateTime NextTime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        public TimerRun(string time)
        {
            var now = DateTime.Now;
            var nextTimestr = now.ToString("yyyy-MM-dd ") + time;
            this.NextTime = DateTime.Parse(nextTimestr);
            var timeSpan = this.NextTime - now;
            if (timeSpan.Milliseconds < 0)
            {
                timeSpan = now.AddMinutes(1) - now;
            }
            Console.WriteLine("开始执行时间" + this.NextTime);
            this.timer = new Timer(TimerCallBack, null, timeSpan, Timeout.InfiniteTimeSpan);
        }

        /// <summary>
        /// 定时器回调
        /// </summary>
        /// <paramref name="state"></paramref>
        private void TimerCallBack(object state)
        {
            Console.WriteLine("自动执行一次:" + DateTime.Now);
            AutoTask.RunAll().Wait();
            this.NextTime = this.NextTime.AddDays(1);
            var timeSpan = this.NextTime - DateTime.Now;
            if (timeSpan.Milliseconds < 0)
            {
                var now = DateTime.Now;
                timeSpan = now.AddMinutes(1) - now;
            }
            this.timer.Change(timeSpan, Timeout.InfiniteTimeSpan);
            Console.WriteLine("下次执行时间:" + this.NextTime);
        }
    }
}
