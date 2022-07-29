namespace healthTracker.Data
{
    public abstract class IRepo
    {
        public readonly int DefaultLimit = 10;
        public readonly int DefaultOffset = 0;
        public readonly string DefaultDateSort = "Date";
    }
}
