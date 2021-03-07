using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Encyption;

namespace WebAPI
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
            services.AddControllers();
            //services.AddSingleton<ICarService,CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();
            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();
            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();
            services.AddCors(options=>
            {
                options.AddPolicy("AllowOrigin", 
                    builder => builder.WithOrigins("http://localhost:3000"));//bu linkten istek gelirse cevap ver
            });
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//appsettings.jsondan gerekli bölümü bizim ürettiðimiz TokenOptions türünde aldýk
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//JwtBearerDefaults .net core sürümüne göre yüklenir
                .AddJwtBearer(options => //ayarlarý burada vericez.
            {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,//Issuer bilgisi doðrulansýn mý? evet , issuerdan token verildiðinde bilginin geri gelmesi için bu gerekli
                    ValidateAudience = true, 
                    ValidateLifetime = true,//Token'ýn yaþam ömrü dikkate alýnsýn mý? evet (bizde 10 dakika) 
                    ValidIssuer = tokenOptions.Issuer,//yukarýda çektiðimiz deðiþkenden geliyor
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,//anahtarda kontrol edilsin mi?
                    IssuerSigningKey=SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)//anahtarda helperdan geldi
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder=>builder.WithOrigins("http://localhost:3000").AllowAnyHeader());//bu linkten gelen herhangi bir isteðe cevap ver "AllowAnyHeader"

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); //sýralarý önemli 

            app.UseAuthorization();           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
