using System;
using DotQuiz.Api.Models;
using Xunit;

namespace DotQuiz.Test 
{
    public class GameSessionTest
    {
        [Fact]
        public void NewGame_ShouldStartWithEmptyProgress()
        {
            var session = new GameSession("Darth Vader", new Locale("en", "US"), GameLevel.Medium);
            Assert.NotEqual(Guid.Empty, session.Id);
            Assert.Equal("Darth Vader", session.PlayerName);
            Assert.Equal("en_US", session.Locale.Name);
            Assert.Equal(GameLevel.Medium, session.Level);
            Assert.Equal(10, session.PendingQuestions);
        }
    }
}