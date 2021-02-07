namespace Financial.Framework.Infra.Service.AppModels
{
    public class QueueSettings
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public int Timeout { get; set; }

        public string Exchange { get; set; }
    }
}
