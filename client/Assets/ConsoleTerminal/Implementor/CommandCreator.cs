using System;
using System.Reflection;
using RedSaw.CommandLineInterface;

namespace ConsoleTerminal.Implementor
{
    public class CommandCreator:
        ICommandCreator
    {
        public Type[] GetAssemblyTypes() => Assembly.GetExecutingAssembly().GetTypes();
    }
}