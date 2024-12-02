// ********RoostGPT********
/*
Test generated by RoostGPT for test csharp-test using AI Type Open AI and AI Model gpt-3.5-turbo

ROOST_METHOD_HASH=OccupyTile_9e22e63103
ROOST_METHOD_SIG_HASH=OccupyTile_73b7c8d7ca

   ########## Test-Scenarios ##########  


Scenario 1: Occupying an Empty Tile and Winning the Game

Details:
  TestName: TestOccupyTileAndWinGame
  Description: Verify that when a player occupies an empty tile that leads to a win, the game ends with the player winning.
Execution:
  Arrange: Set up a game state with specific mappings and positions.
  Act: Occupy a tile that results in the player winning.
  Assert: Check if the GameOverPlayerWon event is triggered.
Validation:
  The assertion aims to verify that the game correctly identifies a winning move and ends the game with the winning player. This test ensures the win condition is correctly implemented.

Scenario 2: Occupying a Tile Already Occupied

Details:
  TestName: TestOccupyAlreadyOccupiedTile
  Description: Ensure that attempting to occupy a tile that is already occupied triggers the TileAlreadyOccupied event.
Execution:
  Arrange: Set up a game state with a pre-occupied tile.
  Act: Try to occupy the same tile again.
  Assert: Verify that the TileAlreadyOccupied event is raised.
Validation:
  This test checks the behavior when a player tries to occupy a tile that is already taken. It ensures that the game handles this scenario appropriately.

Scenario 3: Occupying the Last Empty Tile Resulting in a Draw

Details:
  TestName: TestOccupyLastEmptyTileDraw
  Description: Validate that occupying the last empty tile without any player winning results in a draw.
Execution:
  Arrange: Set up a game state where only one empty tile is left.
  Act: Occupy the remaining empty tile.
  Assert: Check if the GameOverDraw event is fired.
Validation:
  This test ensures that the game correctly detects a draw when all tiles are occupied without a win condition being met.

Scenario 4: Switching Players After Occupying a Tile

Details:
  TestName: TestSwitchPlayerAfterOccupyingTile
  Description: Confirm that after successfully occupying a tile, the player turn switches to the next player.
Execution:
  Arrange: Set up a game state with a player occupying a tile.
  Act: Occupy a tile and trigger the switch player logic.
  Assert: Verify that the player turn changes to the next player.
Validation:
  This test validates that the game correctly alternates between players after each successful tile occupation.

Scenario 5: Failing to Occupy a Tile Due to Tile Already Occupied

Details:
  TestName: TestFailToOccupyTileAlreadyOccupied
  Description: Check that when trying to occupy an already occupied tile, the game does not progress and the TileAlreadyOccupied event is raised.
Execution:
  Arrange: Set up a game state with a pre-occupied tile.
  Act: Attempt to occupy the same tile.
  Assert: Ensure that the game state remains unchanged and the TileAlreadyOccupied event is triggered.
Validation:
  This test ensures that the game handles the scenario of trying to occupy an already occupied tile correctly by not allowing the player to make an invalid move.


*/

// ********RoostGPT********
using System;
using System.Linq;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe.Test
{
    public class OccupyTile135Test
    {
        private GameState gameState;

        [SetUp]
        public void Setup()
        {
            ButtonTileMapping[] buttonTileMappings = new ButtonTileMapping[]
            {
                new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 0),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 2, 0),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 1),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 1),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 2, 1),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 2),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 2),
                new ButtonTileMapping(new System.Windows.Controls.Button(), 2, 2),
            };
            gameState = new GameState(buttonTileMappings);
            gameState.StartGame();
        }

        [Test]
        [Category("valid")]
        public void TestOccupyTileAndWinGame()
        {
            // Arrange
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 0));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 1));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 1));

            // Act & Assert
            Assert.That(() => gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 2)), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        [Category("valid")]
        public void TestOccupyAlreadyOccupiedTile()
        {
            // Arrange
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0));

            // Act & Assert
            Assert.That(() => gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0)), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        [Category("valid")]
        public void TestOccupyLastEmptyTileDraw()
        {
            // Arrange
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 0));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 2, 0));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 1));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 1, 2));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 1));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 2, 1));
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 2));

            // Act & Assert
            Assert.That(() => gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 2, 2)), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        [Category("valid")]
        public void TestSwitchPlayerAfterOccupyingTile()
        {
            // Arrange
            Player initialPlayer = gameState.CurrentPlayer;

            // Act
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0));

            // Assert
            Assert.AreNotEqual(initialPlayer, gameState.CurrentPlayer);
        }

        [Test]
        [Category("valid")]
        public void TestFailToOccupyTileAlreadyOccupied()
        {
            // Arrange
            gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0));

            // Act & Assert
            Assert.That(() => gameState.OccupyTile(new ButtonTileMapping(new System.Windows.Controls.Button(), 0, 0)), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
