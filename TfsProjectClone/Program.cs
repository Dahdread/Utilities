using System;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace TfsProjectClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessToken = args[0];
            var buildDef = int.Parse(args[1]);
            var sourceProject = args[2];
            var destinationProject = args[3];

            CloneBuild(buildDef, accessToken, sourceProject, destinationProject);
        }

        private static void CloneBuild(int buildDef, string accessToken, string sourceProject, string destinationProject)
        {
             var buildClient = CreateClient(accessToken);

            var definition = GetBuildDefinition(buildDef, sourceProject, buildClient);

            definition.Name = definition.Name + "Clone";
            definition.Project = null;
            
            var ress = buildClient.CreateDefinitionAsync(definition, destinationProject);
            ress.Wait();
            var res = ress.Result;

        }

        private static BuildDefinition GetBuildDefinition(int buildDef, string sourceProject, BuildHttpClient buildClient)
        {
            var definitionAsync = buildClient.GetDefinitionAsync(sourceProject, buildDef);
            definitionAsync.Wait();
            var definition = (BuildDefinition) definitionAsync.Result;
            return definition;
        }

        private static BuildHttpClient CreateClient(string accessToken)
        {
            var collectionUri = new Uri("https://riskfirst.visualstudio.com/DefaultCollection", UriKind.Absolute);
            var cred = new VssBasicCredential(string.Empty, accessToken);
            var buildClient = new BuildHttpClient(collectionUri, cred);
            return buildClient;
        }
    }
}
