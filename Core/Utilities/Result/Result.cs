namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        // this:(success) demek -> Success = success demek ile aynidir. Tek parametre gonderirsek usteki ctor, iki parametre gonderirsek hem usteki hem alttaki ctor calisir.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Success = success;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
