namespace DataAccessLayer.Models
{
    public class EmailEntity
    {
        public string ReceiverEmail { get; set; }
        public Guid UserUID { get; set; }
        public string Subject { get; set; }
        public string EmailContent { get; set; }
    }
}
