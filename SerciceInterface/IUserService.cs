using _17bangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace SRV.SerciceInterface
{
	public interface IUserService
	{
		UserModel GetByName(string name);
		string GetById(int Id);
		int? Register(RegisterModel mdodel);
	}
}
