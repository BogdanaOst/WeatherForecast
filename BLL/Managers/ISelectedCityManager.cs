using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public interface ISelectedCityManager
    {
        List<SelectedCityDTO> GetAll();
        SelectedCityDTO GetById(int? id);
        void Add(SelectedCityDTO city_dto);
        void Update(SelectedCityDTO city_dto);
        void Delete(int id);
        void Dispose();
    }
}
