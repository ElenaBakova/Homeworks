namespace MD5Algorithm
{
    public interface ICheckSumCounting
    {
        /// <summary>
        /// Check-sum counting method
        /// </summary>
        /// <param name="path">File or directory path</param>
        /// <returns>Check-sum</returns>
        public byte[] CountCheckSum(string path);
    }
}
