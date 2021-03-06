using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Application.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using AnnotationValidator.Interface;
using Domain.Entities;
using Infrastructure.ValidationModel;
using Shared.Database;
using System.Text.Json.Serialization;

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
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBusinessBondService, BusinessBondService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IResumeService, ResumeService>();
            services.AddTransient<ICandidateAnnouncementService, CandidateAnnouncementService>();

            services.AddTransient<IEntityValidationModel<Announcement>, AnnouncementValidationModel>();
            services.AddTransient<IEntityValidationModel<BusinessBond>, BusinessBondValidationModel>();
            services.AddTransient<IEntityValidationModel<Candidate>, CandidateValidationModel>();
            services.AddTransient<IEntityValidationModel<Company>, CompanyValidationModel>();
            services.AddTransient<IEntityValidationModel<Course>, CourseValidationModel>();
            services.AddTransient<IEntityValidationModel<Education>, EducationValidationModel>();
            services.AddTransient<IEntityValidationModel<Resume>, ResumeValidationModel>();
            services.AddTransient<IEntityValidationModel<CandidateAnnouncement>, CandidateAnnouncementValdiationModel>();
            services.AddTransient<IEntityValidationModel<User>, UserValidationModel>();

            services.AddDbContext<MainContext>(opt => opt.UseSqlServer(SqlDataBase.CONNECTION_STRING));

            services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class ResumeValidationModel : IEntityValidationModel<Resume>
    {
    }

    public class EducationValidationModel : IEntityValidationModel<Education>
    {
    }
}
