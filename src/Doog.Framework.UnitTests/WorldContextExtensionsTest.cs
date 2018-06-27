using NUnit.Framework;
using System;
using NSubstitute;
using System.Collections.Generic;

namespace Doog.Framework.UnitTests
{
    [TestFixture]
    public class WorldContextExtensionsTest
    {
        [Test]
        public void RemoveComponentsWithoutTag_Tag_KeepOnlyComponentsWithTag()
        {
            var c1 = Substitute.For<IComponent>();
            c1.Tag.Returns("Tag1");

            var c2 = Substitute.For<IComponent>();
            c2.Tag.Returns("Tag2");

            var c3 = Substitute.For<IComponent>();
            c3.Tag.Returns("Tag1");

            var ctx = Substitute.For<IWorldContext>();
            ctx.Components.Returns(new List<IComponent>(new IComponent[] {
                c1, c2, c3
            }));
			
			ctx.RemoveComponentsWithoutTag(("Tag2"));

            ctx.Received(1).RemoveComponent(c1);
            ctx.Received(0).RemoveComponent(c2);
            ctx.Received(1).RemoveComponent(c3);
        }

		[Test]
		public void RemoveComponentsWithoutTag_Tags_KeepOnlyComponentsWithTags()
		{
            var c1 = Substitute.For<IComponent>();
            c1.Tag.Returns("Tag1");

            var c2 = Substitute.For<IComponent>();
            c2.Tag.Returns("Tag2");

            var c3 = Substitute.For<IComponent>();
            c3.Tag.Returns("Tag1");

            var ctx = Substitute.For<IWorldContext>();
			ctx.Components.Returns(new List<IComponent>(new IComponent[] {
				c1, c2, c3
			}));

			ctx.RemoveComponentsWithoutTag("Tag2", "Tag1");

            ctx.Received(0).RemoveComponent(c1);
            ctx.Received(0).RemoveComponent(c2);
            ctx.Received(0).RemoveComponent(c3);
        }

		[Test]
		public void RemoveAllComponents_NoArgs_AllComponentsRemoved()
		{
			var c1 = Substitute.For<IComponent>();
			var c2 = Substitute.For<IComponent>();
			var c3 = Substitute.For<IComponent>();
		
			var ctx = Substitute.For<IWorldContext>();
            ctx.Components.Returns(new List<IComponent>(new IComponent[] {
                c1, c2, c3
            }));
          
			ctx.RemoveAllComponents();

            ctx.Received(1).RemoveComponent(c1);
            ctx.Received(1).RemoveComponent(c2);
            ctx.Received(1).RemoveComponent(c3);
        }

		[Test]
		public void OpenScene_SceneType_SceneOpened()
		{
			var ctx = Substitute.For<IWorldContext>();
         	ctx.OpenScene<NullScene>();

            ctx.Received().OpenScene(Arg.Any<NullScene>());
        }

		[Test]
		public void OpenScene_SceneNameAndSceneDoesNotExists_Exception()
		{
			var ctx = Substitute.For<IWorldContext>();
            var ex = Assert.Catch<ArgumentException>(delegate
            {
                ctx.OpenScene("InvalidScene");
            });

            Assert.AreEqual("Could not find a scene with name 'InvalidScene'", ex.Message);
		}

		[Test]
		public void OpenScene_SceneNameAndSceneExists_SceneOpened()
		{
			var ctx = Substitute.For<IWorldContext>();
			ctx.OpenScene("Doog.Framework.NullScene");

            ctx.Received().OpenScene(Arg.Any<NullScene>());
        }

		[Test]
		public void OpenScene_SceneTypeAndKey_SceneOpenedByKey()
		{
			var ctx = Substitute.For<IWorldContext>();
            var input = Substitute.For<IInputSystem>();
            ctx.InputSystem.Returns(input);

            ctx.OpenScene<NullScene>(Keys.D1);
            input.IsKeyDown(Keys.D1).Returns(true);
            ctx.OpenScene<NullScene>(Keys.D1);

            ctx.Received(1).OpenScene(Arg.Any<NullScene>());
        }
    }
}