using System.Collections;
using NUnit.Framework;
using PixoPong.Game;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayModeTests
    {
        private BallController ball;
        private EnemyController enemyRacket;
        private Countdown countdown;

        [OneTimeSetUp]
        public void Setup()
        {
            var gameArena = Object.Instantiate(Resources.Load<GameObject>("Game"));

            ball = gameArena.GetComponentInChildren<BallController>();
            enemyRacket = gameArena.GetComponentInChildren<EnemyController>();
            countdown = gameArena.GetComponentInChildren<Countdown>();
        }

        [UnityTest]
        public IEnumerator EnemyRacketNeedsToFollowTheBallMovement()
        {
            countdown.time = 0;

            var ballOriginalPosition = ball.transform.position.y;
            var enemyRacketOriginalPosition = enemyRacket.transform.position.y;

            yield return new WaitForSeconds(5f);

            Assert.IsTrue(ballOriginalPosition > ball.transform.position.y && enemyRacketOriginalPosition > enemyRacket.transform.position.y
                          || ballOriginalPosition < ball.transform.position.y && enemyRacketOriginalPosition < enemyRacket.transform.position.y);
        }

        [UnityTest]
        public IEnumerator BallShouldMoveAfterCountdown()
        {
            var ballOriginalPosition = ball.transform.position.y;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(ballOriginalPosition,ball.transform.position.y);

            countdown.time = 0;
            yield return new WaitForSeconds(3f);

            Assert.AreNotEqual(ballOriginalPosition, ball.transform.position.y);
        }
    }
}
