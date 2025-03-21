var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DotNetDemoWebAPI>("dotnetdemowebapi");

builder.Build().Run();
