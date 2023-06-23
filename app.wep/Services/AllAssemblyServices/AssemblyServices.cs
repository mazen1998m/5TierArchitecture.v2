using App.web.Services.JsonServices;

namespace App.web.Services.AllAssemblyServices;

public static class AssemblyServices
{
    public static System.Reflection.Assembly GetAssembly(Type type)
        => System.Reflection.Assembly.GetAssembly(type)!;

    public static System.Reflection.Assembly GetAssembly(string assemblyName)
        => System.Reflection.Assembly.Load(assemblyName);

    public static List<System.Reflection.Assembly> GetAllAssembly()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory
            [..AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal)];
        string filePath = Path.Combine(baseDirectory, "AssemblyMeta.json");

        List<Assemble> allAssembly = ReadJson.Deserialize<List<Assemble>>(filePath);

        return allAssembly.Select(assembly => GetAssembly(assembly.Name!)).ToList();

    }

    public static List<string> GetAssemblyName()
     => GetAllAssembly().Select(assembly => assembly.GetName().Name!).ToList();

    public static string GetAssemblyName(Type type)
        => GetAssembly(type).GetName().Name!;

    public static int GetAssemblyNameLength(string assemblyName)
        => assemblyName.Split(".").Length;

    public static int GetAssemblyNameLength(Type assemblyType)
        => GetAssemblyName(assemblyType).Split(".").Length;

    public static IEnumerable<Type> GeTypeByName(System.Reflection.Assembly assembly, string typeName)
        => assembly.GetTypes().Where(v => v.FullName!.Contains(typeName));

    public static IEnumerable<Type> GeTypeByName(string typeName)
    {
        List<Type> allTypes = new();
        List<System.Reflection.Assembly> allAssembly = GetAllAssembly();
        foreach (
            IEnumerable<Type>? types in allAssembly
                     .Select(assembly => assembly
                         .GetTypes()
                         .Where(v => v.FullName!.Contains(typeName))))
        {
            allTypes.AddRange(types);
        }

        return allTypes;
    }

    public static IEnumerable<Type> GetTypes()
    {
        List<Type> allTypes = new();
        List<System.Reflection.Assembly> allAssembly = GetAllAssembly();
        foreach (Type[]? types in allAssembly.Select(assembly => assembly.GetTypes()))
        {
            allTypes.AddRange(types);
        }

        return allTypes;
    }

    public static Type GetType(string typeName)
    {
        Type? type = null;
        foreach (Type? assemblyType
                 in GetAllAssembly().Select(assembly => assembly.GetType(typeName))
                                    .Where(assemblyType => assemblyType != null))
        {
            type = assemblyType;
        }

        return type!;
    }

    public static List<Type> GetConstructors()
        => (from type in GetTypes().Where(t => t.FullName!.StartsWith(GetAssemblyName(t)))
            from constructor in type.GetConstructors()
            from parameter in constructor.GetParameters()
            select parameter.ParameterType).ToList();



}