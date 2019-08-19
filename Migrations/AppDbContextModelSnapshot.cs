﻿// <auto-generated />
using System;
using Hr_Management_final_api.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hr_Management_final_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("date");

                    b.Property<int>("employee_id");

                    b.Property<int>("rate_id");

                    b.HasKey("Id");

                    b.HasIndex("employee_id");

                    b.HasIndex("rate_id");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Address", b =>
                {
                    b.Property<int>("addId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("line_1")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("line_2")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("region")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("township")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("addId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Announcement", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("date")
                        .IsRequired();

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("Announcement");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Attendence", b =>
                {
                    b.Property<int>("attId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("attendenceType")
                        .HasMaxLength(30);

                    b.Property<DateTime>("date");

                    b.Property<int?>("empId");

                    b.Property<DateTime>("end_time");

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("start_time");

                    b.HasKey("attId");

                    b.HasIndex("empId");

                    b.ToTable("Attendences");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Award_Punishment", b =>
                {
                    b.Property<int>("award_punishment_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("award_punishment")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("date");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<int>("employee_id");

                    b.Property<string>("remark")
                        .IsRequired();

                    b.HasKey("award_punishment_Id");

                    b.HasIndex("employee_id");

                    b.ToTable("Award_Punishment");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Branch", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("addressId");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("phone_1")
                        .IsRequired();

                    b.Property<string>("phone_2")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("addressId");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.CV_Form", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("address_id");

                    b.Property<int?>("announcement_id")
                        .IsRequired();

                    b.Property<DateTime?>("date")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("dob")
                        .IsRequired();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("gender")
                        .IsRequired();

                    b.Property<DateTime>("joined_date");

                    b.Property<string>("marital_status")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("nationality")
                        .IsRequired();

                    b.Property<string>("nrc")
                        .IsRequired();

                    b.Property<string>("permanent_address")
                        .IsRequired();

                    b.Property<string>("ph_no_personal")
                        .IsRequired();

                    b.Property<string>("ph_no_work")
                        .IsRequired();

                    b.Property<string>("qualification")
                        .IsRequired();

                    b.Property<string>("religion")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("address_id");

                    b.HasIndex("announcement_id");

                    b.ToTable("CV_Form");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Department", b =>
                {
                    b.Property<int?>("dept_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("branch_id")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("dept_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("phone_no")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("priority")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("dept_id");

                    b.HasIndex("branch_id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.DutyRoster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("From_Date")
                        .HasMaxLength(250);

                    b.Property<int>("Shift_Id");

                    b.Property<DateTime>("To_Date")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("Shift_Id");

                    b.ToTable("DutyRoster");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.DutyRosterDetail", b =>
                {
                    b.Property<int?>("dutyRosterDetail_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("dutyRoster_id")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("employee_id")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("dutyRosterDetail_id");

                    b.HasIndex("dutyRoster_id");

                    b.HasIndex("employee_id");

                    b.ToTable("DutyRosterDetail");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Employee", b =>
                {
                    b.Property<int?>("employeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("addressId");

                    b.Property<DateTime>("dob");

                    b.Property<string>("education_background")
                        .IsRequired();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("employee_Name")
                        .IsRequired();

                    b.Property<string>("employee_No")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("employee_state")
                        .IsRequired();

                    b.Property<string>("gender")
                        .IsRequired();

                    b.Property<DateTime>("joined_date");

                    b.Property<string>("marital_status")
                        .IsRequired();

                    b.Property<string>("nationality")
                        .IsRequired();

                    b.Property<string>("nrc")
                        .IsRequired();

                    b.Property<string>("permanent_address")
                        .IsRequired();

                    b.Property<string>("phone_no_personal")
                        .IsRequired();

                    b.Property<string>("phone_no_work")
                        .IsRequired();

                    b.Property<string>("religion")
                        .IsRequired();

                    b.HasKey("employeeId");

                    b.HasIndex("addressId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.EmployeeAttendence", b =>
                {
                    b.Property<int>("empAttendenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("attendence_Id");

                    b.Property<int>("location_Id");

                    b.HasKey("empAttendenceId");

                    b.HasIndex("attendence_Id");

                    b.HasIndex("location_Id");

                    b.ToTable("EmployeeAttendence");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.EmployeeRoles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("department_id");

                    b.Property<int>("employee_id");

                    b.Property<string>("end_date")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("rankId");

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("roleid");

                    b.Property<DateTime>("start_date")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.HasIndex("department_id");

                    b.HasIndex("employee_id");

                    b.HasIndex("rankId");

                    b.HasIndex("roleid");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Employee_training", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("employee_id");

                    b.Property<DateTime>("from_date");

                    b.Property<string>("remark")
                        .IsRequired();

                    b.Property<DateTime>("to_date");

                    b.Property<int>("trainingId")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.HasIndex("employee_id");

                    b.HasIndex("trainingId");

                    b.ToTable("Employee_training");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Leave", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Leave_type")
                        .HasMaxLength(50);

                    b.Property<int?>("employee_id");

                    b.Property<DateTime>("from_date");

                    b.Property<DateTime>("to_date");

                    b.HasKey("id");

                    b.HasIndex("employee_id");

                    b.ToTable("Leave");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Location", b =>
                {
                    b.Property<int?>("locId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("longitude");

                    b.Property<string>("lotitude")
                        .IsRequired();

                    b.Property<string>("remark")
                        .IsRequired();

                    b.HasKey("locId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Performance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("employee_id");

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("reward_id");

                    b.Property<int>("task_id");

                    b.HasKey("id");

                    b.HasIndex("employee_id");

                    b.HasIndex("reward_id");

                    b.HasIndex("task_id");

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Point", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Product_Performance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("attendence_id");

                    b.Property<int>("duty_roster_id");

                    b.Property<string>("finished_goods")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("unit_id");

                    b.HasKey("id");

                    b.HasIndex("attendence_id");

                    b.HasIndex("duty_roster_id");

                    b.ToTable(" Product_Performance");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Rank", b =>
                {
                    b.Property<int>("Rank_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Rank_Id");

                    b.ToTable("Rank");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Rate", b =>
                {
                    b.Property<int>("rateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("rate")
                        .IsRequired();

                    b.Property<byte>("type");

                    b.HasKey("rateId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Reward", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("payment")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("qty");

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Role", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Salary_range")
                        .IsRequired();

                    b.HasKey("Role_Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Rule", b =>
                {
                    b.Property<int>("Rule_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Rule_no");

                    b.HasKey("Rule_Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.ServicePerformance", b =>
                {
                    b.Property<int>("servicePerformanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("attendence_id")
                        .HasMaxLength(30);

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("work_done")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("servicePerformanceId");

                    b.HasIndex("attendence_id");

                    b.ToTable("ServicePerformance");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("End_Time")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Start_Time")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Tasked", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End_Time")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Start_Time")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tasked");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("pre_requestive")
                        .IsRequired();

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("training")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("firstName")
                        .IsRequired();

                    b.Property<string>("lastName")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<string>("position")
                        .IsRequired();

                    b.Property<string>("userName")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Absence", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employees")
                        .WithMany("Absences")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Rate", "Rates")
                        .WithMany("Absences")
                        .HasForeignKey("rate_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Attendence", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employees")
                        .WithMany("Attendences")
                        .HasForeignKey("empId");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Award_Punishment", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employees")
                        .WithMany("Award_Punishments")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Branch", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Address", "Addresses")
                        .WithMany("Branches")
                        .HasForeignKey("addressId");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.CV_Form", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Address", "Addresses")
                        .WithMany("CV_Forms")
                        .HasForeignKey("address_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Announcement", "Announcement")
                        .WithMany("CV_Forms")
                        .HasForeignKey("announcement_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Department", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Branch", "Branches")
                        .WithMany("Departments")
                        .HasForeignKey("branch_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.DutyRoster", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Shift", "Shift")
                        .WithMany("DutyRosters")
                        .HasForeignKey("Shift_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.DutyRosterDetail", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.DutyRoster", "DutyRosters")
                        .WithMany("DutyRosterDetails")
                        .HasForeignKey("dutyRoster_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employees")
                        .WithMany("DutyRosterDetails")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Employee", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Address", "Addresses")
                        .WithMany("Employees")
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.EmployeeAttendence", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Attendence", "Attendences")
                        .WithMany("EmployeeAttendences")
                        .HasForeignKey("attendence_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Location", "locations")
                        .WithMany("EmployeeAttendences")
                        .HasForeignKey("location_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.EmployeeRoles", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Department", "Department")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Rank", "Rank")
                        .WithMany("EmployeeRole")
                        .HasForeignKey("rankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Role", "Role")
                        .WithMany("EmployeeRole")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Employee_training", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employees")
                        .WithMany("EmployeeTrainings")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Training", "Trainings")
                        .WithMany("Employee_trainings")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Leave", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employees")
                        .WithMany("leaves")
                        .HasForeignKey("employee_id");
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Performance", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Employee", "Employee")
                        .WithMany("Performances")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Reward", "Reward")
                        .WithMany("performance")
                        .HasForeignKey("reward_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.Tasked", "Task")
                        .WithMany("performance")
                        .HasForeignKey("task_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.Product_Performance", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Attendence", "Attendence")
                        .WithMany("Product_Performances")
                        .HasForeignKey("attendence_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hr_Management_final_api.Domain.Models.DutyRoster", "DutyRoster")
                        .WithMany("Product_Performances")
                        .HasForeignKey("duty_roster_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hr_Management_final_api.Domain.Models.ServicePerformance", b =>
                {
                    b.HasOne("Hr_Management_final_api.Domain.Models.Attendence", "Attendence")
                        .WithMany("ServicePerformances")
                        .HasForeignKey("attendence_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
