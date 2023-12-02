using System.Text.Json.Serialization;

namespace greatnet8hack.Web
{
    public enum WritingLevel
    {
        Academic = 0,
        Scandalous = 1
    }

    [Serializable]
    public class ApiResponse 
    { 
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class SearchResponse
    {
        public Project[] projects { get; set; }
    }

    public class ProjectResponse
    {
        public Project project { get; set; }
    }

    public class GptProjectResponse
    {
        public GptProjectResponse()
        {
            Project = new Project();
            GptResponse = new GptResponse
            {
                Keywords = []
            };
        }
        public Project Project { get; set; }
        public GptResponse GptResponse { get; set; }
    }

    public class GptResponse
    {
        public GptResponse()
        {
            Headline = string.Empty;
            Subhead = string.Empty;
            ImageUrl = string.Empty;
            Keywords = [];
        }
        public string Headline { get; set; }
        public string Subhead { get; set; }
        public string ImageUrl { get; set; }
        public string[] Keywords { get; set; }
    }

    public class Project
    {
        public string acronym { get; set; }
        public int projectId { get; set; }
        public string title { get; set; }
        public Primarytaxonomynode[] primaryTaxonomyNodes { get; set; }
        public int startTrl { get; set; }
        public int currentTrl { get; set; }
        public int endTrl { get; set; }
        public string benefits { get; set; }
        public string description { get; set; }
        public Destination[] destinations { get; set; }
        public int startYear { get; set; }
        public int startMonth { get; set; }
        public int endYear { get; set; }
        public int endMonth { get; set; }
        public string statusDescription { get; set; }
        public Principalinvestigator[] principalInvestigators { get; set; }
        public Programdirector[] programDirectors { get; set; }
        public Programexecutive[] programExecutives { get; set; }
        public Coinvestigator[] coInvestigators { get; set; }
        public string website { get; set; }
        public Libraryitem[] libraryItems { get; set; }
        public Transition[] transitions { get; set; }
        public Responsiblemd responsibleMd { get; set; }
        public Program program { get; set; }
        public Leadorganization leadOrganization { get; set; }
        public Supportingorganization[] supportingOrganizations { get; set; }
        public Stateswithwork[] statesWithWork { get; set; }
        public string lastUpdated { get; set; }
        public string releaseStatusString { get; set; }
        public int viewCount { get; set; }
        public string endDateString { get; set; }
        public string startDateString { get; set; }
    }

    public class Responsiblemd
    {
        public string acronym { get; set; }
        public bool canUserEdit { get; set; }
        public string city { get; set; }
        public bool external { get; set; }
        public int linkCount { get; set; }
        public int organizationId { get; set; }
        public string organizationName { get; set; }
        public string organizationType { get; set; }
        public bool naorganization { get; set; }
        public string organizationTypePretty { get; set; }
    }

    public class Program
    {
        public string acronym { get; set; }
        public bool active { get; set; }
        public string description { get; set; }
        public int programId { get; set; }
        public Responsiblemd1 responsibleMd { get; set; }
        public int responsibleMdId { get; set; }
        public int stockImageFileId { get; set; }
        public string title { get; set; }
    }

    public class Responsiblemd1
    {
        public string acronym { get; set; }
        public bool canUserEdit { get; set; }
        public string city { get; set; }
        public bool external { get; set; }
        public int linkCount { get; set; }
        public int organizationId { get; set; }
        public string organizationName { get; set; }
        public string organizationType { get; set; }
        public bool naorganization { get; set; }
        public string organizationTypePretty { get; set; }
    }

    public class Leadorganization
    {
        public string acronym { get; set; }
        public bool canUserEdit { get; set; }
        public string city { get; set; }
        public Country country { get; set; }
        public int countryId { get; set; }
        public bool external { get; set; }
        public int linkCount { get; set; }
        public int organizationId { get; set; }
        public string organizationName { get; set; }
        public string organizationType { get; set; }
        public Stateterritory stateTerritory { get; set; }
        public int stateTerritoryId { get; set; }
        public bool naorganization { get; set; }
        public string organizationTypePretty { get; set; }
    }

    public class Country
    {
        public string abbreviation { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
    }

