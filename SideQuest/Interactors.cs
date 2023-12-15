namespace SideQuest;

using Data;
using Providers;

public static class Interactors
{
	public static IEnumerable<Skill> GetSkills()
		=> SkillProvider.GetSkills();

	public static Skill GetSkill(Guid id)
		=> SkillProvider.GetSkill(id);
	
	public static IEnumerable<Skill> AddSkill(Skill skill) {
		SkillProvider.AddSkill(skill);
		return SkillProvider.GetSkills();
	}
	
	public static Skill AddQuest(Skill skill, Quest quest) {
		var updatedSkill = Domain.Structure.AddQuest(skill, quest);
		SkillProvider.UpdateSkill(updatedSkill);
		return updatedSkill;
	}
	
	public static Skill MarkQuestAsDone(Skill skill, Quest quest) {
		var updatedSkill = Domain.Progression.MarkQuestAsDone(skill, quest);
		SkillProvider.UpdateSkill(updatedSkill);
		return updatedSkill;
	}
}
