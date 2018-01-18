using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using CalculatorService.ServiceInterface;
using CalculatorService.ServiceModel;

namespace CalculatorService.Tests
{
    public class UnitTest
    {
        private readonly ServiceStackHost appHost;

        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<CalculatorServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();


        [Test]
        public void Can_Add_Two_Posted_Values()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = (AddResponse)service.Any(new Add { Addends = new int[] { 2, 3 } });

            Assert.That(response.Sum, Is.EqualTo(5));
        }

        [Test]
        public void Can_Add_Three_Values()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = (AddResponse)service.Any(new Add { Addends = new int[] { 2, 3, 7 } });

            Assert.That(response.Sum, Is.EqualTo(12));
        }

        [Test]
        public void Can_Substract_Values()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = (SubstractResponse)service.Any(new Substract { Minuend=10, Substrahend=5});

            Assert.That(response.Difference, Is.EqualTo(5));
        }

        [Test]
        public void Can_Multiply_Three_Values()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = (MultiplyResponse)service.Any(new Multiply { Factors = new int[] { 5, 6, 10 } });

            Assert.That(response.Product, Is.EqualTo(300));
        }

        [Test]
        public void Can_Divide_Values()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = (DivideResponse)service.Any(new Divide { Dividend=10,Divisor=3});

            Assert.That(response.Quotient, Is.EqualTo(3));
            Assert.That(response.Reminder, Is.EqualTo(1));
        }

        [Test]
        public void Can_SquareRoot()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = (SquareRootResponse)service.Any(new SquareRoot{ Number=4 });

            Assert.That(response.Square, Is.EqualTo(2));
        }
    }
}
