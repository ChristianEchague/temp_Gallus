using Newtonsoft.Json;

namespace Traduccion_php.Dto
{
    public class CurrentOrg
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ExtendedProperties
    {
        public string displayNameLastUpdatedBy { get; set; }
    }

    public class Org
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class OrgPrivileges
    {
        [JsonProperty("1977935901")]
        public List<string> _1977935901 { get; set; }
    }

    public class CreateUserResposeDataDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public string visibility { get; set; }
        public string author_id { get; set; }
        public bool can_change_password { get; set; }
        public bool complete_detail { get; set; }
        public long creation_time_in_millis { get; set; }
        public CurrentOrg current_org { get; set; }
        public bool deleted { get; set; }
        public bool deprecated { get; set; }
        public string account_type { get; set; }
        public string account_status { get; set; }
        public string email { get; set; }
        public int expiration_time_in_millis { get; set; }
        public bool external { get; set; }
        public List<object> favorite_metadata { get; set; }
        public int first_login_time_in_millis { get; set; }
        public int group_mask { get; set; }
        public bool hidden { get; set; }
        public object home_liveboard { get; set; }
        public List<object> incomplete_details { get; set; }
        public bool is_first_login { get; set; }
        public long modification_time_in_millis { get; set; }
        public string modifier_id { get; set; }
        public bool notify_on_share { get; set; }
        public bool onboarding_experience_completed { get; set; }
        public List<Org> orgs { get; set; }
        public string owner_id { get; set; }
        public string parent_type { get; set; }
        public List<string> privileges { get; set; }
        public bool show_onboarding_experience { get; set; }
        public bool super_user { get; set; }
        public bool system_user { get; set; }
        public List<object> tags { get; set; }
        public string tenant_id { get; set; }
        public List<UserGroup> user_groups { get; set; }
        public List<UserInheritedGroup> user_inherited_groups { get; set; }
        public bool welcome_email_sent { get; set; }
        public OrgPrivileges org_privileges { get; set; }
        public string preferred_locale { get; set; }
        public ExtendedProperties extended_properties { get; set; }
        public object extended_preferences { get; set; }
        public object user_parameters { get; set; }
        public object access_control_properties { get; set; }
        public object variable_values { get; set; }
    }

    public class UserGroup
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class UserInheritedGroup
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
