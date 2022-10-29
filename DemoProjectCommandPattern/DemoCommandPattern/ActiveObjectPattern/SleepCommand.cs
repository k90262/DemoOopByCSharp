using System;
namespace DemoCommandPattern.ActiveObjectPattern
{
    public class SleepCommand : Command
    {
        private Command wakeupCommand = null;
        private ActiveObjectEngine engine = null;
        private long sleepTime = 0;
        private DateTime startTime;
        private bool started = false;

        public SleepCommand(long milliseconds, ActiveObjectEngine e, Command wakeupCommand)
        {
            sleepTime = milliseconds;
            engine = e;
            this.wakeupCommand = wakeupCommand;
        }

        public void Execute()
        {
            DateTime currentTime = DateTime.Now;
            if (!started)
            {
                started = true;
                startTime = currentTime;
                engine.AddCommand(this);
            }
            else
            {
                TimeSpan elapsedTime = currentTime - startTime;
                if (elapsedTime.TotalMilliseconds < sleepTime)
                {
                    engine.AddCommand(this);
                }
                else
                {
                    engine.AddCommand(wakeupCommand);
                }
            }
        }
    }
}

