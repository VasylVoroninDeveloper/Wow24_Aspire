var builder = DistributedApplication.CreateBuilder(args);

var crmApiService = builder.AddProject<Projects.CRM_ApiService>("crm-apiservice");

builder.AddProject<Projects.Wow24_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(crmApiService)
    .WaitFor(crmApiService);

builder.AddProject<Projects.CXnone_ApiService>("cxnone-apiservice");

builder.Build().Run();
