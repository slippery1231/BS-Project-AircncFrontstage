using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Services;
using Aircnc.FrontStage.Services.RoomOwner;
using Aircnc.FrontStage.Services.Guest;
using AircncFrontStage.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Aircnc.FrontStage.Services.Transaction;
using Aircnc.FrontStage.Services.Account.Interface;
using Aircnc.FrontStage.Services.Account;
using Aircnc.FrontStage.Services.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Aircnc.FrontStage.Services.PreOrders;

namespace Aircnc.FrontStage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //��Ʈw�`�J
            services.AddDbContext<AircncContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AircncContext"));

            });
            services.AddTransient<DBRepository, DBRepository>();
            services.AddTransient<HostListService, HostListService>();
            services.AddTransient<HostReservationService, HostReservationService>();
            services.AddTransient<HostHomePageService, HostHomePageService>();
            services.AddTransient<OrderService, OrderService>();
            services.AddTransient<RoomDetailService, RoomDetailService>();
            services.AddTransient<NavSearchService, NavSearchService>();
            services.AddTransient<TransactionService, TransactionService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<SearchRoomService, SearchRoomService>();
            services.AddTransient<AverageRoomPriceService, AverageRoomPriceService>();
            services.AddTransient<MailService, MailService>();
            services.AddTransient<CalendarService, CalendarService>();
            services.AddTransient<CreateRoomService, CreateRoomService>();
            services.AddTransient<SaveOrderService, SaveOrderService>();
            services.AddTransient<PreOrderService, PreOrderService>();

            services.AddHttpContextAccessor();
            services.AddTransient<HostRoomEditService, HostRoomEditService>();

            //�]�w���Ҥ覡
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //����
            app.UseAuthentication();
            app.UseAuthorization();
            //���
            app.UseCors();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Search Room",
                    pattern: "Rooms",
                    defaults: new { controller = "Search", action = "Search"});

                endpoints.MapControllerRoute(
                    name: "Room Detail",
                    pattern: "Detail",
                    defaults: new { controller = "RoomDetail", action = "RoomDetail" });

                endpoints.MapControllerRoute(
                    name: "Booking Room",
                    pattern: "Booking",
                    defaults: new { controller = "Booking", action = "Booking" });

                //endpoints.MapControllerRoute(
                //    name:"OrderList",
                //    pattern:"Order/OrderList/{id?}"
                //    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
