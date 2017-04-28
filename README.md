# Centennial Startup Helper

This program was made as an example to [@Jaex](https://github.com/Jaex) for how he could handle the startup task in his Windows Store port of ShareX. ShareX runs on .NET 4 but .NET 4.6 is required to import and use UWP functions. As such, he had to made an helper for it to work.

## Usage

To use, simply invoke it like you would with any process and watch the return value.

Option | Explanation
------------ | -------
/status [TaskIndex]  | Will return the current status of the selected task.
/enable [TaskIndex]  | Will enable the selected task and return the new status.
/disable [TaskIndex] | Will disable the selected task and return the new status.

TaskIndex is a zero-indexed value selecting the task you want to view/edit. They are ordered in the same order you declared them in your AppxManifest. It defaults to 0 if you ignore the parameter (which should be your one and only startup task anyways).  
If the tool is launched with no command line arguments, it behaves same as if running `/status 0`.

Return Value | Explanation
------------ | -------
-1 | An exception was thrown. (Most common mistake is that the process does not have a package identity)
0  | Task is enabled.
1  | Task is disabled.
2  | Task has been disabled by the user in the Task Manager's startup tab.

## Redistribution and licensing

Since this is unlicensed, you are free to use or redistribute this as you want. Crediting me is appreciated, but not required.