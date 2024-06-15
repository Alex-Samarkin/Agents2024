using ScottPlot.Colormaps;

namespace AgentsLibrary1
{
    public interface IUpdatable<T> where T : class
    {
        void Update();
        T DeepCopy();
        void CopyFrom(T copyObject);
    }
}