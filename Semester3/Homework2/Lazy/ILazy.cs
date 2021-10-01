namespace Lazy
{
    /// <summary>
    /// Lazy interface
    /// </summary>
    public interface ILazy<out T>
    { 
        /// <summary>
        /// Lazy counting
        /// </summary>
        /// <returns>Result of the counting</returns>
        T Get();
    }
}
