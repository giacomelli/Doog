using NUnit.Framework;
using System;
using Rhino.Mocks;
using Snake.Framework.Behaviors;
using System.Collections.Generic;

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
            ctx.Expect(c => c.RemoveComponent(c1));
            ctx.Expect(c => c.RemoveComponent(c3));

            ctx.RemoveComponentsWithoutTag(("Tag2"));

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
    }
}
