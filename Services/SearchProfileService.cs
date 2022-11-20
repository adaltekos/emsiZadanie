using emsiZadanie.Models;

namespace emsiZadanie.Services;

public static class SearchProfileService
{
    static List<SearchProfile> SearchProfiles { get; }
    static int nextId = 0;
    static SearchProfileService()
    {
        SearchProfiles = new List<SearchProfile> { };
    }

	public static List<SearchProfile> GetAll() => SearchProfiles;

    public static SearchProfile Get(int id) => SearchProfiles.FirstOrDefault(p => p.Id == id)!;

    public static void Add(List<string> phrases)
    {
        SearchProfile searchProfile = new SearchProfile { Id = nextId++, Phrases = phrases };
		SearchProfiles.Add(searchProfile);
    }

}