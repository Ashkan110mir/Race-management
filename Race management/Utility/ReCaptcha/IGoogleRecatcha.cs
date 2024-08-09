namespace Race_management.Utility.ReCaptcha
{
    public interface IGoogleRecatcha
    {
        public Task<bool> ISRecapthaTrue();
    }
}
