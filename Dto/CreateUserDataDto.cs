
namespace Traduccion_php.Dto
{
    public class CreateUserDataDto
    {
        public string name { get; set; } = string.Empty;
        public string display_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string accont_type { get; set; } = "OIDC_USER";
        public bool notify_on_share { get; set; } = false;
        public List<string> org_identifiers { get; set; } = [];
        public bool trigger_welcome_email { get; set; } = false;        
    }
}
