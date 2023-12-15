namespace SideQuest;

using Data;
using Providers;

public class Interactors(SkillProvider skillProvider)
{
	public IEnumerable<Skill> GetSkills()
		=> skillProvider.GetSkills();

	public Skill GetSkill(Guid id)
		=> skillProvider.GetSkill(id);
	
	public IEnumerable<Skill> AddSkill(Skill skill) {
		skillProvider.AddSkill(skill);
		return skillProvider.GetSkills();
	}

	public IEnumerable<Skill> RemoveSkill(Skill skill) {
		skillProvider.RemoveSkill(skill);
		return skillProvider.GetSkills();
	}
	
	public Skill AddQuest(Skill skill, Quest quest) {
		var updatedSkill = Domain.Structure.AddQuest(skill, quest);
		skillProvider.UpdateSkill(updatedSkill);
		return updatedSkill;
	}
	
	public Skill RemoveQuest(Skill skill, Quest quest) {
		var updatedSkill = Domain.Structure.RemoveQuest(skill, quest);
		skillProvider.UpdateSkill(updatedSkill);
		return updatedSkill;
	}
	
	public Skill MarkQuestAsDone(Skill skill, Quest quest) {
		var updatedSkill = Domain.Progression.MarkQuestAsDone(skill, quest);
		skillProvider.UpdateSkill(updatedSkill);
		return updatedSkill;
	}
}
