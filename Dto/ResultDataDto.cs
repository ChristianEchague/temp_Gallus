
namespace Traduccion_php.Dto
{
    public class ResultDataDto<R, E>
    {
        public R? DataResult { get; set; }
        public E? DataError { get; set; }
    }
}
