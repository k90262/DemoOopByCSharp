public interface Application
{
    void Cleanup();
    bool Done();
    void Idle();
    void Init();
}