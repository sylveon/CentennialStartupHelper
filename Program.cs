using System;
using Windows.ApplicationModel;

namespace CentennialStartupHelper
{
    internal static class Program
    {
        private static int Main(string[] CommandLine)
        {
            try
            {
                string Argument = "/status";
                if (CommandLine.Length >= 1)
                {
                    Argument = CommandLine[0];
                }

                int startupTaskIndex = 0;
                if (CommandLine.Length >= 2)
                {
                    startupTaskIndex = int.Parse(CommandLine[1]);
                }

                var task = StartupTask.GetForCurrentPackageAsync().AsTask().Result[startupTaskIndex];

                switch (Argument)
                {
                    case "/enable":
                        return task.RequestEnableAsync().AsTask().Result.ToInt();

                    case "/disable":
                        task.Disable();
                        return task.State.ToInt();

                    case "/status":
                        return task.State.ToInt();

                    default: throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static int ToInt(this StartupTaskState state)
        {
            switch (state)
            {
                case StartupTaskState.Enabled:
                    return 0;

                case StartupTaskState.Disabled:
                    return 1;

                case StartupTaskState.DisabledByUser:
                    return 2;

                default: throw new NotImplementedException();
            }
        }
    }
}