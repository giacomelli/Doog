using NSubstitute;
using NUnit.Framework;
using Snake;
using System;
using System.Reflection;

namespace Doog.Tests.Infrastructure.Runner
{
    [TestFixture]
    public class GameActivatorTest
    {
        private static Assembly _gameAssembly = typeof(SnakeGame).Assembly;

        [Test]
        public void CreateInstance_NoWorldImplementation_Exception()
        {
            var actual = Assert.Catch<InvalidOperationException>(() =>
            {
                GameActivator.CreateInstance(typeof(GameActivatorTest).Assembly);
            });

            Assert.AreEqual("Could not find a class that inherits from Doog.World class.", actual.Message);
        }

        [Test]
        public void CreateInstance_WorldImplementation_World()
        {
            var actual = GameActivator.CreateInstance(_gameAssembly);
            Assert.IsTrue(actual is World);
        }

        [Test]
        public void Config_DebugEnabled_WorldStatsConsoleCreated()
        {
            var world = CreateWorld();
            GameActivator.Config(world, new string[] { "debug-enabled" });
            Assert.IsNotNull(world.Components.GetOne<WorldStatsConsole>());
        }

        [Test]
        public void Config_NoLogArgument_NullLogSystem()
        {
            var world = CreateWorld();
            GameActivator.Config(world, new string[0]);
            Assert.IsTrue(world.LogSystem is NullLogSystem);
            Assert.IsNull(world.Components.GetOne<WorldStatsConsole>());
        }

        [Test]
        public void Config_FileLog_FileLogSystem()
        {
            var world = CreateWorld();
            GameActivator.Config(world, new string[] { "file-log" });
            Assert.IsTrue(world.LogSystem is FileLogSystem);
        }

        [Test]
        public void Config_InGameLog_InGameLogSystem()
        {
            var world = CreateWorld();
            GameActivator.Config(world, new string[] { "ingame-log" });
            Assert.IsTrue(world.LogSystem is InGameLogSystem);
        }

        [Test]
        public void Config_MultipleArgs_MultipleSystems()
        {
            var world = CreateWorld();
            GameActivator.Config(world, new string[] { "debug-enabled", "ingame-log" });
            Assert.IsTrue(world.LogSystem is InGameLogSystem);
            Assert.IsNotNull(world.Components.GetOne<WorldStatsConsole>());
        }

        private World CreateWorld()
        {
            var world = GameActivator.CreateInstance(_gameAssembly);
            world.Initialize(
                Substitute.For<IGraphicSystem>(),
                Substitute.For<IPhysicSystem>(),
                Substitute.For<ITextSystem>(),
                Substitute.For<IInputSystem>(),
                () => { });

            return world;
        }
    }
}
