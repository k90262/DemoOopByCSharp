public class ApplicationRunner 
{
    private Application itsApplication = null;

    public ApplicationRunner(Application app) 
    {
        itsApplication = app;
    }

    public void Run() 
    {
        itsApplication.Init();
        while (!itsApplication.Done()) 
            itsApplication.Idle();
        itsApplication.Cleanup();
    }

}