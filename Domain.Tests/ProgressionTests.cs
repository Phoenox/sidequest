namespace Domain.Tests;

public abstract class ProgressionTests
{
	public class MarkingATestAsDone
	{
		[Fact]
		public void AddsTheQuestsXpToTheSkill() {
			var quest = Dummies.Quest;
			var skill = Dummies.Skill with {
					Quests = [quest],
					Xp = 42,
			};

			var updatedSkill = Progression.MarkQuestAsDone(skill, quest);

			updatedSkill.Xp.Should().Be(92);
		}

		[Fact]
		public void IncreasesTheSkillLevelIfTheSkillsXpIsOver100() {
			var quest = Dummies.Quest;
			var skill = Dummies.Skill with {
					Quests = [quest],
					Xp = 92,
					Level = 0,
			};

			var updatedSkill = Progression.MarkQuestAsDone(skill, quest);

			updatedSkill.Level.Should().Be(1);
		}

		[Fact]
		public void ExcessXpIsCarriedOverToTheNextLevel() {
			var quest = Dummies.Quest;
			var skill = Dummies.Skill with {
					Quests = [quest],
					Xp = 92,
			};

			var updatedSkill = Progression.MarkQuestAsDone(skill, quest);

			updatedSkill.Xp.Should().Be(42);
		}
	}
}
