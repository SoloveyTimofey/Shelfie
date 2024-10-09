namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public class ChangeLogModel
    {
        public ChangeLogModel(DateTime changeTime, string changeMessage)
        {
            this.ChangeMessage = changeMessage;
            this.ChangeTime = changeTime;
        }
        public DateTime ChangeTime { get; set; }
        public string ChangeMessage { get; set; }
    }
}
