using NetArchTest.Rules;

namespace ArchitectureTests
{
    //TODO: Apply TemplateMethod Pattern here
    public class Tests
    {
        private const string DomainNamespace = "Shelfie.Domain";
        private const string ApplicationNamespace = "Shelfie.Application";
        private const string InfrastructureNamespace = "Shelfie.Infrastructure";
        private const string WebApiNamespace = "Shelfie.WebApi";
        private const string MappingNamespace = "Shelfie.Application.Mapping";


        [Test]
        public void Domain_ShoudNotHaveDependencyOnOtherProjects()
        {
            //Arrange
            var assembly = typeof(Shelfie.Domain.StaticResources.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                WebApiNamespace,
                MappingNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Test]
        public void Application_ShoudNotHaveDependencyOnOtherProjectsExceptDomain()
        {
            //Arrange
            var assembly = typeof(Shelfie.Application.StaticResources.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                InfrastructureNamespace,
                WebApiNamespace,
                MappingNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Test]
        public void Infrastructure_ShoudNotHaveDependencyOnOtherProjectsExceptApplicationAndDomain()
        {
            //Arrange
            var assembly = typeof(Shelfie.Application.StaticResources.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                WebApiNamespace,
                MappingNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}