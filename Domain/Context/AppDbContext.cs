
using Hr_Management_final_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

             protected override void OnModelCreating(ModelBuilder builder)
    {
            // Apply configurations for entity

        //Attributes for Employee Table
        builder.Entity<Employee>().ToTable("Employee");
        builder.Entity<Employee>().HasKey(p => p.employeeId);
        builder.Entity<Employee>().Property(p => p.employeeId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Employee>().Property(p => p.employee_No).IsRequired().HasMaxLength(50);
        builder.Entity<Employee>().Property(p => p.employee_Name).IsRequired();
        builder.Entity<Employee>().Property(p => p.email).IsRequired();
        builder.Entity<Employee>().Property(p => p.dob).IsRequired();
        builder.Entity<Employee>().Property(p => p.nrc).IsRequired();
        builder.Entity<Employee>().Property(p => p.phone_no_work).IsRequired();  
        builder.Entity<Employee>().Property(p => p.phone_no_personal).IsRequired();  
        builder.Entity<Employee>().Property(p => p.gender).IsRequired();  
        builder.Entity<Employee>().Property(p => p.marital_status).IsRequired();  
        builder.Entity<Employee>().Property(p => p.nationality).IsRequired();  
        builder.Entity<Employee>().Property(p => p.religion).IsRequired();  
        builder.Entity<Employee>().Property(p => p.permanent_address).IsRequired();  
        builder.Entity<Employee>().Property(p => p.education_background).IsRequired(); 
        builder.Entity<Employee>().Property(p => p.addressId).IsRequired();  
        builder.Entity<Employee>().Property(p => p.joined_date).IsRequired(); 
        builder.Entity<Employee>().Property(p => p.employee_state).IsRequired();
        //Employee table join Leave table (Relationship one to many)  
        builder.Entity<Employee>().HasMany(e => e.leaves).WithOne(l => l.Employees).HasForeignKey(p => p.employee_id);
        //Employee table join Attendences table (Relationship one to many)
        builder.Entity<Employee>().HasMany(p => p.Attendences).WithOne(p => p.Employees).HasForeignKey(p => p.empId);
        //Employee table join EmployeeTraining table (Relationship one to many)
        builder.Entity<Employee>().HasMany(p =>p.EmployeeTrainings).WithOne(p =>p.Employees).HasForeignKey(p =>p.employee_id);
        //Employee table join Award_Punishment table (Relationship one to many)
        builder.Entity<Employee>().HasMany(p =>p.Award_Punishments).WithOne(p =>p.Employees).HasForeignKey(p =>p.employee_id);
        //Employee table join Absence table (Relationship one to many)
        builder.Entity<Employee>().HasMany(e => e.Absences).WithOne(l => l.Employees).HasForeignKey(p => p.employee_id);
        //Employee table join Performance table (Relationship one to many)
        builder.Entity<Employee>().HasMany(e => e.Performances).WithOne(l => l.Employee).HasForeignKey(p => p.employee_id);
        //Employee table join DutyRoster_Detail table (Relationship one to many)
        builder.Entity<Employee>().HasMany(e => e.DutyRosterDetails).WithOne(l => l.Employees).HasForeignKey(p => p.employee_id);

        builder.Entity<Employee>().HasMany(e => e.EmployeeRoles).WithOne(l => l.Employee).HasForeignKey(p => p.employee_id);

        //Attributes for Address Table
        builder.Entity<Address>().ToTable("Address");
        builder.Entity<Address>().HasKey(p => p.addId);
        builder.Entity<Address>().Property(p => p.addId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Address>().Property(p => p.line_1).IsRequired().HasMaxLength(30);
        builder.Entity<Address>().Property(p => p.line_2).IsRequired().HasMaxLength(30);
        builder.Entity<Address>().Property(p => p.region).IsRequired().HasMaxLength(30);
        builder.Entity<Address>().Property(p => p.country).IsRequired().HasMaxLength(30);
        //Address table join Employee table (Relationship one to many)
        builder.Entity<Address>().HasMany(e => e.Employees).WithOne(d => d.Addresses).HasForeignKey(p => p.addressId);
        //Address table join Branches table (Relationship one to many)
        builder.Entity<Address>().HasMany(e => e.Branches).WithOne(d => d.Addresses).HasForeignKey(p => p.addressId);
        //Address table join CV_Form table (Relationship one to many)
        builder.Entity<Address>().HasMany(p => p.CV_Forms).WithOne(p => p.Addresses).HasForeignKey(p => p.address_id);

         //Attributes for Leave Table
        builder.Entity<Leave>().ToTable("Leave");
        builder.Entity<Leave>().HasKey(p => p.id);
        builder.Entity<Leave>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Leave>().Property(p => p.Leave_type).IsRequired().HasMaxLength(50);
        builder.Entity<Leave>().Property(p => p.from_date).IsRequired();
        builder.Entity<Leave>().Property(p => p.to_date).IsRequired();
        //Attributes for EmployeeAttendence Table
        builder.Entity<EmployeeAttendence>().ToTable("EmployeeAttendence");
        builder.Entity<EmployeeAttendence>().HasKey(p => p.empAttendenceId);
        builder.Entity<EmployeeAttendence>().Property(p => p.empAttendenceId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EmployeeAttendence>().Property(p => p.attendence_Id).IsRequired();
        builder.Entity<EmployeeAttendence>().Property(p => p.location_Id).IsRequired();

         //Attributes for Department Table
        builder.Entity<Department>().ToTable("Department");
        builder.Entity<Department>().HasKey(p => p.dept_id);
        builder.Entity<Department>().Property(p => p.dept_id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Department>().Property(p => p.dept_name).IsRequired().HasMaxLength(50);
        builder.Entity<Department>().Property(p => p.priority).IsRequired().HasMaxLength(50);
        builder.Entity<Department>().Property(p => p.branch_id).IsRequired().HasMaxLength(50);
        builder.Entity<Department>().Property(p => p.phone_no).IsRequired().HasMaxLength(50);
        builder.Entity<Department>().Property(p => p.remark).IsRequired().HasMaxLength(50);
        //Authorized By NiNiWinMay
        //Department table join EmployeeRoles table (Relationship one to many)
        builder.Entity<Department>().HasMany(p => p.EmployeeRoles).WithOne(p => p.Department).HasForeignKey(p => p.department_id);

        //Attributes for Branch Table
        builder.Entity<Branch>().ToTable("Branchs");
        builder.Entity<Branch>().HasKey(p => p.Id);
        builder.Entity<Branch>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Branch>().Property(p => p.name).IsRequired();
        builder.Entity<Branch>().Property(p => p.phone_1).IsRequired();
        builder.Entity<Branch>().Property(p => p.phone_2).IsRequired();
        //Authorized By NiNiWinMay
        //Branch table join Departments table (Relationship one to many)
        builder.Entity<Branch>().HasMany(e => e.Departments).WithOne(d => d.Branches).HasForeignKey(p => p.branch_id);
        
        //Attributes for Attendence Table
        builder.Entity<Attendence>().ToTable("Attendences");
        builder.Entity<Attendence>().HasKey(p => p.attId);
        builder.Entity<Attendence>().Property(p => p.attId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Attendence>().Property(p => p.date).IsRequired();
        builder.Entity<Attendence>().Property(p => p.start_time).IsRequired();
        builder.Entity<Attendence>().Property(p => p.end_time).IsRequired();
        builder.Entity<Attendence>().Property(p => p.attendenceType).IsRequired().HasMaxLength(30);
        builder.Entity<Attendence>().Property(p => p.remark).IsRequired().HasMaxLength(30);
        //Attendence table join EmployeeAttendence table (Relationship one to many)
        builder.Entity<Attendence>().HasMany(e => e.EmployeeAttendences).WithOne(d => d.Attendences).HasForeignKey(p => p.attendence_Id);
        
        //Attributes for Location Table
        builder.Entity<Location>().ToTable("Locations");
        builder.Entity<Location>().HasKey(l=>l.locId);
        builder.Entity<Location>().Property(l=>l.locId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Location>().Property(l=>l.lotitude).IsRequired();
        builder.Entity<Location>().Property(l=>l.remark).IsRequired();
        //Locatin table join EmployeeAttendence table (Relationship one to many)
        builder.Entity<Location>().HasMany(e => e.EmployeeAttendences).WithOne(d => d.locations).HasForeignKey(p => p.location_Id);
        
        //Attributes for Employee_Training Table
        builder.Entity<Employee_training>().ToTable("Employee_training");
        // Set key for entity
        builder.Entity<Employee_training>().HasKey(p=>p.id);
        // Set configuration for columns
        builder.Entity<Employee_training>().Property(p=>p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Employee_training>().Property(p => p.from_date).IsRequired();
        builder.Entity<Employee_training>().Property(p => p.to_date).IsRequired();
        builder.Entity<Employee_training>().Property(p => p.remark).IsRequired();
          builder.Entity<Employee_training>().Property(p => p.employee_id).IsRequired();
        builder.Entity<Employee_training>().Property(p => p.trainingId).IsRequired().HasMaxLength(30);
  
         //Attributes for Training Table
        builder.Entity<Training>().ToTable("Training");
        // Set key for entity
        builder.Entity<Training>().HasKey(p=>p.Id);
        // Set configuration for columns
        builder.Entity<Training>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Training>().Property(p => p.training).IsRequired();
        builder.Entity<Training>().Property(p => p.duration).IsRequired().HasMaxLength(30);
        builder.Entity<Training>().Property(p => p.pre_requestive).IsRequired();
        builder.Entity<Training>().Property(p => p.remark).IsRequired().HasMaxLength(30);
        //Training table join Employee_Training table (Relationship one to many)
        builder.Entity<Training>().HasMany(p =>p.Employee_trainings).WithOne(p =>p.Trainings).HasForeignKey(p =>p.trainingId);

        //Attributes for Award_Punishment Table
        builder.Entity<Award_Punishment>().ToTable("Award_Punishment");
        builder.Entity<Award_Punishment>().HasKey(p => p.award_punishment_Id);
        builder.Entity<Award_Punishment>().Property(p => p.award_punishment_Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Award_Punishment>().Property(p => p.employee_id).IsRequired();
        builder.Entity<Award_Punishment>().Property(p => p.award_punishment).IsRequired().HasMaxLength(30);
        builder.Entity<Award_Punishment>().Property(p => p.date).IsRequired();
        builder.Entity<Award_Punishment>().Property(p => p.description).IsRequired();
        builder.Entity<Award_Punishment>().Property(p => p.remark).IsRequired();
        
         //Attributes for CV_Form Table
        builder.Entity<CV_Form>().ToTable("CV_Form");
        builder.Entity<CV_Form>().HasKey(p => p.id);
        builder.Entity<CV_Form>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CV_Form>().Property(p => p.announcement_id).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.date).IsRequired().HasMaxLength(50);
        builder.Entity<CV_Form>().Property(p => p.name).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.email).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.nrc).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.dob).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.nrc).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.ph_no_work).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.ph_no_personal).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.gender).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.marital_status).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.nationality).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.religion).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.permanent_address).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.qualification).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.address_id).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.joined_date).IsRequired();
        builder.Entity<CV_Form>().Property(p => p.status).IsRequired();
       
     //Attributes for Announcement Table
    builder.Entity<Announcement>().ToTable("Announcement");
    builder.Entity<Announcement>().HasKey(p => p.id);
    builder.Entity<Announcement>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Announcement>().Property(p => p.description).IsRequired();
    builder.Entity<Announcement>().Property(p => p.title).IsRequired().HasMaxLength(50);
    builder.Entity<Announcement>().Property(p => p.date).IsRequired();
    //Annocument table join CV_Form table (Relationship one to many)
    builder.Entity<Announcement>().HasMany(p => p.CV_Forms).WithOne(p => p.Announcement).HasForeignKey(p => p.announcement_id);
    //Authorized By NiNiWinMay(Table Joining -EmployeeRole)
     //Attributes for EmployeeRoles Table
    builder.Entity<EmployeeRoles>().ToTable("EmployeeRoles");
    builder.Entity<EmployeeRoles>().HasKey(p=>p.id);
    builder.Entity<EmployeeRoles>().Property(p=>p.id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<EmployeeRoles>().Property(p => p.start_date).IsRequired().HasMaxLength(30);
    builder.Entity<EmployeeRoles>().Property(p => p.end_date).IsRequired().HasMaxLength(30);
    builder.Entity<EmployeeRoles>().Property(p => p.remark).IsRequired().HasMaxLength(100);
 //Attributes for Role Table
    builder.Entity<Role>().ToTable("Role");
    builder.Entity<Role>().HasKey(p => p.Role_Id);
    builder.Entity<Role>().Property(p => p.Role_Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(30);
    builder.Entity<Role>().Property(p => p.Priority).IsRequired().HasMaxLength(30);
    builder.Entity<Role>().Property(p => p.Salary_range).IsRequired();
    builder.Entity<Role>().HasMany(p => p.EmployeeRole).WithOne(p => p.Role).HasForeignKey(p => p.roleid);

    //Atrrtibutes for Rank table
    builder.Entity<Rank>().ToTable("Rank");
    builder.Entity<Rank>().HasKey(p => p.Rank_Id);
    builder.Entity<Rank>().Property(p => p.Rank_Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Rank>().Property(p => p.Name).IsRequired().HasMaxLength(30);
    builder.Entity<Rank>().HasMany(p => p.EmployeeRole).WithOne(p => p.Ranks).HasForeignKey(p => p.rankId);

    //Role table join EmployeeRole table (Relationship one to many)
 //Attributes for ServicePerformance Table
    builder.Entity<ServicePerformance>().ToTable("ServicePerformance");
    builder.Entity<ServicePerformance>().HasKey(p => p.servicePerformanceId);
    builder.Entity<ServicePerformance>().Property(p => p.servicePerformanceId).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<ServicePerformance>().Property(p => p.work_done).IsRequired().HasMaxLength(30);
    builder.Entity<ServicePerformance>().Property(p => p.attendence_id).IsRequired().HasMaxLength(30);
    builder.Entity<ServicePerformance>().Property(p => p.remark).IsRequired().HasMaxLength(30);
    //ServicePerformance table join Attendence table (Relationship one to many)
    builder.Entity<Attendence>().HasMany(p => p.ServicePerformances).WithOne(p => p.Attendence).HasForeignKey(p => p.attendence_id);    
 //Attributes for Absence Table
    builder.Entity<Absence>().ToTable("Absence");
     builder.Entity<Absence>().HasKey(p => p.Id);
     builder.Entity<Absence>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
     builder.Entity<Absence>().Property(p => p.employee_id).IsRequired();
     builder.Entity<Absence>().Property(p => p.date).IsRequired();
     builder.Entity<Absence>().Property(p => p.rate_id).IsRequired();
 //Attributes for Rate Table
    builder.Entity<Rate>().ToTable("Rate");
    builder.Entity<Rate>().HasKey(p => p.rateId);
    builder.Entity<Rate>().Property(p => p.rateId).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Rate>().Property(p => p.Name).IsRequired();
    builder.Entity<Rate>().Property(p => p.rate).IsRequired();
    builder.Entity<Rate>().Property(p=>p.type).IsRequired();
    builder.Entity<Rate>().Property(p => p.description).IsRequired();
    //Rate table join Absence table (Relationship one to many)
    builder.Entity<Rate>().HasMany(e => e.Absences).WithOne(l => l.Rates).HasForeignKey(p => p.rate_id);
 //Attributes for Performance Table
     builder.Entity<Performance>().ToTable("Performance");
     builder.Entity<Performance>().HasKey(p => p.id);
     builder.Entity<Performance>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
     builder.Entity<Performance>().Property(p => p.employee_id).IsRequired();
     builder.Entity<Performance>().Property(p => p.reward_id).IsRequired();
     builder.Entity<Performance>().Property(p => p.task_id).IsRequired();
     builder.Entity<Performance>().Property(p => p.remark).IsRequired().HasMaxLength(50);
 //Attributes for Reward Table
      builder.Entity<Reward>().ToTable("Reward");
      builder.Entity<Reward>().HasKey(p => p.id);
      builder.Entity<Reward>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Reward>().Property(p => p.name).IsRequired().HasMaxLength(50);
      builder.Entity<Reward>().Property(p => p.qty).IsRequired();
      builder.Entity<Reward>().Property(p => p.payment).IsRequired().HasMaxLength(50);
      builder.Entity<Reward>().Property(p => p.remark).IsRequired().HasMaxLength(50);
      //Reward table join Performance table (Relationship one to many)
      builder.Entity<Reward>().HasMany(p => p.performance).WithOne(p => p.Reward).HasForeignKey(p => p.reward_id);
 //Attributes for TaskedTable
      builder.Entity<Tasked>().ToTable("Tasked");
      builder.Entity<Tasked>().HasKey(p => p.Id);
      builder.Entity<Tasked>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Tasked>().Property(p => p.Name).IsRequired().HasMaxLength(50);
      builder.Entity<Tasked>().Property(p => p.Start_Time).IsRequired().HasMaxLength(50);
      builder.Entity<Tasked>().Property(p => p.End_Time).IsRequired().HasMaxLength(50);
      builder.Entity<Tasked>().Property(p => p.Status).IsRequired().HasMaxLength(50);
      builder.Entity<Tasked>().Property(p => p.Remark).IsRequired().HasMaxLength(50);
      //Tasked table join Performance table (Relationship one to many)
      builder.Entity<Tasked>().HasMany(p => p.performance).WithOne(p => p.Task).HasForeignKey(p => p.task_id);
 //Attributes for Product_Performance Table
    builder.Entity< Product_Performance>().ToTable("Product_Performance");
    builder.Entity< Product_Performance>().HasKey(p=>p.id);
    builder.Entity< Product_Performance>().Property(p=>p.id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity< Product_Performance>().Property(p => p.unit_id).IsRequired();
    builder.Entity< Product_Performance>().Property(p => p.finished_goods).IsRequired().HasMaxLength(30);
    builder.Entity< Product_Performance>().Property(p => p.attendence_id).IsRequired();
    builder.Entity< Product_Performance>().Property(p => p.duty_roster_id).IsRequired();
    //Product Performance table join Attendence table (Relationship one to many)
    builder.Entity<Attendence>().HasMany(p => p.Product_Performances).WithOne(p => p.Attendence).HasForeignKey(p => p.attendence_id);
    //Product Performance table join DutyRoster table (Relationship one to many)
    builder.Entity<DutyRoster>().HasMany(p => p.Product_Performances).WithOne(p => p.DutyRoster).HasForeignKey(p => p.duty_roster_id);
   //Attributes for Shift Table
   builder.Entity<Shift> ().ToTable ("Shifts");
   builder.Entity<Shift> ().HasKey (p => p.Id);
   builder.Entity<Shift> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd ();
   builder.Entity<Shift> ().Property (p => p.Name).IsRequired ().HasMaxLength (250);
   builder.Entity<Shift> ().Property (p => p.Start_Time).IsRequired ().HasMaxLength (250);
   builder.Entity<Shift> ().Property (p => p.End_Time).IsRequired ().HasMaxLength (250);
   //Shift table join DutyRoster table (Relationship one to many)
   builder.Entity<Shift> ().HasMany (p => p.DutyRosters).WithOne (p => p.Shift).HasForeignKey (p => p.Shift_Id);
  //Attributes for DutyRoster Table
    builder.Entity<DutyRoster> ().ToTable ("DutyRoster");
    builder.Entity<DutyRoster> ().HasKey (p => p.Id);
    builder.Entity<DutyRoster> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd ();
    builder.Entity<DutyRoster> ().Property (p => p.From_Date).IsRequired ().HasMaxLength (250);
    builder.Entity<DutyRoster> ().Property (p => p.To_Date).IsRequired ().HasMaxLength (250);
    //DutyRoster table join DutyRoster Detail table (Relationship one to many)
     builder.Entity<DutyRoster> ().HasMany (p => p.DutyRosterDetails).WithOne (p => p.DutyRosters).HasForeignKey (p => p.dutyRoster_id);
 
 //Attributes for DutyRosterDetai Table
     builder.Entity<DutyRosterDetail>().ToTable("DutyRosterDetail");
    builder.Entity<DutyRosterDetail>().HasKey(p => p. dutyRosterDetail_id);
     builder.Entity<DutyRosterDetail>().Property(p => p. dutyRosterDetail_id).IsRequired ().ValueGeneratedOnAdd ();
    builder.Entity<DutyRosterDetail>().Property(p => p.dutyRoster_id).IsRequired ().HasMaxLength (250);
    builder.Entity<DutyRosterDetail>().Property(p => p.employee_id).IsRequired ().HasMaxLength (250);
 //Attributes for Point Table
      builder.Entity<Point> ().ToTable ("Points");
      builder.Entity<Point> ().HasKey (p => p.Id);
      builder.Entity<Point> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd ();
      builder.Entity<Point> ().Property (p => p.Name).IsRequired ().HasMaxLength (250);
      builder.Entity<Point> ().Property (p => p.Price).IsRequired ().HasMaxLength (250);
      builder.Entity<Point> ().Property (p => p.Remark).IsRequired ().HasMaxLength (250);
      builder.Entity<Point>().HasMany(p => p.Product_Performances).WithOne(p => p.Point).HasForeignKey(p => p.unit_id);
 //Attributes for Rule Table
      builder.Entity<Rule>().ToTable("Rules");
      builder.Entity<Rule>().HasKey(p => p.Rule_Id);
      builder.Entity<Rule>().Property(p => p.Rule_Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Rule>().Property(p => p.Rule_no).IsRequired();
      builder.Entity<Rule>().Property(p => p.Description).IsRequired().HasMaxLength(100);

       builder.Entity<User>().ToTable("User");
        builder.Entity<User>().HasKey(p => p.id);
        builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.firstName).IsRequired();
        builder.Entity<User>().Property(p => p.lastName).IsRequired();
         builder.Entity<User>().Property(p => p.userName).IsRequired();
        builder.Entity<User>().Property(p => p.email).IsRequired();
        builder.Entity<User>().Property(p => p.password).IsRequired();
        builder.Entity<User>().Property(p => p.phone).IsRequired();
        builder.Entity<User>().Property(p => p.position).IsRequired();
      //Attributes for Township Table
        builder.Entity<Township>().ToTable("Township");
        builder.Entity<Township>().HasKey(p => p.townshipId);
        builder.Entity<Township>().Property(p => p.townshipId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Township>().Property(p=>p.Name).IsRequired();
        builder.Entity<Township>().Property(p=>p.city_Id).IsRequired();
        builder.Entity<Township>().HasMany(p => p.Address).WithOne(p => p.Township).HasForeignKey(p => p.township_Id);

//Attributes for City Table
        builder.Entity<City>().ToTable("City");
        builder.Entity<City>().HasKey(p => p.cityId);
        builder.Entity<City>().Property(p => p.cityId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<City>().Property(p=>p.Name).IsRequired();
        builder.Entity<City>().HasMany(p => p.Township).WithOne(p => p.city).HasForeignKey(p => p.city_Id);




      


    base.OnModelCreating(builder);


    }   
         //build table employee in Database
        public DbSet<Employee> Employees{get;set;}
        //build table EmployeeAttendence in Database
        public DbSet<EmployeeAttendence> EmployeeAttendences {get;set;}
        //build table Department in Database
        public DbSet<Department> Departments{get;set;}
         //build table Address in Database
        public DbSet<Address> Addresses {get;set;}
        public DbSet<Leave> Leave{get;set;}
        public DbSet<Branch> Branchs {get;set;}
        public DbSet<Attendence> Attendences {get;set;}
        public DbSet<Location> Locations {get;set;}
        public DbSet<Employee_training> Employee_trainings { get; set; }
        public DbSet<Training> Trainings{get;set;}
        public DbSet<Award_Punishment> Award_Punishment {get;set;}
         public DbSet <Announcement> Announcement {get; set; }
        //actually work with cv_form database
         public DbSet<CV_Form> CV_Forms {get;set;}
        public DbSet<EmployeeRoles> EmployeeRole { get; set; }
        public DbSet<Role> Roles { get; set; } 

       public DbSet<ServicePerformance> ServicePerformances{ get; set; } 

        public DbSet<Absence> Absences {get;set;}

         public DbSet<Rate> Rates{get;set;}
         public DbSet<Performance> Performance { get; set; }
        public DbSet<Reward> Reward { get; set; }
        public DbSet<Tasked> Tasked { get; set; }

        public DbSet<Product_Performance> Product_Performances{ get; set; }

        public DbSet<Shift> Shifts { get; set; }
       public DbSet<DutyRoster> DutyRoster { get; set; }
       public DbSet<DutyRosterDetail> DutyRosterDetail{get;set;}

        public DbSet<Point> Points { get; set; }
         public DbSet<Rule> Rules {get;set;}

         public DbSet<User> Users {get;set;}
        public DbSet<Rank> Ranks {get;set;}
        public DbSet<Township> Townships {get;set;}
        public DbSet<City> Cities {get;set;}
}
    
    }
