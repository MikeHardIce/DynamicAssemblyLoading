# DynamicAssemblyLoading
Figuring out how to load assemblies during runtime in dotnet core 3.

There are 2 plugins in the plugin folder that both implement ITask and ITaskInformation from a shared library. 
The goal is to get both assemblies dynamically loaded into the DynamicAssemblyLoading Assembly.
