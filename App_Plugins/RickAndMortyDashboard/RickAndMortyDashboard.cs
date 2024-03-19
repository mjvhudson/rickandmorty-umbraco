using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Dashboards;

namespace RickAndMortyProject.App_Plugins.RickAndMortyDashboard
{
    public class RickAndMortyDashboard : IDashboard
    {
        public string[] Sections => [Constants.Applications.Content];

        public IAccessRule[] AccessRules
        {
            get
            {
                return
                [
                    new AccessRule { Type = AccessRuleType.Grant, Value = Constants.Security.AdminGroupAlias }
                ];
            }
        }

        public string? Alias => "RickAndMortyCharacters";

        public string? View => "backoffice/RickAndMortyCharacters";
    }
}
