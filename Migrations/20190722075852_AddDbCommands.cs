using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hr_Management_final_api.Migrations
{
    public partial class AddDbCommands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    line_1 = table.Column<string>(maxLength: 30, nullable: false),
                    line_2 = table.Column<string>(maxLength: 30, nullable: false),
                    township = table.Column<string>(maxLength: 30, nullable: false),
                    city = table.Column<string>(maxLength: 30, nullable: false),
                    region = table.Column<string>(maxLength: 30, nullable: false),
                    country = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addId);
                });

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lotitude = table.Column<string>(nullable: false),
                    longitude = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locId);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Price = table.Column<double>(maxLength: 250, nullable: false),
                    Remark = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Rank_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Rank_Id);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    rateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    rate = table.Column<string>(nullable: false),
                    type = table.Column<byte>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.rateId);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    qty = table.Column<int>(nullable: false),
                    payment = table.Column<string>(maxLength: 50, nullable: false),
                    remark = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Priority = table.Column<string>(maxLength: 30, nullable: false),
                    Salary_range = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Rule_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rule_no = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Rule_Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Start_Time = table.Column<string>(maxLength: 250, nullable: false),
                    End_Time = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasked",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Start_Time = table.Column<DateTime>(maxLength: 50, nullable: false),
                    End_Time = table.Column<DateTime>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    Remark = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasked", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    training = table.Column<string>(nullable: false),
                    duration = table.Column<string>(maxLength: 30, nullable: false),
                    pre_requestive = table.Column<string>(nullable: false),
                    remark = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    position = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    phone_1 = table.Column<string>(nullable: false),
                    phone_2 = table.Column<string>(nullable: false),
                    addressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branchs_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "addId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    employee_No = table.Column<string>(maxLength: 50, nullable: false),
                    employee_Name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    dob = table.Column<DateTime>(nullable: false),
                    nrc = table.Column<string>(nullable: false),
                    phone_no_work = table.Column<string>(nullable: false),
                    phone_no_personal = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    marital_status = table.Column<string>(nullable: false),
                    nationality = table.Column<string>(nullable: false),
                    religion = table.Column<string>(nullable: false),
                    permanent_address = table.Column<string>(nullable: false),
                    education_background = table.Column<string>(nullable: false),
                    joined_date = table.Column<DateTime>(nullable: false),
                    employee_state = table.Column<string>(nullable: false),
                    addressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "addId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CV_Form",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(maxLength: 50, nullable: false),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    dob = table.Column<DateTime>(nullable: false),
                    nrc = table.Column<string>(nullable: false),
                    ph_no_work = table.Column<string>(nullable: false),
                    ph_no_personal = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    marital_status = table.Column<string>(nullable: false),
                    nationality = table.Column<string>(nullable: false),
                    religion = table.Column<string>(nullable: false),
                    permanent_address = table.Column<string>(nullable: false),
                    qualification = table.Column<string>(nullable: false),
                    joined_date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    address_id = table.Column<int>(nullable: false),
                    announcement_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_Form", x => x.id);
                    table.ForeignKey(
                        name: "FK_CV_Form_Address_address_id",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "addId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV_Form_Announcement_announcement_id",
                        column: x => x.announcement_id,
                        principalTable: "Announcement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutyRoster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Shift_Id = table.Column<int>(nullable: false),
                    From_Date = table.Column<DateTime>(maxLength: 250, nullable: false),
                    To_Date = table.Column<DateTime>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyRoster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DutyRoster_Shifts_Shift_Id",
                        column: x => x.Shift_Id,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    dept_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dept_name = table.Column<string>(maxLength: 50, nullable: false),
                    priority = table.Column<string>(maxLength: 50, nullable: false),
                    phone_no = table.Column<string>(maxLength: 50, nullable: false),
                    remark = table.Column<string>(maxLength: 50, nullable: false),
                    branch_id = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.dept_id);
                    table.ForeignKey(
                        name: "FK_Department_Branchs_branch_id",
                        column: x => x.branch_id,
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    rate_id = table.Column<int>(nullable: false),
                    employee_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absence_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absence_Rate_rate_id",
                        column: x => x.rate_id,
                        principalTable: "Rate",
                        principalColumn: "rateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendences",
                columns: table => new
                {
                    attId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    start_time = table.Column<DateTime>(nullable: false),
                    end_time = table.Column<DateTime>(nullable: false),
                    attendenceType = table.Column<byte>(maxLength: 30, nullable: false),
                    remark = table.Column<string>(maxLength: 30, nullable: false),
                    empId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendences", x => x.attId);
                    table.ForeignKey(
                        name: "FK_Attendences_Employee_empId",
                        column: x => x.empId,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Award_Punishment",
                columns: table => new
                {
                    award_punishment_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    award_punishment = table.Column<string>(maxLength: 30, nullable: false),
                    date = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    remark = table.Column<string>(nullable: false),
                    employee_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award_Punishment", x => x.award_punishment_Id);
                    table.ForeignKey(
                        name: "FK_Award_Punishment_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_training",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    from_date = table.Column<DateTime>(nullable: false),
                    to_date = table.Column<DateTime>(nullable: false),
                    remark = table.Column<string>(nullable: false),
                    employee_id = table.Column<int>(nullable: false),
                    trainingId = table.Column<int>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_training", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_training_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_training_Training_trainingId",
                        column: x => x.trainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Leave_type = table.Column<byte>(maxLength: 50, nullable: false),
                    from_date = table.Column<DateTime>(nullable: false),
                    to_date = table.Column<DateTime>(nullable: false),
                    employee_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.id);
                    table.ForeignKey(
                        name: "FK_Leave_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    task_id = table.Column<int>(nullable: false),
                    reward_id = table.Column<int>(nullable: false),
                    remark = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Performance_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performance_Reward_reward_id",
                        column: x => x.reward_id,
                        principalTable: "Reward",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performance_Tasked_task_id",
                        column: x => x.task_id,
                        principalTable: "Tasked",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutyRosterDetail",
                columns: table => new
                {
                    dutyRosterDetail_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dutyRoster_id = table.Column<int>(maxLength: 250, nullable: false),
                    employee_id = table.Column<int>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyRosterDetail", x => x.dutyRosterDetail_id);
                    table.ForeignKey(
                        name: "FK_DutyRosterDetail_DutyRoster_dutyRoster_id",
                        column: x => x.dutyRoster_id,
                        principalTable: "DutyRoster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutyRosterDetail_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    start_date = table.Column<DateTime>(maxLength: 30, nullable: false),
                    end_date = table.Column<string>(maxLength: 30, nullable: false),
                    remark = table.Column<string>(maxLength: 100, nullable: false),
                    roleid = table.Column<int>(nullable: false),
                    rankId = table.Column<int>(nullable: false),
                    employee_id = table.Column<int>(nullable: false),
                    department_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "dept_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Rank_rankId",
                        column: x => x.rankId,
                        principalTable: "Rank",
                        principalColumn: "Rank_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Role_roleid",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: " Product_Performance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    attendence_id = table.Column<int>(nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    finished_goods = table.Column<string>(maxLength: 30, nullable: false),
                    duty_roster_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Product_Performance", x => x.id);
                    table.ForeignKey(
                        name: "FK_ Product_Performance_Attendences_attendence_id",
                        column: x => x.attendence_id,
                        principalTable: "Attendences",
                        principalColumn: "attId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ Product_Performance_DutyRoster_duty_roster_id",
                        column: x => x.duty_roster_id,
                        principalTable: "DutyRoster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendence",
                columns: table => new
                {
                    empAttendenceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    location_Id = table.Column<int>(nullable: false),
                    attendence_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendence", x => x.empAttendenceId);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendence_Attendences_attendence_Id",
                        column: x => x.attendence_Id,
                        principalTable: "Attendences",
                        principalColumn: "attId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendence_Locations_location_Id",
                        column: x => x.location_Id,
                        principalTable: "Locations",
                        principalColumn: "locId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePerformance",
                columns: table => new
                {
                    servicePerformanceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    work_done = table.Column<string>(maxLength: 30, nullable: false),
                    remark = table.Column<string>(maxLength: 30, nullable: false),
                    attendence_id = table.Column<int>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePerformance", x => x.servicePerformanceId);
                    table.ForeignKey(
                        name: "FK_ServicePerformance_Attendences_attendence_id",
                        column: x => x.attendence_id,
                        principalTable: "Attendences",
                        principalColumn: "attId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ Product_Performance_attendence_id",
                table: " Product_Performance",
                column: "attendence_id");

            migrationBuilder.CreateIndex(
                name: "IX_ Product_Performance_duty_roster_id",
                table: " Product_Performance",
                column: "duty_roster_id");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_employee_id",
                table: "Absence",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_rate_id",
                table: "Absence",
                column: "rate_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_empId",
                table: "Attendences",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_Award_Punishment_employee_id",
                table: "Award_Punishment",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_addressId",
                table: "Branchs",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_Form_address_id",
                table: "CV_Form",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_CV_Form_announcement_id",
                table: "CV_Form",
                column: "announcement_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_branch_id",
                table: "Department",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_DutyRoster_Shift_Id",
                table: "DutyRoster",
                column: "Shift_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DutyRosterDetail_dutyRoster_id",
                table: "DutyRosterDetail",
                column: "dutyRoster_id");

            migrationBuilder.CreateIndex(
                name: "IX_DutyRosterDetail_employee_id",
                table: "DutyRosterDetail",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_addressId",
                table: "Employee",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_training_employee_id",
                table: "Employee_training",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_training_trainingId",
                table: "Employee_training",
                column: "trainingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendence_attendence_Id",
                table: "EmployeeAttendence",
                column: "attendence_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendence_location_Id",
                table: "EmployeeAttendence",
                column: "location_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_department_id",
                table: "EmployeeRoles",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_employee_id",
                table: "EmployeeRoles",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_rankId",
                table: "EmployeeRoles",
                column: "rankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_roleid",
                table: "EmployeeRoles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_employee_id",
                table: "Leave",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_employee_id",
                table: "Performance",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_reward_id",
                table: "Performance",
                column: "reward_id");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_task_id",
                table: "Performance",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePerformance_attendence_id",
                table: "ServicePerformance",
                column: "attendence_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " Product_Performance");

            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "Award_Punishment");

            migrationBuilder.DropTable(
                name: "CV_Form");

            migrationBuilder.DropTable(
                name: "DutyRosterDetail");

            migrationBuilder.DropTable(
                name: "Employee_training");

            migrationBuilder.DropTable(
                name: "EmployeeAttendence");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "ServicePerformance");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "DutyRoster");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Tasked");

            migrationBuilder.DropTable(
                name: "Attendences");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
