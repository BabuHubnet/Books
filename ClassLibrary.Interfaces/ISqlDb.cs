namespace ClassLibrary.Interfaces
{
    public interface ISqlDb
    {
        public string ConnectionString { get; }
        public int Timeout { get; }
    }
}

