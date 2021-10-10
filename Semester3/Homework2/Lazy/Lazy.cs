using System;

namespace Lazy
{
    /// <summary>
    /// Lazy class
    /// </summary>
    public abstract class Lazy<T> : ILazy<T>
    {
        protected Func<T> supplier;
        protected T value;
        protected volatile bool isValueCreated; 

        public Lazy(Func<T> supplier)
            => this.supplier = supplier ?? throw new ArgumentNullException("Counting function can't be null");

        public abstract T Get();
    }
}
