What's that
===========
Syntactic sugar improvements for the RunSharp library.
RunSharp is a nice user-friendly wrapper for Reflection.Emit API
developed by Stefan Simek and Matthew Wilson.

Original RunSharp code:

```csharp
MyTypeGen.Public.Static.Method(typeof(void), "Main")
   .Parameter(typeof(string[]), "args")
   .Attribute(typeof(DescriptionAttribute), "Entry Point");
```

My version:

```csharp
MyTypeGen.Public.Static.Void("Main")
   .Parameter<string[]>("args")
   .Attribute<DescriptionAttribute>("Entry Point");
```

Overview
========
RunSharp is a layer above the standard .NET Reflection.Emit API, allowing to 
generate/compile dynamic code at runtime very quickly and efficiently 
(unlike using CodeDOM and invoking the C# compiler). To the best of my
knowledge, there is no such library available at the moment.

Example
=======
A simple hello world example in C#

```csharp
public class Test
{
   public static void Main(string[] args)
   {
      Console.WriteLine("Hello " + args[0]);
   }
}
```

can be dynamically generated using RunSharp as follows:

```csharp
AssemblyGen ag = new AssemblyGen("hello.exe");
TypeGen Test = ag.Public.Class("Test");
{
   CodeGen g = Test.Public.Static.Method(typeof(void), "Main", typeof(string[]));
   {
      Operand args = g.Param(0, "args");
      g.Invoke(typeof(Console), "WriteLine", "Hello " + args[0] + "!");
   }
}
ag.Save();
```

The above code should generate roughly the same assembly as if the first 
example was compiled using csc.

Tutorial
========
[RunSharp - Reflection.Emit Has Never Been Easier](http://www.codeproject.com/Articles/20921/RunSharp-Reflection-Emit-Has-Never-Been-Easier)
