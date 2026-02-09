using Newtonsoft.Json;
using RestSharp;
using System.Runtime.InteropServices;
using System.Text.Json;
using Traduccion_php.Dto;

namespace Traduccion_php.Services
{
    public static class ThoughtspotClient
    {
        public static async Task<ResultDataDto<string, bool>> GetThoughtspotToken(TokenDataDto data)
        {
            var ret = new ResultDataDto<string, bool>();
            var url = "https://gallus.thoughtspot.cloud";
            var method = "api/rest/2.0/auth/token/full";
            var options = new RestClientOptions(url)
            {
                Timeout = TimeSpan.FromMilliseconds(-1),
            };
            var client = new RestClient(options);
            try
            {
                var request = new RestRequest(method, Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(data);
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ret.DataResult = "Error: " + response.StatusCode;
                    ret.DataError = true;
                    return ret;
                }
                var doc = JsonDocument.Parse(response.Content);
                var token = doc.RootElement.GetProperty("token").GetString();
                ret.DataResult = token;
                ret.DataError = false;
                return ret;
            }
            catch (Exception ex)
            {
                ret.DataResult = ex.Message;
                ret.DataError = false;
            }
            finally
            {
                client.Dispose();
            }
            return ret;
        }

        public static Dictionary<string, List<string>> GetTargetOrgIdsByCognitoGroup(IEnumerable<string> cognitoGroups)
        {
            var results = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var group in cognitoGroups)
            {
                if (string.IsNullOrWhiteSpace(group))
                {
                    continue;
                }

                var key = group.ToLowerInvariant();
                if (CognitoGroupOrgIdMap.TryGetValue(key, out var orgIds))
                {
                    results[key] = new List<string>(orgIds);
                }
            }

            return results;
        }

        public static async Task<ResultDataDto<bool, ErrorDto>> CreateNewUser(CreateUserDataDto data, string token)
        {
            var ret = new ResultDataDto<bool, ErrorDto>();
            var url = "https://gallus.thoughtspot.cloud";
            var method = "api/rest/2.0/users/create";
            var options = new RestClientOptions(url)
            {
                Timeout = TimeSpan.FromMilliseconds(-1),
            };
            var client = new RestClient(options);
            try
            {
                var request = new RestRequest(method, Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {token}");
                var body = JsonConvert.SerializeObject(data);
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var obj = JsonConvert.DeserializeObject<CreateUserResposeDataDto>(response.Content);
                }
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ret.DataError = new ErrorDto { HasError = true, ErrorMessage = $"Error: {response.StatusCode} - Detail: {response.Content}" };
                    return ret;
                }
                ret.DataResult = true;
                ret.DataError = new ErrorDto { HasError = false };
            }
            catch (Exception ex)
            {
                ret.DataError = new ErrorDto { HasError = true, ErrorMessage = $"Error: {ex.Message}" };
            }
            finally
            {
                client.Dispose();
            }
            return ret;
        }

        private static readonly Dictionary<string, List<string>> CognitoGroupOrgIdMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["better"] = ["1026167531"],
            ["pmg"] = ["93716433"],
            ["grate"] = ["818396742"],
            ["celink"] = ["1865786808"],
            ["chm"] = ["74610152"],
            ["dinercap"] = ["807229780"],
            ["demo"] = ["1977935901"],
            ["reliant"] = ["1459934658"],
            ["revolution"] = ["1094129358"],
            ["radius"] = ["1622018741"],
            ["kindlending"] = ["1270257552"],
            ["loanstore"] = ["1416332342"],
            ["demoanalytics"] = ["1977935901"],
            ["apex"] = ["1119088413"],
            ["northern"] = ["1905265078"],
            ["advantage"] = ["1476805275"],
            ["prmg"] = ["428892831"],
            ["prmguat"] = ["581621867"],
            ["flexpoint"] = ["1694387707"],
            ["prmgprod"] = ["428892831"],
            ["fcm"] = ["1275652438"],
            ["gallusagility"] = ["184485983"],
            ["administrator"] = [
                "1026167531",
                "93716433",
                "74610152",
                "1977935901",
                "0",
                "741418449",
                "888221964",
                "193492375",
                "1119088413",
                "1588809781",
                "818396742",
                "1459934658",
                "1094129358",
                "1622018741",
                "1865786808",
                "184485983",
                "1275652438",
                "1977935901",
                "581621867",
                "1694387707",
                "428892831",
                "1476805275",
                "1905265078",
                "1416332342",
                "807229780",
                "1270257552"
            ]
        };
    }
}
