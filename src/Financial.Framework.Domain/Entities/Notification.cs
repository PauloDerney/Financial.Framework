namespace Financial.Framework.Domain.Entities
{
    public struct Notification
    {
        public Notification(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}