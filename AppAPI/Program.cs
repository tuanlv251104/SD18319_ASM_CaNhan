//using AppAPI.IRepository;
//using AppAPI.Repositorys;

//namespace AppAPI
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddTransient<ISanPhamRepo, SanPhamRepo>();
            builder.Services.AddControllers();
            //builder.Services.AddSession();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseSession();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
//        }
//    }
//}