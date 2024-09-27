using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class ChangeLog
    {
        public ChangeLog(DateTime changeTime, string changeMessage)
        {
            this.ChangeMessage = changeMessage;
            this.ChangeTime = changeTime;
        }
        public DateTime ChangeTime { get; }
        public string ChangeMessage { get; }
    }
}
