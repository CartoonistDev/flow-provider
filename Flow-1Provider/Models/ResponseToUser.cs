using AutoMapper;

namespace Flow_1Provider.Models
{
    public class ResponseToUser<T>
    {
        public ResponseToUser(object obj, IMapper mapper, string msg, bool suc = true, int count = 0)
        {
            if (obj != null)
            {
                data = mapper.Map<T>(obj);
            }
            message = msg;
            success = suc;
            TotalCount = count;
        }

        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public int TotalCount { get; set; }
    }
}
