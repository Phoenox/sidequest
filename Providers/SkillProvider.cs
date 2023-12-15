namespace SideQuest.Providers;

using Blazored.LocalStorage;
using Data;

public class SkillProvider(ISyncLocalStorageService localStorageService)
{
	private readonly List<Skill> skills = [];

	public IEnumerable<Skill> GetSkills()
		=> skills.AsReadOnly();

	public Skill GetSkill(Guid id)
		=> skills.First(s => s.Id == id);
	
	public void UpdateSkill(Skill skill) {
		var index = skills.FindIndex(s => s.Id == skill.Id);
		skills[index] = skill;
	}
	
	public void AddSkill(Skill skill)
		=> skills.Add(skill);
}
