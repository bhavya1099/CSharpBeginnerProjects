// ********RoostGPT********
/*
Test generated by RoostGPT for test csharp-test using AI Type  and AI Model 

ROOST_METHOD_HASH=OccupyTile_93382c77ca
ROOST_METHOD_SIG_HASH=OccupyTile_992d29020a

   ########## Test-Scenarios ##########  

Scenario 1: Test to check if the OccupyTile method correctly assigns a tile to a player.

Details:
    TestName: TestOccupyTileAssignsTileToPlayer.
    Description: This test is meant to check if the OccupyTile method correctly assigns a tile to a player when the tile is not already occupied.
Execution:
    Arrange: Create a Player instance and the GameBoard instance.
    Act: Call the OccupyTile method with the player instance and valid x, y coordinates.
    Assert: Check if the tile is now occupied by the player.
Validation:
    The assertion verifies that the OccupyTile method correctly assigns the tile to the player. It's significant in the context of game rules.

Scenario 2: Test to check if the OccupyTile method returns false when trying to occupy an already occupied tile.

Details:
    TestName: TestOccupyTileReturnsFalseForOccupiedTile.
    Description: This test is meant to check if the OccupyTile method returns false when a player tries to occupy a tile that is already occupied.
Execution:
    Arrange: Create two Player instances and the GameBoard instance. Call the OccupyTile method for the first player.
    Act: Call the OccupyTile method for the second player with the same x, y coordinates as the first player.
    Assert: Check if the method returns false.
Validation:
    The assertion verifies that the OccupyTile method correctly prevents a player from occupying a tile that's already occupied. It's significant in the context of game rules.

Scenario 3: Test to check if the OccupyTile method raises the PlayerOccupiedTile event.

Details:
    TestName: TestOccupyTileRaisesPlayerOccupiedTileEvent.
    Description: This test is meant to check if the OccupyTile method raises the PlayerOccupiedTile event when a player successfully occupies a tile.
Execution:
    Arrange: Create a Player instance and the GameBoard instance. Subscribe to the PlayerOccupiedTile event.
    Act: Call the OccupyTile method with the player instance and valid x, y coordinates.
    Assert: Check if the PlayerOccupiedTile event was raised.
Validation:
    The assertion verifies that the OccupyTile method correctly raises the PlayerOccupiedTile event. It's significant in the context of the game's event-driven architecture.

Scenario 4: Test to check if the OccupyTile method handles invalid x, y coordinates.

Details:
    TestName: TestOccupyTileHandlesInvalidCoordinates.
    Description: This test is meant to check if the OccupyTile method handles invalid x, y coordinates.
Execution:
    Arrange: Create a Player instance and the GameBoard instance.
    Act: Call the OccupyTile method with the player instance and invalid x, y coordinates.
    Assert: Check if the method throws an exception.
Validation:
    The assertion verifies that the OccupyTile method correctly handles invalid x, y coordinates. It's significant in the context of error handling.


*/

// ********RoostGPT********
using System;
using NUnit.Framework;
using Moq;
using TicTacToe;

namespace TicTacToe.Test
{
    [TestFixture]
    public class OccupyTileTest
    {
        private GameBoard gameBoard;
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            gameBoard = new GameBoard();
            player1 = new Player(1, "X");
            player2 = new Player(2, "O");
        }

        [Test, Category("Valid")]
        public void TestOccupyTileAssignsTileToPlayer()
        {
            int x = 0, y = 0;

            bool result = gameBoard.OccupyTile(player1, x, y);

            Assert.IsTrue(result, "Tile should be occupied by player1");
        }

        [Test, Category("Invalid")]
        public void TestOccupyTileReturnsFalseForOccupiedTile()
        {
            int x = 0, y = 0;
            gameBoard.OccupyTile(player1, x, y);

            bool result = gameBoard.OccupyTile(player2, x, y);

            Assert.IsFalse(result, "Tile already occupied by player1, player2 should not be able to occupy it");
        }

        [Test, Category("Valid")]
        public void TestOccupyTileRaisesPlayerOccupiedTileEvent()
        {
            int x = 0, y = 0;
            bool eventRaised = false;
            gameBoard.PlayerOccupiedTile += (s, e) => eventRaised = true;

            gameBoard.OccupyTile(player1, x, y);

            Assert.IsTrue(eventRaised, "PlayerOccupiedTile event should be raised when a player successfully occupies a tile");
        }

        [Test, Category("Invalid")]
        public void TestOccupyTileHandlesInvalidCoordinates()
        {
            int x = -1, y = 0;

            TestDelegate testDelegate = () => gameBoard.OccupyTile(player1, x, y);

            Assert.Throws<IndexOutOfRangeException>(testDelegate, "OccupyTile method should throw an exception when x, y coordinates are invalid");
        }

        [TearDown]
        public void TearDown()
        {
            gameBoard = null;
            player1 = null;
            player2 = null;
        }
    }
}
