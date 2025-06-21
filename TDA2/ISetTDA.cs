namespace TDA2;

public interface ISet<T>
{
    void Add(T element);
    bool Remove(T element);
    bool Contains(T element);
    bool IsEmpty();
    int Count();
    T GetAny();
    void Clear();
    void SetComparer(IComparer<T> comparer);
    List<T> ToList();
        
    ISet<T> Union(ISet<T> other);
    ISet<T> Intersection(ISet<T> other);
    ISet<T> Difference(ISet<T> other);
    bool IsSubsetOf(ISet<T> other);
}