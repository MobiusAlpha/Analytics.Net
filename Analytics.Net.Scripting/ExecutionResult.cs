namespace Analytics.Net.Scripting
{
    public class ExecutionResult
    {
        public int Code { get; set; }
        public int Subcode { get; set; }
        public string Message { get; set; }
        public ExecutionLog[] Log { get; set; }
    }
}