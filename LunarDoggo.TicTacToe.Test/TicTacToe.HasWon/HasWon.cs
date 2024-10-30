// ********RoostGPT********
/*
Test generated by RoostGPT for test csharp-test using AI Type  and AI Model 

ROOST_METHOD_HASH=HasWon_ca2e109cdd
ROOST_METHOD_SIG_HASH=HasWon_c6b52a8205

   ########## Test-Scenarios ##########  

Scenario 1: Player has won by filling a row

Details:
    TestName: TestHasWonByRow.
    Description: This test checks if the HasWon method correctly identifies when a player has won by filling a row with their symbol.

Execution:
    Arrange: Create a game board where a player has filled a row with their symbol.
    Act: Invoke the HasWon method with the player's identifier.
    Assert: Assert that the method returns true.

Validation:
    The assertion verifies that the HasWon method correctly identifies a win by row. This test is significant because it validates a core part of the game's win condition.

Scenario 2: Player has won by filling a column

Details:
    TestName: TestHasWonByColumn.
    Description: This test checks if the HasWon method correctly identifies when a player has won by filling a column with their symbol.

Execution:
    Arrange: Create a game board where a player has filled a column with their symbol.
    Act: Invoke the HasWon method with the player's identifier.
    Assert: Assert that the method returns true.

Validation:
    The assertion verifies that the HasWon method correctly identifies a win by column. This test is important as it validates another part of the game's win condition.

Scenario 3: Player has won by filling a diagonal

Details:
    TestName: TestHasWonByDiagonal.
    Description: This test checks if the HasWon method correctly identifies when a player has won by filling a diagonal with their symbol.

Execution:
    Arrange: Create a game board where a player has filled a diagonal with their symbol.
    Act: Invoke the HasWon method with the player's identifier.
    Assert: Assert that the method returns true.

Validation:
    The assertion verifies that the HasWon method correctly identifies a win by diagonal. This test is crucial as it validates the final part of the game's win condition.

Scenario 4: Player has not won

Details:
    TestName: TestHasNotWon.
    Description: This test checks if the HasWon method correctly identifies when a player has not met any of the win conditions.

Execution:
    Arrange: Create a game board where no player has met the win conditions.
    Act: Invoke the HasWon method with a player's identifier.
    Assert: Assert that the method returns false.

Validation:
    The assertion verifies that the HasWon method correctly identifies when a player has not won. This test is important because it confirms that the method doesn't falsely attribute wins.

Scenario 5: Player has won but with a different player's identifier

Details:
    TestName: TestHasWonWithDifferentPlayerIdentifier.
    Description: This test checks if the HasWon method correctly identifies when a player has won but is checked with a different player's identifier.

Execution:
    Arrange: Create a game board where one player has met the win conditions.
    Act: Invoke the HasWon method with a different player's identifier.
    Assert: Assert that the method returns false.

Validation:
    The assertion verifies that the HasWon method correctly identifies the right player's win. This test is important because it validates the method's ability to distinguish between different players.


*/

// ********RoostGPT********
using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe.Test
{
    [TestFixture]
    public class HasWonTest
    {
        private GameBoard gameBoard;

        [SetUp]
        public void Setup()
        {
            this.gameBoard = new GameBoard();
        }

        [Test, Category("valid")]
        public void TestHasWonByRow()
        {
            byte player = 1;
            this.gameBoard.OccupyTile(player, 0, 0);
            this.gameBoard.OccupyTile(player, 0, 1);
            this.gameBoard.OccupyTile(player, 0, 2);

            bool result = this.gameBoard.HasWon(player);

            Assert.IsTrue(result);
        }

        [Test, Category("valid")]
        public void TestHasWonByColumn()
        {
            byte player = 1;
            this.gameBoard.OccupyTile(player, 0, 0);
            this.gameBoard.OccupyTile(player, 1, 0);
            this.gameBoard.OccupyTile(player, 2, 0);

            bool result = this.gameBoard.HasWon(player);

            Assert.IsTrue(result);
        }

        [Test, Category("valid")]
        public void TestHasWonByDiagonal()
        {
            byte player = 1;
            this.gameBoard.OccupyTile(player, 0, 0);
            this.gameBoard.OccupyTile(player, 1, 1);
            this.gameBoard.OccupyTile(player, 2, 2);

            bool result = this.gameBoard.HasWon(player);

            Assert.IsTrue(result);
        }

        [Test, Category("valid")]
        public void TestHasNotWon()
        {
            byte player = 1;
            this.gameBoard.OccupyTile(player, 0, 0);
            this.gameBoard.OccupyTile(player, 1, 0);
            this.gameBoard.OccupyTile(player, 2, 1);

            bool result = this.gameBoard.HasWon(player);

            Assert.IsFalse(result);
        }

        [Test, Category("valid")]
        public void TestHasWonWithDifferentPlayerIdentifier()
        {
            byte player1 = 1;
            byte player2 = 2;
            this.gameBoard.OccupyTile(player1, 0, 0);
            this.gameBoard.OccupyTile(player1, 0, 1);
            this.gameBoard.OccupyTile(player1, 0, 2);

            bool result = this.gameBoard.HasWon(player2);

            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            this.gameBoard.Reset();
        }
    }
}
