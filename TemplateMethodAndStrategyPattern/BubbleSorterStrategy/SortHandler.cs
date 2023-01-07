public interface SortHandler {
    void SetArray(object array);
    int Length();
    bool OutOfOrder(int index);
    void Swap(int index);
}