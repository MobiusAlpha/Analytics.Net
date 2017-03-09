namespace Analytics.Net.Scripting
{
    public interface ICompiler
    {
        byte[] Compile(ExecutionContext context);
    }
}