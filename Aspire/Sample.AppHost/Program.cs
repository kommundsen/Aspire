var builder = DistributedApplication.CreateBuilder(args);

var sql = builder
    .AddSqlServer("sql")
    .WithDataVolume();

var db = sql.AddDatabase("db");

var api = builder
    .AddProject<Projects.Sample_Api>("api")
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WaitFor(db);

var web = builder
    .AddViteApp("web", "../Sample.Web", "npm")
    .WithExternalHttpEndpoints()
    .WithReference(api)
    .WaitFor(api);


builder.Build().Run();
