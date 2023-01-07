public class IntSortHandler : SortHandler
{
    private int[] array = null;

    public void SetArray(object array)
    {
        this.array = (int[]) array;
    }

    public int Length() 
    {
        return array.Length;
    }

    public bool OutOfOrder(int index)
    {
        return (array[index] > array[index+1]);
    }

    public void Swap(int index)
    {
        int temp = array[index];
        array[index] = array[index+1];
        array[index+1] = temp;
    }
}