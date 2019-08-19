using AutoMapper;
using Hr_Management_final_api.Domain.SaveResources;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Mapping
{// using Profile for View Table
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {    //change resource to model
            CreateMap<SaveEmployeeResource, Employee>();
            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<SaveAddressResource, Address>();
            CreateMap<SaveLeaveResource, Leave>();
            CreateMap<SaveBranchResource, Branch>();
            CreateMap<SaveAttendenceResource,Attendence>();
            CreateMap<SaveEmployeeAttendenceResource,EmployeeAttendence>();
            CreateMap<SaveLocationResources,Location>();
            CreateMap<SaveTrainingResource,Training>();
            CreateMap<SaveEmployee_trainingResource,Employee_training>();
            CreateMap<SaveAward_PunishmentResource, Award_Punishment>();
            CreateMap<SaveCV_FormResource, CV_Form>();
            CreateMap<SaveAnnouncementResource, Announcement>();
            CreateMap<SaveEmployeeRoleResource, EmployeeRoles>();
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveAnnouncementResource, ServicePerformance>();
            CreateMap<SaveAbsenceResource, Absence>();
            CreateMap<SaveRateResource, Rate>();
            CreateMap<SavePerformanceResource, Performance>();
            CreateMap<SaveTaskedResource, Tasked>();
            CreateMap<SaveRewardResource, Reward>();
            CreateMap<SaveProductPerformanceResource, Product_Performance>();
            CreateMap<SaveShiftResource, Shift> ();
            CreateMap<SaveDutyRosterResource, DutyRoster> ();
            CreateMap<SaveDutyRosterDetailResource, DutyRosterDetail> ();
            CreateMap<SavePointResource, Point> ();
            CreateMap<SaveRuleResource, Rule>(); 
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveRankResource, Rank>(); 
            CreateMap<SaveCityResource, City>();  
            CreateMap<SaveTownshipResource,Township>();
         

         }
    }
}