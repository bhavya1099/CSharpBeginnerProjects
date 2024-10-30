// ********RoostGPT********
/*
Test generated by RoostGPT for test csharp-test using AI Type  and AI Model 

ROOST_METHOD_HASH=StartGame_ea5458875f
ROOST_METHOD_SIG_HASH=StartGame_941d5801f0

   ########## Test-Scenarios ##########  

Scenario 1: Test to validate successful game start

Details:
  TestName: TestSuccessfulGameStart
  Description: This test is meant to check whether the game starts successfully and all the properties are correctly initialized.

Execution:
  Arrange: Create an instance of the GameState class with required buttonTileMappings.
  Act: Invoke the StartGame method.
  Assert: Verify that the currentPlayer is set to firstPlayer, gameBoard is reset and TilesReset event is invoked.

Validation:
  The assertion aims to verify that the game starts correctly with first player's turn and a reset game board. This test is significant as it ensures the game state is correctly initialized for a new game.

Scenario 2: Test to validate game restart

Details:
  TestName: TestGameRestart
  Description: This test is meant to check whether the game restarts successfully after a game is over.

Execution:
  Arrange: Create an instance of the GameState class and simulate a game over situation.
  Act: Invoke the StartGame method.
  Assert: Verify that the currentPlayer is set to firstPlayer, gameBoard is reset and TilesReset event is invoked.

Validation:
  The assertion aims to verify that the game can be restarted correctly after a game over. This test is important to ensure the game can be played multiple times without any lingering state from previous games.

Scenario 3: Test to validate TilesReset event invocation

Details:
  TestName: TestTilesResetEventInvocation
  Description: This test is meant to check whether the TilesReset event is invoked when the game starts.

Execution:
  Arrange: Create an instance of the GameState class and subscribe to the TilesReset event.
  Act: Invoke the StartGame method.
  Assert: Verify that the TilesReset event is invoked.

Validation:
  The assertion aims to verify that the TilesReset event is invoked when the game starts. This test is significant to ensure that the UI is updated correctly when a new game starts. 

Scenario 4: Test to validate game start with null buttonTileMappings

Details:
  TestName: TestGameStartWithNullButtonTileMappings
  Description: This test is meant to check the behavior of the StartGame method when the buttonTileMappings is null.

Execution:
  Arrange: Create an instance of the GameState class with null buttonTileMappings.
  Act: Invoke the StartGame method.
  Assert: Verify that an appropriate exception is thrown.

Validation:
  The assertion aims to verify that the StartGame method handles null buttonTileMappings correctly by throwing an exception. This test is important to ensure the game doesn't start with invalid game state.


*/

// ********RoostGPT********
using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using TicTacToe;

namespace TicTacToe.Test
{
    [TestFixture]
    public class StartGameTest
    {
        private GameState _gameState;
        private Mock<GameBoard> _mockGameBoard;
        private bool _isTilesResetEventInvoked;

        [SetUp]
        public void SetUp()
        {
            _mockGameBoard = new Mock<GameBoard>();
            _gameState = new GameState(new ButtonTileMapping[0])
            {
                gameBoard = _mockGameBoard.Object
            };
            _gameState.TilesReset += (s, e) => _isTilesResetEventInvoked = true;
        }

        [Test, Category('valid')]
        public void TestSuccessfulGameStart()
        {
            _gameState.StartGame();

            Assert.AreEqual(_gameState.currentPlayer, _gameState.firstPlayer);
            _mockGameBoard.Verify(gb => gb.Reset(), Times.Once);
            Assert.IsTrue(_isTilesResetEventInvoked);
        }

        [Test, Category('valid')]
        public void TestGameRestart()
        {
            _gameState.StartGame();
            _gameState.StartGame();

            Assert.AreEqual(_gameState.currentPlayer, _gameState.firstPlayer);
            _mockGameBoard.Verify(gb => gb.Reset(), Times.Exactly(2));
            Assert.IsTrue(_isTilesResetEventInvoked);
        }

        [Test, Category('valid')]
        public void TestTilesResetEventInvocation()
        {
            _gameState.StartGame();

            Assert.IsTrue(_isTilesResetEventInvoked);
        }

        [Test, Category('invalid')]
        public void TestGameStartWithNullButtonTileMappings()
        {
            Assert.Throws<ArgumentNullException>(() => new GameState(null));
        }
    }
}
