namespace JsonLibrary
{
    public class UpdatedEventArgs : EventArgs
    {
        public DateTime UpdateDateTime { get; }

        public UpdatedEventArgs(DateTime update)
        {
            UpdateDateTime = update;
        }
    }
}
