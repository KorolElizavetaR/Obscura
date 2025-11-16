using NUnit.Framework;
using UnityEngine;

namespace Tests.Unit {

    class FakeTilemapHandler : TilemapHandler {
        bool _value;
        public FakeTilemapHandler(bool alwaysCollision) {
            _value = alwaysCollision;
        }

        public override bool isCollision(ObjectBehavior nextCell) {
            return _value;
        }
    }

    public class UnitTests {

        [Test]
        public void ResetProgress_DeletesLevelsFromPlayerPrefs() {
            HandleModalButtonsEvents handler = new HandleModalButtonsEvents();
            PlayerPrefs.SetString("levels", "[1,2,3]");
            handler.resetProgress();
            Assert.IsFalse(PlayerPrefs.HasKey("levels"));
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void PlayerState_IsWin_SetToTrue() {
            // Arrange
            var animator = new GameObject().AddComponent<Animator>();
            var playerState = new Player.PlayerState(animator);

            // Act
            playerState.IsWin = true;

            // Assert
            Assert.IsTrue(playerState.IsWin);
        }

        
        [Test]
        public void EnemyTilesBehavior_OnEvent_SetsPlayerDeadState() {
            // Arrange
            var enemyTile = new GameObject().AddComponent<EnemyTilesBehavior>();
            var failWindow = new GameObject().AddComponent<PopupAnimation>();
            enemyTile.failWindow = failWindow;

            // Initialize Player state
            var playerObj = new GameObject();
            var animator = playerObj.AddComponent<Animator>();
            Player.State = new Player.PlayerState(animator);

            // Act
            enemyTile.OnEvent();

            // Assert
            Assert.IsTrue(Player.State.IsDead);
        }

    }
}
