namespace Shelfie.Domain.ValueObjects
{
    public class ChangeLog
    {
        public ChangeLog(DateTime changeTime, string changeMessage)
        {
            this.ChangeMessage = changeMessage;
            this.ChangeTime = changeTime;
        }
        public DateTime ChangeTime { get; set; }
        public string ChangeMessage { get; set; }
    }
}
