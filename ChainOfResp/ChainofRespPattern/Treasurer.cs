﻿using ChainOfResp.DAL;
using ChainOfResp.Models;

namespace ChainOfResp.ChainofRespPattern
{
	public class Treasurer : Employee
	{
		private readonly Context _context;

		public Treasurer(Context context)
		{
			_context = context;
		}

		public override void ProcessRequest(CustomerViewModel customerViewModel)
		{
			if (customerViewModel.Amount <= 80000)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Name=customerViewModel.Name;
				customerProcess.Amount=customerViewModel.Amount;
				customerProcess.EmployeeName = "Emre Keskiner";
				customerProcess.Description = "Talep edilen tutar veznedar tarafından ödendi";
				_context.CustomerProcesses.Add(customerProcess);
				_context.SaveChanges();	
			}else if (NextApprover !=null)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				customerProcess.Name = customerViewModel.Name;
				customerProcess.Amount = customerViewModel.Amount;
				customerProcess.EmployeeName = "Emre Keskiner";
				customerProcess.Description = "Talep edilen tutar veznedar tarafından ödenmedi, işlem şube müdür yardımcısına aktarıldı.";
				_context.CustomerProcesses.Add(customerProcess);
				_context.SaveChanges();
				NextApprover.ProcessRequest(customerViewModel);
			}
		}
	}
}
