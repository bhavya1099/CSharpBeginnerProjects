// ********RoostGPT********
/*
Test generated by RoostGPT for test artilleryTest using AI Type  and AI Model 

ROOST_METHOD_HASH=AreAllFieldsOccupied_01adc85aeb
ROOST_METHOD_SIG_HASH=AreAllFieldsOccupied_be4cd9d72c

   ########## Test-Scenarios ##########  

Scenario 1: All fields are occupied
Details:
  TestName: TestAreAllFieldsOccupied_AllFieldsOccupied
  Description: This test is meant to check if the method correctly returns true when all fields in the game board are occupied by players.
Execution:
  Arrange: Set up a game board with all fields occupied by players.
  Act: Call the AreAllFieldsOccupied() method.
  Assert: Verify that the method returns true.
Validation:
  The assertion aims to verify that the method correctly checks if all fields in the game board are occupied. This test is significant in ensuring that the game board is correctly detecting when all fields are occupied, which can be used to determine if the game is a draw.

Scenario 2: Some fields are occupied
Details:
  TestName: TestAreAllFieldsOccupied_SomeFieldsOccupied
  Description: This test is meant to check if the method correctly returns false when some fields in the game board are occupied by players.
Execution:
  Arrange: Set up a game board with some fields occupied by players.
  Act: Call the AreAllFieldsOccupied() method.
  Assert: Verify that the method returns false.
Validation:
  The assertion aims to verify that the method correctly checks if some fields in the game board are occupied. This test is significant in ensuring that the game board is correctly detecting when not all fields are occupied, which can be used to continue the game.

Scenario 3: No fields are occupied
Details:
  TestName: TestAreAllFieldsOccupied_NoFieldsOccupied
  Description: This test is meant to check if the method correctly returns false when no fields in the game board are occupied by players.
Execution:
  Arrange: Set up a game board with no fields occupied by players.
  Act: Call the AreAllFieldsOccupied() method.
  Assert: Verify that the method returns false.
Validation:
  The assertion aims to verify that the method correctly checks if no fields in the game board are occupied. This test is significant in ensuring that the game board is correctly detecting when no fields are occupied, which can be used to continue the game.

Scenario 4: Empty game board
Details:
  TestName: TestAreAllFieldsOccupied_EmptyGameBoard
  Description: This test is meant to check if the method correctly returns false when the game board is empty.
Execution:
  Arrange: Set up an empty game board.
  Act: Call the AreAllFieldsOccupied() method.
  Assert: Verify that the method returns false.
Validation:
  The assertion aims to verify that the method correctly checks if the game board is empty. This test is significant in ensuring that the game board is correctly detecting when it is empty, which can be used to start a new game.

Scenario 5: Large game board
Details:
  TestName: TestAreAllFieldsOccupied_LargeGameBoard
  Description: This test is meant to check if the method correctly handles a large game board with multiple rows and columns.
Execution:
  Arrange: Set up a large game board with multiple rows and columns, with some fields occupied by players.
  Act: Call the AreAllFieldsOccupied() method.
  Assert: Verify that the method returns false.
Validation:
  The assertion aims to verify that the method correctly handles a large game board with multiple rows and columns. This test is significant in ensuring that the method can handle different sizes of game boards and correctly detect if all fields are occupied.


*/

// ********RoostGPT********
using NUnit.Framework;
using System;

namespace TicTacToe.Test
{
    [TestFixture]
    public class AreAllFieldsOccupiedTest
    {
        private GameBoard gameBoard;

        [SetUp]
        public void Setup()
        {
            gameBoard = new GameBoard();
        }

        [Test]
        [Category("valid")]
        public void TestAreAllFieldsOccupied_AllFieldsOccupied()
        {
            OccupyAllFields();
            bool result = gameBoard.AreAllFieldsOccupied();
            Assert.IsTrue(result);
        }

        [Test]
        [Category("valid")]
        public void TestAreAllFieldsOccupied_SomeFieldsOccupied()
        {
            OccupySomeFields();
            bool result = gameBoard.AreAllFieldsOccupied();
            Assert.IsFalse(result);
        }

        [Test]
        [Category("valid")]
        public void TestAreAllFieldsOccupied_NoFieldsOccupied()
        {
            bool result = gameBoard.AreAllFieldsOccupied();
            Assert.IsFalse(result);
        }

        [Test]
        [Category("valid")]
        public void TestAreAllFieldsOccupied_EmptyGameBoard()
        {
            bool result = gameBoard.AreAllFieldsOccupied();
            Assert.IsFalse(result);
        }

        [Test]
        [Category("valid")]
        public void TestAreAllFieldsOccupied_LargeGameBoard()
        {
            OccupySomeFields();
            bool result = gameBoard.AreAllFieldsOccupied();
            Assert.IsFalse(result);
        }

        private void OccupyAllFields()
        {
            for (int x = 0; x < gameBoard.tiles.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.tiles.GetLength(1); y++)
                {
                    gameBoard.tiles[x, y] = 1;
                }
            }
        }

        private void OccupySomeFields()
        {
            gameBoard.tiles[0, 0] = 1;
            gameBoard.tiles[1, 0] = 1;
            gameBoard.tiles[2, 0] = 0;
            gameBoard.tiles[0, 1] = 1;
            gameBoard.tiles[1, 1] = 0;
            gameBoard.tiles[2, 1] = 1;
            gameBoard.tiles[0, 2] = 0;
            gameBoard.tiles[1, 2] = 1;
            gameBoard.tiles[2, 2] = 1;
        }
    }
}
