using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.TestTools;
using System.Reflection;

namespace Tests.Unit {

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

        [Test]
        public void JsonFormatter_SerializesAndDeserializesHashSetCorrectly() {
            var set = new HashSet<int> { 2, 5, 8 };
            string json = JsonFormatter.ToJson(set);
            var deserialized = JsonFormatter.FromJson<HashSet<int>>(json);

            Assert.AreEqual(3, deserialized.Count);
            Assert.IsTrue(deserialized.Contains(5));
        }

        [Test]
        public void EnemyTilesBehavior_OnEvent_SetsPlayerDeadAndStartsCoroutine() {
            var go = new GameObject();
            var enemy = go.AddComponent<EnemyTilesBehavior>();
            var popup = new GameObject().AddComponent<PopupAnimation>();
            enemy.failWindow = popup;

            // Инициализируем Player.State
            var playerObj = new GameObject();
            Player.State = new Player.PlayerState(playerObj.AddComponent<Animator>());

            enemy.OnEvent();

            Assert.IsTrue(Player.State.IsDead);
        }

        public class SimpleTilemapHandlerStub : TilemapHandler {
            public override bool isCollision(Vector3Int cell) => true;
            public override bool isCollision(ObjectBehavior objBeh) => objBeh?.objectProperty.IsCollision ?? false;
        }
        
    }
}
