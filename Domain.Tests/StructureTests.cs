namespace Domain.Tests;

public class StructureTests
{
	[Fact]
	public void AddingAQuestToASkillAppendsItToTheQuestList()
	{
		var skill = Dummies.Skill with {
				Quests = [new Quest("Quest1", 10)],
		};
		var quest = new Quest("Quest2", 10);
		
		var updatedSkill = Structure.AddQuest(skill, quest);

		updatedSkill.Quests.Should().BeEquivalentTo(skill.Quests.Append(quest));
	}
}
