public class QuickBubbleSorter 
{
    private int operations = 0;
    protected int length = 0;
    private SortHandler itsSortHandler;

    public QuickBubbleSorter(SortHandler handler) 
    {
        itsSortHandler = handler;
    }

    public int Sort(object array) 
    {
        itsSortHandler.SetArray(array);
        length = itsSortHandler.Length();
        operations = 0;
        if (length <= 1)
            return operations;
        
        bool thisPassInOrder = false;
        for (int nextToLast = length-2; 
             nextToLast >= 0 && !thisPassInOrder; 
             nextToLast--)
        {
            thisPassInOrder = true; //potentially.
            for (int index = 0; index <= nextToLast; index++)
            {
                if (itsSortHandler.OutOfOrder(index))
                {
                    itsSortHandler.Swap(index);
                    thisPassInOrder = false;
                }
                operations++;
            }
        }

        return operations;
    }
}