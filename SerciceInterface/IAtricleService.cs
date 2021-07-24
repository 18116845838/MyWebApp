using _17bangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.SerciceInterface
{
    public interface IAtricleService
    {
        void Publish(ArcticleModel model/*, int currentUserId*/);
		ArcticleModel GetEdit(int id);
		void Edit(int id, ArcticleModel model);
	}
}
