namespace Race_management.Utility.Email_Sender
{
    public interface IEmailSender
    {
        public Task Send_Email(string Toemail, string text, string subject, bool ismassagehtml = false);
    }
}
