using System;

namespace Lazy
{
    /// <summary>
    /// Lazy class
    /// </summary>
    public abstract class Lazy<T> : ILazy<T>
    {
        protected volatile Func<T> supplier;
        protected T value;
        protected bool isValueCreated; 

        public Lazy(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            this.supplier = supplier;
        }

        public abstract T Get();
    }
}
