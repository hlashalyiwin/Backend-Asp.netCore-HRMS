using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeRole;
using HR_MANAGEMENT.Domain.Services;
using HR_MANAGEMENT.IServices;
using HR_MANAGEMENT.IServicess;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.IServices;
using Hr_Management_final_api.Domain.Repositories;
using Hr_Management_final_api.Domain.Services;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServices;
using Hr_Management_final_api.IServicess;
using HR1.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hr_Management_final_api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //  services.AddDbContext<AppDbContext>(options => {
            //     options.UseInMemoryDatabase("Hr_Management_api");
            // });
            services.AddDbContext<AppDbContext>(options => options
            .UseMySql(Configuration["HrManagementData:HrManagementConnectionStrings"]));
             services.AddCors(c =>  
            c.AddPolicy("Global.CORS_ALLOW_ALL_POLICY_NAME", 
              builder=> { builder.AllowAnyOrigin()
                           .WithMethods("GET","PUT","POST","DELETE")
                       .AllowAnyHeader();
        
            } ) ); 
            
           services.AddScoped<IEmployeeService,EmployeeService>();
           services.AddScoped<IEmployeeRepository,EmployeeRepository>();

           services.AddScoped<IEmployeeAttendenceService , EmployeeAttendenceService>();
           services.AddScoped<IEmployeeAttendenceRepository , EmployeeAttendenceRepository>();

           services.AddScoped<IDepartmentService,DepartmentService>();
           services.AddScoped<IDepartmentRepository,DepartmentRepository>();

              
           services.AddScoped<IAddressService,AddressService>();
           services.AddScoped<IAddressRepository,AddressRepository>();

            services.AddScoped<ILeaveService,LeaveService>();
            services.AddScoped<ILeaveRepository,LeaveRepository>();

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchService, BranchService>();

            services.AddScoped<IAttendenceService,AttendenceService>();
            services.AddScoped<IAttendenceRepository,AttendenceRepository>();

            services.AddScoped<ILocationService,LocationService>();
            services.AddScoped<ILocationRepositories,LocationRepository>();

            services.AddScoped<IEmployee_trainingService, Employee_trainingServie>();
            services.AddScoped<IEmployee_trainingRepository, Employee_trainingRepository>();

            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();

            services.AddScoped<IAward_PunishmentRepository, Award_PunishmentRepository>();
            services.AddScoped<IAward_PunishmentService, Award_PunishmentService>();

            services.AddScoped<ICV_FormService, CV_FormService>();
            services.AddScoped<ICV_FormRepository,CV_FormRepository>();

            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

            services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();
            services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            
            services.AddScoped<IServicePerformanceService, ServicePerfornmanceService>();
            services.AddScoped<IServicePerformanceRepository, ServicePerformanceRepository>();

            services.AddScoped<IAbsenceService, AbsenceService>();
            services.AddScoped<IAbsenceRepository, AbsenceRepository>();

            services.AddScoped<IRateService,RateService>();
            services.AddScoped<IRateRepository,RateRepository>();
            
            services.AddScoped<IPerformanceService, PerformanceService>();
            services.AddScoped<IPerformanceRepository, PerformanceRepository>();

            services.AddScoped<IRewardService, RewardService>();
            services.AddScoped<IRewardRepository, RewardRepository>();

            services.AddScoped<ITaskedService,TaskedService>();
            services.AddScoped<ITaskedRepository,TaskedRepository>();
            
            services.AddScoped<IProductService,Product_Service>();
            services.AddScoped<IProduct_Performance_Repository,Product_Performance_Repository>();

            services.AddScoped<IShiftService, ShiftService> ();
            services.AddScoped<IShiftRepository, ShiftRepository> ();

             services.AddScoped<IDutyRosterService, DutyRosterService> ();
             services.AddScoped<IDutyRosterRepository, DutyRosterRepository> ();

             services.AddScoped<IDutyRosterDetailService, DutyRosterDetailService> ();
             services.AddScoped<IDutyRosterDetailRepository, DutyRosterDetailRepository> ();

            services.AddScoped<IPointRepository, PointRepository> ();
            services.AddScoped<IPointService, PointService> ();

            services.AddScoped<IRuleService,RuleService>();
            services.AddScoped<IRuleRepository,RuleRepository>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,UserRepository>();

            services.AddScoped<ICityService,CityServices>();
            services.AddScoped<ICityRepository,CityRepository>();

            services.AddScoped<ITownshipService,TownshipService>();
            services.AddScoped<ITownshipRepository,TownshipRepository>();

            services.AddScoped<IRankService,RankService>();
            services.AddScoped<IRankRepository,RankRepository>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
              app.UseCors("Global.CORS_ALLOW_ALL_POLICY_NAME");  

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
