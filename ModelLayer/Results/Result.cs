using System.Collections.Generic;

namespace ModelLayer
{
    public class Result<T> where T : class
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Exceptions { get; set; }
        public T Data { get; set; }
      //  public List<T> DataList { get; set; }
    }
}
