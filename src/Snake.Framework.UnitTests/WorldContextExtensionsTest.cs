using NUnit.Framework;
using System;
using Rhino.Mocks;
using Snake.Framework.Behaviors;
using System.Collections.Generic;
using Snake.Framework.Input;

namespace Snake.Framework.UnitTests
{
    [TestFixture]
    public class WorldContextExtensionsTest
    {
        [Test]
        public void RemoveComponentsWithoutTag_Tag_KeepOnlyComponentsWithTag()
        {
            var c1 = MockRepository.GenerateMock<IComponent>();
            c1.Expect(c => c.Tag).Return("Tag1");

            var c2 = MockRepository.GenerateMock<IComponent>();
            c2.Expect(c => c.Tag).Return("Tag2");

            var c3 = MockRepository.GenerateMock<IComponent>();
            c3.Expect(c => c.Tag).Return("Tag1");

            var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(c => c.Components).Return(new List<IComponent>(new IComponent[] {
                c1, c2, c3
            }));
			ctx.Expect(c => c.RemoveComponent(c1)).Repeat.Once();
			ctx.Expect(c => c.RemoveComponent(c2)).Repeat.Never();
			ctx.Expect(c => c.RemoveComponent(c3)).Repeat.Once();


			ctx.RemoveComponentsWithoutTag(("Tag2"));

            c1.VerifyAllExpectations();
            c2.VerifyAllExpectations();
            c3.VerifyAllExpectations();
            ctx.VerifyAllExpectations();
        }

		[Test]
		public void RemoveComponentsWithoutTag_Tags_KeepOnlyComponentsWithTags()
		{
			var c1 = MockRepository.GenerateMock<IComponent>();
			c1.Expect(c => c.Tag).Return("Tag1");

			var c2 = MockRepository.GenerateMock<IComponent>();
			c2.Expect(c => c.Tag).Return("Tag2");

			var c3 = MockRepository.GenerateMock<IComponent>();
			c3.Expect(c => c.Tag).Return("Tag1");

			var ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(c => c.Components).Return(new List<IComponent>(new IComponent[] {
				c1, c2, c3
			}));

			ctx.Expect(c => c.RemoveComponent(c1)).Repeat.Never();
			ctx.Expect(c => c.RemoveComponent(c2)).Repeat.Never();
			ctx.Expect(c => c.RemoveComponent(c3)).Repeat.Never();

			ctx.RemoveComponentsWithoutTag("Tag2", "Tag1");
          
			c1.VerifyAllExpectations();
			c2.VerifyAllExpectations();
			c3.VerifyAllExpectations();
			ctx.VerifyAllExpectations();
		}

		[Test]
		public void RemoveAllComponents_NoArgs_AllComponentsRemoved()
		{
			var c1 = MockRepository.GenerateMock<IComponent>();
			var c2 = MockRepository.GenerateMock<IComponent>();
			var c3 = MockRepository.GenerateMock<IComponent>();
		
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(c => c.Components).Return(new List<IComponent>(new IComponent[] {
				c1, c2, c3
			}));
			ctx.Expect(c => c.RemoveComponent(c1));
            ctx.Expect(c => c.RemoveComponent(c2));
			ctx.Expect(c => c.RemoveComponent(c3));

			ctx.RemoveAllComponents();

			c1.VerifyAllExpectations();
			c2.VerifyAllExpectations();
			c3.VerifyAllExpectations();
			ctx.VerifyAllExpectations();
		}

		[Test]
		public void OpenScene_SceneType_SceneOpened()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(c => c.OpenScene(Arg<NullScene>.Is.TypeOf));
			ctx.OpenScene<NullScene>();

            ctx.VerifyAllExpectations();
		}

		[Test]
		public void OpenScene_SceneNameAndSceneDoesNotExists_Exception()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
            var ex = Assert.Catch<ArgumentException>(delegate
            {
                ctx.OpenScene("InvalidScene");
            });

            Assert.AreEqual("Could not find a scene with name 'InvalidScene'", ex.Message);
		}

		[Test]
		public void OpenScene_SceneNameAndSceneExists_SceneOpened()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(c => c.OpenScene(Arg<NullScene>.Is.TypeOf));
			ctx.OpenScene("Snake.Framework.NullScene");

			ctx.VerifyAllExpectations();
		}

		[Test]
		public void OpenScene_SceneTypeAndKey_SceneOpenedByKey()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
            var input = MockRepository.GenerateMock<IInputSystem>();
            ctx.Expect(c => c.InputSystem).Return(input);
			ctx.Expect(c => c.OpenScene(Arg<NullScene>.Is.TypeOf));
			ctx.OpenScene<NullScene>(Keys.D1);
            input.Expect(i => i.IsKeyDown(Keys.D1)).Return(true);
            ctx.OpenScene<NullScene>(Keys.D1);
			ctx.VerifyAllExpectations();
		}
    }
}
