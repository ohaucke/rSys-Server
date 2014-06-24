using System.Collections.Generic;

namespace rSysServer
{
    // From: http://stackoverflow.com/a/5923604/1018144
    public class FixedSizedQueue<T> : Queue<T>
    {
        private readonly int maxQueueSize;
        private readonly object syncRoot = new object();

        public FixedSizedQueue(int maxQueueSize)
        {
            this.maxQueueSize = maxQueueSize;
        }

        public new void Enqueue(T item)
        {
            lock (syncRoot)
            {
                base.Enqueue(item);
                if (base.Count > this.maxQueueSize)
                {
                    base.Dequeue(); // Throw away
                }
            }
        }
    }
}
