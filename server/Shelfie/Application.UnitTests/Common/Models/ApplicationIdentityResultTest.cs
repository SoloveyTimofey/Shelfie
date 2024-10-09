using Shelfie.Application.Common.Models;

namespace Application.UnitTests.Common.Models
{
    public class ApplicationIdentityResultTest
    {
        [Test]
        public void ContainsErrors_SucceededFalse()
        {
            //Assign
            var applicationIdentityResult = new ApplicationIdentityResult
            {
                Errors =
                {
                    "First Error",
                    "Second Error"
                }
            };

            //Act & Assert
            Assert.IsFalse(applicationIdentityResult.Succeeded);
        }

        [Test]
        public void DoesNotContainErrors_SucceededTrue()
        {
            //Assign
            var applicationIdentityResult = new ApplicationIdentityResult();

            //Act & Assert
            Assert.IsTrue(applicationIdentityResult.Succeeded);
        }
    }
}
