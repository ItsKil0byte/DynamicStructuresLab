namespace DynamicStructuresLab;

public interface IQueue
{
    void Enqueue(string item);
    string Dequeue();
    string Peek();
    bool IsEmpty();
    void Print();
}
