using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume
{
	public interface IDataService
	{
		Task<List<GroupedDisplay>> GetQualifications();

		Task<List<WorkExperience>> GetWorkExperiences();
	}
}
