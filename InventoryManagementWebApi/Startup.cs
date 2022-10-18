using BusinessLayer;
using InterfaceLayer;
using InterfaceLayer.Business;
using InterfaceLayer.JWTAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ModelLayer;
using System.Text;

namespace InventoryManagementWebApi
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
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.AddControllers();
            services.AddCors();

            //services.AddDbContext<InventoryMnagementDBContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var key = Configuration["JWT:Secret"];
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // ValidAudience = Configuration["JWT:ValidAudience"],
                    // ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            services.AddSingleton<IJWTAuth>(new JWTAuth(key, Configuration));
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryManagementWebApi", Version = "v1" });

                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddScoped<IContactLogic<Contact>, ContactLogic<Contact>>();
            services.AddScoped<IContactTypeLogic<ContactType>, ContactTypeLogic<ContactType>>();
            services.AddScoped<ICustomerTypeLogic<CustomerType>, CustomerTypeLogic<CustomerType>>();
            services.AddScoped<ICustomerMasterLogic<CustomerMaster>, CustomerMasterLogic<CustomerMaster>>();
            services.AddScoped<ILocationLogic<Location>, LocationLogic<Location>>();
            services.AddScoped<IProductCustomerUnitPriceLogic<ProductCustomerUnitPrice>, ProductCustomerUnitPriceLogic<ProductCustomerUnitPrice>>();
            services.AddScoped<IProductLogic<ProductInformation>, ProductLogic<ProductInformation>>();
            services.AddScoped<IProductSupplierUnitPriceLogic<ProductSupplierUnitPrice>, ProductSupplierUnitPriceLogic<ProductSupplierUnitPrice>>();
            services.AddScoped<IStoreInfoLogic<StoreInfo>, StoreInfoLogic<StoreInfo>>();
            services.AddScoped<IStoreProductLogic<StoreProduct>, StoreProductLogic<StoreProduct>>();
            services.AddScoped<ISupplierLogic<Supplier>, SupplierLogic<Supplier>>();
            services.AddScoped<IUserLogic<UserInfo>, UserLogic<UserInfo>>();
            services.AddScoped<IExcemptionsLogic<Excemptions>, ExcemptionsLogic<Excemptions>>();
            services.AddScoped<IOrderLogic<Order>, OrderLogic<Order>>();
            services.AddScoped<IOrderProductsLogic<OrderProducts>, OrderProductsLogic<OrderProducts>>();
            services.AddScoped<IOrderTemplateLogic<OrderTemplate>, OrderTemplateLogic<OrderTemplate>>();
            services.AddScoped<IOrderTemplateProductsLogic<OrderTemplateProducts>, OrderTemplateProductsLogic<OrderTemplateProducts>>();
            services.AddScoped<IRegionLogic<Region>, RegionLogic<Region>>();
            services.AddScoped<ICategoryLogic<Category>, CategoryLogic<Category>>();
            services.AddScoped<ICategoryCustomerLogic<CategoryCustomer>, CategoryCustomerLogic<CategoryCustomer>>();
            services.AddScoped<ICategoryProductLogic<CategoryProduct>, CategoryProductLogic<CategoryProduct>>();
            services.AddScoped<ICategoryStoreLogic<CategoryStore>, CategoryStoreLogic<CategoryStore>>();
            services.AddScoped<IStoreGroupDriverMappingLogic<StoreGroupDriverMapping>, StoreGroupDriverMappingLogic<StoreGroupDriverMapping>>();
            services.AddScoped<IStoreGroupStoreMappingLogic<StoreGroupStoreMapping>, StoreGroupStoreMappingLogic<StoreGroupStoreMapping>>();
            services.AddScoped<IRunLevelLogic<RunLevel>, RunLevelLogic<RunLevel>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryManagementWebApi v1");
                c.DefaultModelsExpandDepth(-1);
            });
            // app.UseMiddleware<CorsMiddleware>();

            // custom jwt auth middleware


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            app.UseMiddleware<JWTMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseMvc();
        }
    }
}
