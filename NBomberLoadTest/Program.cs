using NBomber.Contracts.Stats;
using NBomber.CSharp; //utilizando o NBombet

using var httpClient = new HttpClient(); //criando client

var scenario = Scenario.Create("Meu Primeiro Teste Carga", async context =>
{
    var response = await httpClient.GetAsync("https://google.com.br");

    return response.IsSuccessStatusCode
        ? Response.Ok()
        : Response.Fail();
});

NBomberRunner
  .RegisterScenarios(scenario)
  .WithReportFileName("NBomber")
  .WithReportFolder("NBomber")
  .WithReportFormats(ReportFormat.Txt, ReportFormat.Csv, ReportFormat.Html, ReportFormat.Md)
  .Run();