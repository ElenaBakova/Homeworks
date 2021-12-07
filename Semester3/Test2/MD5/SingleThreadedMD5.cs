using System.Text;

namespace MD5Algorithm
{
    public class SingleThreadedMD5
    {
        public byte[] CountCheckSum(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new ArgumentException();
            }

            using var md5 = MD5.Create();
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path).OrderBy(name => name);
                var sumString = Path.GetDirectoryName(path);
                foreach (var file in files)
                {
                    sumString += CountCheckSum(file).ToString();
                }
                return md5.ComputeHash(Encoding.UTF8.GetBytes(sumString));
            }
            else
            {
                using var stream = File.OpenRead(path);
                return md5.ComputeHash(stream);
            }
        }
    }
}
