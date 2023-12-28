namespace ClassLibrary.Interface
{
    public interface ISqlDb
    {
        public string ConnectionString { get; }
        public int Timeout { get; }
    }
}