    public class Stateterritory
    {
        public string abbreviation { get; set; }
        public Country1 country { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
        public int stateTerritoryId { get; set; }
    }

    public class Country1
    {
        public string abbreviation { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
    }

    public class Primarytaxonomynode
    {
        public int taxonomyNodeId { get; set; }
        public int taxonomyRootId { get; set; }
        public int parentNodeId { get; set; }
        public int level { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string definition { get; set; }
        public string exampleTechnologies { get; set; }
        public bool hasChildren { get; set; }
        public bool hasInteriorContent { get; set; }
    }

    public class Destination
    {
        public int lkuCodeId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int lkuCodeTypeId { get; set; }
        public Lkucodetype lkuCodeType { get; set; }
    }

    public class Lkucodetype
    {
        public string codeType { get; set; }
        public string description { get; set; }
    }

    public class Principalinvestigator
    {
        public int contactId { get; set; }
        public bool canUserEdit { get; set; }
        public int displayOrder { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string fullNameInverted { get; set; }
        public string primaryEmail { get; set; }
        public bool publicEmail { get; set; }
        public bool nacontact { get; set; }
    }

    public class Programdirector
    {
        public int contactId { get; set; }
        public bool canUserEdit { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string fullNameInverted { get; set; }
        public string middleInitial { get; set; }
        public string primaryEmail { get; set; }
        public bool publicEmail { get; set; }
        public bool nacontact { get; set; }
    }

    public class Programexecutive
    {
        public int contactId { get; set; }
        public bool canUserEdit { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string fullNameInverted { get; set; }
        public string middleInitial { get; set; }
        public string primaryEmail { get; set; }
        public bool publicEmail { get; set; }
        public bool nacontact { get; set; }
    }

    public class Coinvestigator
    {
        public int contactId { get; set; }
        public bool canUserEdit { get; set; }
        public int displayOrder { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string fullNameInverted { get; set; }
        public string primaryEmail { get; set; }
        public bool publicEmail { get; set; }
        public bool nacontact { get; set; }
        public string middleInitial { get; set; }
    }

    public class Libraryitem
    {
        public object[] files { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int libraryItemTypeId { get; set; }
        public int projectId { get; set; }
        public string publishedBy { get; set; }
        public string publishedDateString { get; set; }
        public Contenttype contentType { get; set; }
    }

    public class Contenttype
    {
        public int lkuCodeId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int lkuCodeTypeId { get; set; }
        public Lkucodetype1 lkuCodeType { get; set; }
    }

    public class Lkucodetype1
    {
        public string codeType { get; set; }
        public string description { get; set; }
    }

    public class Transition
    {
        public int transitionId { get; set; }
        public int projectId { get; set; }
        public string partner { get; set; }
        public string transitionDate { get; set; }
        public string infusion { get; set; }
        public string path { get; set; }
        public string details { get; set; }
        public string rationale { get; set; }
        public string infoText { get; set; }
        public string infoTextExtra { get; set; }
        public string dateText { get; set; }
    }

    public class Supportingorganization
    {
        public string acronym { get; set; }
        public bool canUserEdit { get; set; }
        public string city { get; set; }
        public Country2 country { get; set; }
        public int countryId { get; set; }
        public bool external { get; set; }
        public int linkCount { get; set; }
        public int organizationId { get; set; }
        public string organizationName { get; set; }
        public string organizationType { get; set; }
        public Stateterritory1 stateTerritory { get; set; }
        public int stateTerritoryId { get; set; }
        public bool naorganization { get; set; }
        public string organizationTypePretty { get; set; }
        public int murepUnitId { get; set; }
    }

    public class Country2
    {
        public string abbreviation { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
    }

    public class Stateterritory1
    {
        public string abbreviation { get; set; }
        public Country3 country { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
        public int stateTerritoryId { get; set; }
    }

    public class Country3
    {
        public string abbreviation { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
    }

    public class Stateswithwork
    {
        public string abbreviation { get; set; }
        public Country4 country { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
        public int stateTerritoryId { get; set; }
    }

    public class Country4
    {
        public string abbreviation { get; set; }
        public int countryId { get; set; }
        public string name { get; set; }
    }

}
