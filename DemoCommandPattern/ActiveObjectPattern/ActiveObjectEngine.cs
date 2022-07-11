using System;
using System.Collections;

namespace DemoCommandPattern.ActiveObjectPattern
{
    public class ActiveObjectEngine
    {
        ArrayList itsCommands = new ArrayList();

        public void AddCommand(Command c)
        {
            itsCommands.Add(c);
        }

        public void Run()
        {
            while (itsCommands.Count > 0
                && itsCommands[0] != null)
            {
                Command c = (Command)itsCommands[0];
                itsCommands.RemoveAt(0);
                if (c != null)
                    c.Execute();
            }
        }
    }
}

