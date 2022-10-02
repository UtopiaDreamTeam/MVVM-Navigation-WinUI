namespace MvvmNavigation
{
    public class HistoryStack<T>
    {
        private readonly LinkedList<T> items = new LinkedList<T>();
        public List<T> Items => items.ToList();
        public int Capacity { get; }
        public HistoryStack(int capacity)
        {
            Capacity = capacity;
        }

        public void Push(T item)
        {
            if (items.Count == Capacity)
            {
                items.RemoveFirst();
                items.AddLast(item);
            }
            else
            {
                items.AddLast(new LinkedListNode<T>(item));
            }
        }

        public bool TryPop(out T value)
        {
            value = default;
            if (items.Count == 0)
            {
                return false;
            }
            var ls = items.Last;
            items.RemoveLast();
            if (ls == null)
                return false;
            value = ls.Value;
            return true;
        }
    }
}
