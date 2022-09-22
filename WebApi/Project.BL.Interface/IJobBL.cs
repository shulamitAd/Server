using EFModel.CustomEntities;
using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Interface
{
    public interface IJobBL
    {
        List<Jobs> GetChartData(FromToModel fromTo);
    }
}
