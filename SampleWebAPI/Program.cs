using Sample.Business.Logic;
using Sample.Business.Interface;
using Sample.Data.Logic;
using Sample.Data.Interface;
using Azure.Identity;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAzureClients(x=>{
x.AddBlobServiceClient(new Uri("https://imageblobstorage1.blob.core.windows.net/testblob"));
x.UseCredential(new DefaultAzureCredential());
});
//registers interfaces start
builder.Services.AddTransient<IBookBusiness,BookBusiness>();
builder.Services.AddTransient<IBookData,BookData>();
builder.Services.AddTransient<IImageBusiness,ImageBusiness>();
builder.Services.AddTransient<IImageData,ImageData>();
builder.Services.AddTransient<IDALBase,DALBase>();
//end
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
