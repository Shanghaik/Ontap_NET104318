namespace Ontap_NET104
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(600); // Set thời gian timeout của session là 600 giây
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); // Khai báo sử dụng Session 
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute( // Set mặc định khi chạy app
                name: "default",
                pattern: "{controller=Account}/{action=Login}");

            app.Run();
        }
    }
}