
using AutoMapper;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.Resource;
using Hr_Management_final_api.Domain.Resources;

namespace Hr_Management_final_api.Domain.Mapping
 {// using Profile for View Table
     public class ModelToResourceProfile : Profile
     {
          public ModelToResourceProfile()
         {//change model to resource
          
             CreateMap<Employee, EmployeeResource>();   
             CreateMap<Department, DepartmentResource>();
             CreateMap<Address, AddressResource>();
             CreateMap<Leave, LeaveResource>();
             CreateMap<Branch, BranchResource>();
             CreateMap<Attendence,AttendenceResource>();
             CreateMap<EmployeeAttendence,EmployeeAttendenceResource>();
             CreateMap<Location,LocationResource>();
             CreateMap<Training,TrainingResource>();
             CreateMap<Employee_training,Employee_trainingResource>();
             CreateMap<Award_Punishment, Award_PunishmentResource>();
             CreateMap<CV_Form, CV_FormResource>();
             CreateMap<Announcement, AnnouncementResource>();
             CreateMap<EmployeeRoles, EmployeeRoleResource>();
             CreateMap<Role, RoleResource>();
             CreateMap<ServicePerformance, ServicePerformanceResource>();
             CreateMap<Absence, AbsenceResource>(); 
             CreateMap<Rate, RateResource>(); 
             CreateMap<Performance, PerformanceResource>();
             CreateMap<Tasked, TaskedResource>(); 
              CreateMap<Reward, RewardResource>(); 
             CreateMap<Product_Performance, ProductPerformanceResource>();
             CreateMap<Shift, ShiftResource> ();
             CreateMap<DutyRoster, DutyRosterResource> ();
             CreateMap<DutyRosterDetail, DutyRosterDetailResource> ();
             CreateMap<Point, PointResource> ();
             CreateMap<Rule, RuleResource>();
              CreateMap<User, UserResource>();
              CreateMap<Rank, RankResource>();
              CreateMap<City, CityResource>();
              CreateMap<Township,TownShipResourse>();




          
             
        }
     }
 }