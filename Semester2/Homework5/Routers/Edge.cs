namespace Routers
{
    /// <summary>
    /// Edge consists of start, finish vertex and weight.
    /// </summary>
    public class Edge
    {
        public Edge(int start, int finish, int weight)
        {
            Weight = weight;
            Start = start;
            Finish = finish;
        }

        public int Weight { get; private set; }
        public int Start { get; private set; }
        public int Finish { get; private set; }
    }
}
