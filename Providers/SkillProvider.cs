namespace SideQuest.Providers;

using Blazored.LocalStorage;
using Data;

public class SkillProvider(ISyncLocalStorageService localStorageService)
{
	private const string SkillsKey = "skills";
	
	public IEnumerable<Skill> GetSkills() {
		return localStorageService.GetItem<IEnumerable<Skill>>(SkillsKey)
		       ?? new List<Skill>();
	}
	
	private void SaveSkills(IEnumerable<Skill> skills)
		=> localStorageService.SetItem(SkillsKey, skills);

	public Skill GetSkill(Guid id) {
		var skills = GetSkills();
		return skills.First(s => s.Id == id);
	}
	
	public void UpdateSkill(Skill skill) {
		var skills = GetSkills().ToList();
		var index = skills.FindIndex(s => s.Id == skill.Id);
		skills[index] = skill;
		SaveSkills(skills);
	}

	public void AddSkill(Skill skill) {
		var skills = GetSkills().ToList();
		var updatedSkills = skills.Append(skill);
		SaveSkills(updatedSkills);
	}
	
	public void RemoveSkill(Skill skill) {
		var skills = GetSkills().ToList();
		var updatedSkills = skills.Where(s => s.Id != skill.Id);
		SaveSkills(updatedSkills);
	}
}
