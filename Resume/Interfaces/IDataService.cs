using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume
{
	public interface IDataService
	{
		Task<List<Timeline>> GetTimeline();

		Task<List<GroupedDisplay>> GetQualifications();

		Task<List<WorkExperience>> GetWorkExperiences();

		Task<List<GroupedDisplay>> GetTechnicalSkills();

		Task<List<Project>> GetProjectsList();

		Task<List<Preference>> GetPreferences();
	}
}
