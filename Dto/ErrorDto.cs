
namespace Traduccion_php.Dto
{
    public class ErrorDto
    {
        public string ErrorMessage { get; set; }
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public bool HasError { get; set; }
        public bool GoToError { get; set; }
    }
}
