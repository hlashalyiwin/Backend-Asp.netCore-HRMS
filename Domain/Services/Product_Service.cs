//Developed by Nang Ah: Mon(Lashio)

using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Hr_Management_final_api.IServices;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
	//Product_Service class
    public class Product_Service : IProductService
    {

        private readonly IProduct_Performance_Repository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public Product_Service(IProduct_Performance_Repository ProductRepository,IUnitOfWork unitofwork)
        {
            _productRepository = ProductRepository;
			_unitOfWork = unitofwork;
        }


        public async Task<IEnumerable<Product_Performance>> ListAsync()//List all data
        {
			await _unitOfWork.CompleteAsync();
            return await _productRepository.ListAsync();
        }
		public async Task<Product_Performance> GetByIdAsync(int id)//get by id
		{
			return await _productRepository.FindByIdAsync(id);
			 
		}


        public async Task<SaveProduct_Performance_Response> SaveAsync(Product_Performance Product_Performance)
		//Save data
		{
			try
			{
				await _productRepository.AddAsync(Product_Performance);
				await _unitOfWork.CompleteAsync();
			
				return new SaveProduct_Performance_Response(Product_Performance);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveProduct_Performance_Response($"An error occurred when saving the Product_Performance: {ex.Message}");
			}
		}

		public async Task<SaveProduct_Performance_Response> UpdateAsync(int id, Product_Performance Product_Performance)
		//Update by id
		{
			var existingProduct_Performance = await _productRepository.FindByIdAsync(id);
			
			if (existingProduct_Performance == null)
				return  new SaveProduct_Performance_Response("Product_Performance not found.");
			
			///Authorized By NiNiWinMay(Table Joining) 24.6.2019
			existingProduct_Performance.unit_id= Product_Performance.unit_id;
			existingProduct_Performance.finished_goods = Product_Performance.finished_goods;
			existingProduct_Performance.Attendence.date=Product_Performance.Attendence.date;
            existingProduct_Performance.Attendence.start_time=Product_Performance.Attendence.start_time;
            existingProduct_Performance.Attendence.end_time = Product_Performance.Attendence.end_time;
            existingProduct_Performance.Attendence.attendenceType=Product_Performance.Attendence.attendenceType;
            existingProduct_Performance.Attendence.remark=Product_Performance.Attendence?.remark;
			existingProduct_Performance.Attendence.Employees.employee_No = Product_Performance.Attendence?.Employees.employee_No;
			existingProduct_Performance.Attendence.Employees.employee_Name= Product_Performance.Attendence?.Employees.employee_Name;
            existingProduct_Performance.Attendence.Employees.email=Product_Performance.Attendence?.Employees.email;
            existingProduct_Performance.Attendence.Employees.dob=Product_Performance.Attendence.Employees.dob;
            existingProduct_Performance.Attendence.Employees.nrc=Product_Performance.Attendence?.Employees.nrc;	
			existingProduct_Performance.Attendence.Employees.phone_no_work=Product_Performance.Attendence?.Employees.phone_no_work;
			existingProduct_Performance.Attendence.Employees.phone_no_personal=Product_Performance.Attendence?.Employees.phone_no_personal;
			existingProduct_Performance.Attendence.Employees.gender=Product_Performance.Attendence?.Employees.gender;
			existingProduct_Performance.Attendence.Employees.marital_status=Product_Performance.Attendence?.Employees.marital_status;
			existingProduct_Performance.Attendence.Employees.nationality=Product_Performance.Attendence?.Employees.nationality;
			existingProduct_Performance.Attendence.Employees.religion=Product_Performance.Attendence?.Employees.religion;
			existingProduct_Performance.Attendence.Employees.permanent_address=Product_Performance.Attendence?.Employees.permanent_address;
			existingProduct_Performance.Attendence.Employees.education_background=Product_Performance.Attendence?.Employees.education_background;
			//existingProduct_Performance.Attendence.Employees.addressId=Product_Performance.Attendence?.Employees.addressId;
			existingProduct_Performance.Attendence.Employees.joined_date=Product_Performance.Attendence.Employees.joined_date;
			existingProduct_Performance.Attendence.Employees.employee_state=Product_Performance.Attendence?.Employees.employee_state;
			existingProduct_Performance.Attendence.Employees.Addresses.line_1= Product_Performance.Attendence?.Employees.Addresses.line_1;
			existingProduct_Performance.Attendence.Employees.Addresses.line_2= Product_Performance.Attendence?.Employees.Addresses.line_2;
			existingProduct_Performance.Attendence.Employees.Addresses.region= Product_Performance.Attendence?.Employees.Addresses.region;
			existingProduct_Performance.Attendence.Employees.Addresses.country= Product_Performance.Attendence?.Employees.Addresses.country;
			existingProduct_Performance.DutyRoster.From_Date= Product_Performance.DutyRoster.From_Date;
			existingProduct_Performance.DutyRoster.To_Date= Product_Performance.DutyRoster.To_Date;
			existingProduct_Performance.DutyRoster.Shift.Name= Product_Performance.DutyRoster?.Shift.Name;
			existingProduct_Performance.DutyRoster.Shift.Start_Time= Product_Performance.DutyRoster.Shift.Start_Time;
			existingProduct_Performance.DutyRoster.Shift.End_Time= Product_Performance.DutyRoster.Shift.End_Time;
			
			

			try
			{
				_productRepository.Update(existingProduct_Performance);
				await _unitOfWork.CompleteAsync();

				 return new SaveProduct_Performance_Response(existingProduct_Performance);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveProduct_Performance_Response($"An error occurred when saving the Department: {ex.Message}");
			}
		}

		public async Task<SaveProduct_Performance_Response> DeleteAsync(int id)//Delete by id
		{
			var existingProduct_Performance = await _productRepository.FindByIdAsync(id);
			await _unitOfWork.CompleteAsync();

			if (existingProduct_Performance == null)
				return new SaveProduct_Performance_Response("Product_Performance not found.");
			//existingProduct_Performance=await Product_Performance.Transport;
			try
			{
				_productRepository.Remove(existingProduct_Performance);
				//_productRepository.Remove(Transport);
				await _unitOfWork.CompleteAsync();


				return new SaveProduct_Performance_Response("Success");
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new SaveProduct_Performance_Response($"An error occurred when deleting the Product_Performance: {ex.Message}");
			}
		}
		public async Task<IEnumerable<Product_Performance>> FindByDate(int day,int month,int year ){
			return await _productRepository.FindByDate(day,month,year);
		}
        
    }
}