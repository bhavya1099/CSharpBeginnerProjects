// ********RoostGPT********
/*
Test generated by RoostGPT for test java-customannotation-test using AI Type  and AI Model 

ROOST_METHOD_HASH=MoveToNextQuestion_927b31ccfb
ROOST_METHOD_SIG_HASH=MoveToNextQuestion_2455d33844

   ########## Test-Scenarios ##########  

Scenario 1: MoveToNextQuestion With Unanswered Questions Available

Details:
  TestName: MoveToNextQuestionWithQuestionsAvailable
  Description: Validates that the next question is set properly when there are unanswered questions available.
Execution:
  Arrange: Create an instance of GameState with a non-empty list of QuizQuestion objects.
  Act: Call the MoveToNextQuestion method on the GameState instance.
  Assert: Check that CurrentQuestion is not null and IsCurrentQuestionAnswered is set to false.
Validation:
  The assertion confirms that the method successfully retrieves a random unanswered question and correctly updates the state. This test is significant as it ensures the game can progress by moving to the next question.

Scenario 2: MoveToNextQuestion With No Unanswered Questions

Details:
  TestName: MoveToNextQuestionWithNoQuestionsAvailable
  Description: Validates that the method does not change the CurrentQuestion when no unanswered questions are available.
Execution:
  Arrange: Create a GameState instance where all questions have been answered (empty unansweredQuestions list).
  Act: Store the current value of CurrentQuestion, then call the MoveToNextQuestion method.
  Assert: Assert that the CurrentQuestion remains unchanged.
Validation:
  The assertion checks whether CurrentQuestion remains the same, demonstrating that the method correctly handles the scenario where no unanswered questions are left, an essential aspect to prevent runtime errors in the game logic.

Scenario 3: Check HighlitghtedAnswerIndex Reset on MoveToNextQuestion

Details:
  TestName: CheckHighlightedAnswerIndexResetOnMoveToNextQuestion
  Description: Ensures that the highlightedAnswerIndex is reset to 0 when MoveToNextQuestion is executed.
Execution:
  Arrange: Create a GameState instance with unanswered quiz questions and artificially set highlightedAnswerIndex to a non-zero value.
  Act: Call the MoveToNextQuestion method.
  Assert: Assert that highlightedAnswerIndex has been reset to 0.
Validation:
  This test confirms that after moving to a new question, the first possible answer is highlighted by default. The reset is crucial for proper navigation through answer options for subsequent questions.

Scenario 4: Check ChosenAnswer Reset on MoveToNextQuestion

Details:
  TestName: CheckChosenAnswerResetOnMoveToNextQuestion
  Description: Check that ChosenAnswer is reset to null after executing MoveToNextQuestion.
Execution:
  Arrange: Initialize GameState with unanswered questions, simulate answering a question to set a non-null ChosenAnswer.
  Act: Call MoveToNextQuestion method.
  Assert: Assert that ChosenAnswer is reset to null.
Validation:
  Ensures that after moving to the next question, no answer is marked as chosen from the previous question. This behavior is vital for maintaining game integrity and user experience.

Scenario 5: Random Question Selection Is Non-Deterministic

Details:
  TestName: RandomQuestionSelectionIsNonDeterministic
  Description: Test to verify that the method selects a different random question upon subsequent invocations, simulating the randomness of question selection.
Execution:
  Arrange: Initialize GameState with a list of several unanswered questions, and call MoveToNextQuestion multiple times, recording the CurrentQuestion.
  Act: Compare the questions selected across multiple invocations to see if at least once a different question was selected.
  Assert: Check that not all recorded CurrentQuestion are the same.
Validation:
  This test helps ensure that the MoveToNextQuestion method is leveraging the randomness as expected, which is crucial for keeping the quiz dynamic and engaging.


*/

// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.QuizGame;
using System.Collections.Generic;
using System.Linq;

namespace LunarDoggo.QuizGame.Test
{
    [TestFixture]
    public class MoveToNextQuestionTest
    {
        [Test, Category("valid")]
        public void MoveToNextQuestionWithQuestionsAvailable()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = true }, new QuizQuestionAnswer { IsCorrect = false } } },
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = false }, new QuizQuestionAnswer { IsCorrect = true } } }
            };
            var gameState = new GameState(questions);

            // Act
            gameState.MoveToNextQuestion();

            // Assert
            Assert.IsNotNull(gameState.CurrentQuestion);
            Assert.IsFalse(gameState.IsCurrentQuestionAnswered);
        }

        [Test, Category("invalid")]
        public void MoveToNextQuestionWithNoQuestionsAvailable()
        {
            // Arrange
            var gameState = new GameState(Enumerable.Empty<QuizQuestion>());
            var initialCurrentQuestion = gameState.CurrentQuestion;

            // Act
            gameState.MoveToNextQuestion();

            // Assert
            Assert.AreEqual(initialCurrentQuestion, gameState.CurrentQuestion);
        }

        [Test, Category("valid")]
        public void CheckHighlightedAnswerIndexResetOnMoveToNextQuestion()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = true }, new QuizQuestionAnswer { IsCorrect = false } } }
            };
            var gameState = new GameState(questions);
            gameState.HighlightNextAnswer(); // Increment highlighted answer index to simulate selection

            // Act
            gameState.MoveToNextQuestion();

            // Assert
            Assert.AreEqual(0, typeof(GameState).GetField("_highlightedAnswerIndex", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(gameState));
        }

        [Test, Category("valid")]
        public void CheckChosenAnswerResetOnMoveToNextQuestion()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = true }, new QuizQuestionAnswer { IsCorrect = false } } }
            };
            var gameState = new GameState(questions);
            gameState.AnswerQuestion();

            // Act
            gameState.MoveToNextQuestion();

            // Assert
            Assert.IsNull(gameState.ChosenAnswer);
        }

        [Test, Category("boundary")]
        public void RandomQuestionSelectionIsNonDeterministic()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = true }, new QuizQuestionAnswer { IsCorrect = false } } },
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = false }, new QuizQuestionAnswer { IsCorrect = true } } },
                new QuizQuestion { Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = true }, new QuizQuestionAnswer { IsCorrect = false } } }
            };
            var gameState = new GameState(questions);
            var selectedQuestions = new List<QuizQuestion>();

            // Act
            int iterations = 5; // More iterations for better chance to observe randomness
            for (int i = 0; i < iterations; i++)
            {
                gameState.MoveToNextQuestion();
                selectedQuestions.Add(gameState.CurrentQuestion);
            }

            // Assert
            Assert.IsTrue(selectedQuestions.Distinct().Count() > 1, "Should select different questions on successive calls.");
        }
    }
}
