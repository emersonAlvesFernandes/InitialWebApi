namespace InitialWebApi.Model.Models
{
    public class PipelineLogData
    {
        public PipelineLogData(RequestLog requestLog, ResponseLog responseLog)
        {
            RequestLog = requestLog;
            ResponseLog = responseLog;
        }

        public string Code { get; set; }
        public RequestLog RequestLog { get; set; }
        public ResponseLog ResponseLog { get; set; }
    }


    public class RequestLog
    {
        public RequestLog(string scheme, string host, string path, string queryString, object body)
        {
            Scheme = scheme;
            Host = host;
            Path = path;
            QueryString = queryString;
            Body = body;
        }

        public string Scheme { get; private set; }
        public string Host { get; private set; }
        public string Path { get; private set; }
        public string QueryString { get; private set; }
        public object Body { get; private set; }
    }

    public class ResponseLog
    {
        public ResponseLog(int statusCode, object body)
        {
            StatusCode = statusCode;
            Body = body;
        }

        public int StatusCode { get; private set; }
        public object Body { get; private set; }
    }
}
