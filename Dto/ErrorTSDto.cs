namespace Traduccion_php.Dto
{
    public class Debug
    {
        public int code { get; set; }
        public string incident_id_guid { get; set; }
        public string trace_id_guid { get; set; }
        public string debug { get; set; }
    }

    public class Error
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public Debug debug { get; set; }
    }

    public class ErrorTSDto
    {
        public Error error { get; set; }
    }
}
